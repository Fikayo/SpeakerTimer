namespace TheLiveTimer.Client.Network
{
    using System;
    using System.Net.Sockets;
    using TheLiveTimer.Network;

    internal class ServerMessageProcessor
    {
        public ServerMessageProcessor(ClientNetworkCommunicator communicator)
        {
            this.NetworkCommunicator = communicator;
        }

        public event EventHandler<ClientAcceptedEventArgs> ClientAccepted;

        public event EventHandler<ClientDeclinedEventArgs> ClientDeclined;

        public ClientNetworkCommunicator NetworkCommunicator { get; }

        public void ProcessServerMessage(ServerMessageData serverMessage)
        {
            switch (serverMessage.ServerMessage)
            {
                case ServerMessage.ServerReady:
                    {
                        Console.WriteLine("--- Server Ready message from server.");
                        Console.WriteLine("--- Responding with Request");
                        Console.WriteLine("--- check null");
                        Console.WriteLine("--- its {0}", serverMessage.Address == null);

                        // Server is ready to accept clients
                        var address = serverMessage.Address;
                        Console.WriteLine("--- have the addy");

                        var serverTcpClient = new TcpClient(address.IP.ToString(), address.Port);
                        Console.WriteLine("--- have the tcp client");


                        // Transmit request to server
                        this.NetworkCommunicator.Transmit(serverTcpClient, ClientMessage.ClientRequest);
                        break;
                    }

                case ServerMessage.ClientAccepted:
                    {
                        // Someone has been accepted as a client - check if it's me
                        var address = serverMessage.Address;

                        if (address.Equals(this.NetworkCommunicator.ClientAddress))
                        {
                            // Hooray, it's us

                            // Get the communication id from the arguments
                            var commId = BitConverter.ToInt64(serverMessage.Arguments, 0);

                            this.OnClientAccepted(commId);
                        }

                        break;
                    }

                case ServerMessage.ClientDeclined:
                    {
                        // This client was declined for an unknown reason
                        // Report to user
                        this.OnClientDeclined();
                        break;
                    }

                case ServerMessage.ClientMax:
                    {
                        // Max clients reached by server. So declined.
                        // Tell user
                        // Wait for 30 seconds then try again
                        this.OnClientDeclined(true);
                        break;
                    }

                case ServerMessage.LivenessChecker:
                    {
                        // Liveness checke. Get the next communication id from the arguments
                        var commId = BitConverter.ToInt64(serverMessage.Arguments, 0);
                        this.OnClientAccepted(commId);
                        break;
                    }

                default:
                    {
                        Console.WriteLine("Unknown server message: {0}", serverMessage.ServerMessage);
                        break;
                    }
            }
        }

        private void OnClientAccepted(long commId)
        {
            var handler = this.ClientAccepted;
            if (handler != null)
            {
                handler.Invoke(this, new ClientAcceptedEventArgs(commId));
            }
        }

        private void OnClientDeclined(bool maxClients = false)
        {
            var handler = this.ClientDeclined;
            if (handler != null)
            {
                handler.Invoke(this, new ClientDeclinedEventArgs(maxClients));
            }
        }
    }
}
