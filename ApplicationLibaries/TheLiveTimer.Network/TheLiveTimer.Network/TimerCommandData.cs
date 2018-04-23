namespace TheLiveTimer.Network
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class TimerCommandData : NetworkData
    {
        public TimerCommandData(Int64 commnicationId, TimerCommand command, byte[] arguments)
        {
            this.CommunicationId = commnicationId;
            this.Command = command;
            this.Arguments = arguments ?? new byte[0];
        }

        /// <summary>
        /// The arguments being sent with the data, if any
        /// </summary>
        public byte[] Arguments { get; }

        /// <summary>
        /// The current cuoomnication id used to sync master and clients
        /// </summary>
        public Int64 CommunicationId { get; }

        /// <summary>
        /// The command being sent
        /// </summary>
        public TimerCommand Command { get; }
	}
}
