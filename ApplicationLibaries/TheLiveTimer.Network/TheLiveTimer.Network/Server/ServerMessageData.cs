namespace TheLiveTimer.Network
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class ServerMessageData : NetworkData
    {
        public ServerMessageData(ServerMessage serverMessage, NetworkAddress address, byte[] args = null) 
        {
            this.ServerMessage = serverMessage;
            this.Address = address;
            this.Arguments = args ?? new byte[0];
        }

        /// <summary>
        /// The arguments being sent with the data, if any
        /// </summary>
        public byte[] Arguments { get; }

        public ServerMessage ServerMessage { get; }

        public NetworkAddress Address { get; }
	}
}
