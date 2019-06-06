namespace TheLiveTimer.Server.Network
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks.Dataflow;
    using TheLiveTimer.Server.Network;
    using TheLiveTimer.Network;

    internal class ClientManager
    {
        public const int MaxClients = 10;


        private NetworkCommunicator networkCommunicator;
        private readonly Dictionary<NetworkAddress, bool> clientLivenessMap;

        public ClientManager(NetworkCommunicator networkCommunicator)
        {
            this.networkCommunicator = networkCommunicator;
            this.clientLivenessMap = new Dictionary<NetworkAddress, bool>();
        }

        public int TotalClients { get { return this.clientLivenessMap.Count; } }

        public void HandleClientPacket(ReceivedPacket receivedPacket)
        {
            var clientMessage = ClientMessage.Unknown;
            var clientAddress = receivedPacket.Sender;
            if (!receivedPacket.HasError)
            {
                var clientMessageData = receivedPacket.Packet.NetworkData as ClientMessageData;
                clientAddress = clientMessageData.ClientAddress;
                clientMessage = clientMessageData.ClientMessage;

                Console.WriteLine("-> Parcel recieved from Client: {0}:{1}", clientAddress.IP, clientAddress.Port);
            }

            switch (clientMessage)
            {
                case ClientMessage.ClientRequest:
                    {
                        Console.WriteLine("--> Client Request received");
                        var serverMessage = default(ServerMessage);
                        byte[] args = null;

                        if (receivedPacket.HasError)
                        {
                            // Error while getting request
                            Console.WriteLine("--> Declining client request");
                            serverMessage = ServerMessage.ClientDeclined;
                        }
                        else if (this.TotalClients <= MaxClients)
                        {
                            // Request received successfully
                            Console.WriteLine("--> Accepting client request");
                            serverMessage = ServerMessage.ClientAccepted;
                            args = BitConverter.GetBytes(this.networkCommunicator.CommunicationId);

                            // Add client address to the list of clients
                            this.AddOrUpdateClientMap(clientAddress, true);
                        }
                        else
                        {
                            // Max clients reached
                            Console.WriteLine("--> Mex clients reached. Declining");
                            serverMessage = ServerMessage.ClientMax;
                            clientAddress = null;
                        }

                        // Send response to back to everyone
                        var data = new ServerMessageData(serverMessage, clientAddress, args);
                        this.networkCommunicator.TransmitData(data);
                        break;
                    }

                case ClientMessage.LivenessResponse:
                    {
                        if (!receivedPacket.HasError)
                        {
                            // Set live state back to true
                            this.AddOrUpdateClientMap(clientAddress, true);
                        }

                        break;
                    }

                case ClientMessage.Unknown:
                default:
                    {
                        //throw new Exception(string.Format("Don't understand your client message: {0}", clientMessageData.ClientMessage));

                        // Send response to back to everyone
                        var data = new ServerMessageData(ServerMessage.Error, clientAddress);
                        this.networkCommunicator.TransmitData(data);
                        break;
                    }
            }
        }

        private void PollClients()
        {
            byte[] args = BitConverter.GetBytes(CommandDataFactory.Instance.NextCommunicationId());

            foreach (var address in this.clientLivenessMap.Keys)
            {
                // Set their live state to false before polling
                this.AddOrUpdateClientMap(address, false);

                var data = new ServerMessageData(ServerMessage.LivenessChecker, address, args);
                this.networkCommunicator.TransmitData(data);
            }
        }

        private void AddOrUpdateClientMap(NetworkAddress clientAddress, bool isLive)
        {
            lock (this.clientLivenessMap)
            {
                if (!this.clientLivenessMap.ContainsKey(clientAddress))
                {
                    this.clientLivenessMap.Add(clientAddress, isLive);
                }
                else
                {
                    this.clientLivenessMap[clientAddress] = isLive;
                }
            }
        }
    }
}
