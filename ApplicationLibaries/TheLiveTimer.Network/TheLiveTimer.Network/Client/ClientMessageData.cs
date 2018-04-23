namespace TheLiveTimer.Network
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class ClientMessageData : NetworkData
    {
        public ClientMessageData(ClientMessage clientMessage, NetworkAddress clientAddress, byte[] args = null)
        {
            this.ClientMessage = clientMessage;
            this.ClientAddress = clientAddress;
            this.Arguments = args ?? new byte[0];
        }

        /// <summary>
        /// The arguments being sent with the data, if any
        /// </summary>
        public byte[] Arguments { get; }

        public ClientMessage ClientMessage { get; }

        public NetworkAddress ClientAddress { get; }
    }
}
