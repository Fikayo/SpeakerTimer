namespace TheLiveTimer.Network
{
    using System;
    using System.Runtime.Serialization;

    public class ServerMessageData : NetworkData
    {
        public ServerMessageData(ServerMessage ServerMessage)
        {
            this.ServerMessage = ServerMessage;
        }

        protected ServerMessageData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            this.ServerMessage = (ServerMessage)info.GetValue(nameof(ServerMessage), typeof(ServerMessage));
        }

        public ServerMessage ServerMessage { get; private set; }

        protected override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            info.AddValue(nameof(ServerMessage), this.ServerMessage);
        }
    }
}
