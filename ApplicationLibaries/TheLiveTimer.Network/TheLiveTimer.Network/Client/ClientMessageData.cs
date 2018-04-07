namespace TheLiveTimer.Network
{
    using System;
    using System.Runtime.Serialization;

    public class ClientMessageData : NetworkData
    {
        public ClientMessageData(ClientMessage clientMessage)
        {
            this.ClientMessage = clientMessage;
        }

        protected ClientMessageData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            this.ClientMessage = (ClientMessage)info.GetValue(nameof(ClientMessage), typeof(ClientMessage));
        }

        public ClientMessage ClientMessage { get; private set; }

        protected override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            info.AddValue(nameof(ClientMessage), this.ClientMessage);
        }
    }
}
