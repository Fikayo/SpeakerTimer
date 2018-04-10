namespace TheLiveTimer.Network
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class TimerCommandData : NetworkData
    {
        public TimerCommandData(Int64 commnicationId, TimerNetworkCommand command, byte[] arguments)
        {
            this.CommunicationId = commnicationId;
            this.Command = command;
            this.Arguments = arguments ?? new byte[0];
        }

        protected TimerCommandData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            this.CommunicationId = info.GetInt64(nameof(CommunicationId));
            this.Command = (TimerNetworkCommand)info.GetValue(nameof(Command), typeof(TimerNetworkCommand));
            this.Arguments = NetworkUtils.ObjectToByteArray(info.GetValue(nameof(Arguments), typeof(byte[])));
        }

        /// <summary>
        /// The current cuoomnication id used to sync master and clients
        /// </summary>
        public Int64 CommunicationId { get; private set; }

        /// <summary>
        /// The command being sent
        /// </summary>
        public TimerNetworkCommand Command { get; private set; }

        /// <summary>
        /// The arguments being sent with the command
        /// </summary>
        public byte[] Arguments { get; private set; }
	}
}
