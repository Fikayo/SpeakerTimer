namespace TheLiveTimer.Network
{
    using System;
    using System.Runtime.Serialization;

    public class TimerCommandData : NetworkData
    {
        /*
        /// <summary>
        /// The index of the communication identifier in the network packet in the network packet byte array.
        /// </summary>
        public const int CommunicationIdIndex = 8;

        /// <summary>
        /// The index of the <see cref="TimerNetworkCommand"/>  in the network packet byte array.
        /// </summary>
        public const int CommandIndex = 16;

        /// <summary>
        /// The index of the arguments length in the network packet byte array.
        /// </summary>
        public const int ArgumentsLengthIndex = 20;

        /// <summary>
        /// The starting index of the arguments list in the network packet byte array.
        /// </summary>
        public const int ArgumentsIndex = 24;
        */

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

        /*
        public override int DataLength
        {
            get { return sizeof(Int64) + sizeof(TimerNetworkCommand) + sizeof(Int32) + this.Arguments.Length; }
        }

		/// <summary>
		/// Converts the byte array into a <see cref="TimerNetworkPacket"/>
		/// </summary>
		/// <returns>A <see cref="TimerNetworkPacket"/></returns>
		/// <param name="data">A byte array</param>
        protected static TimerCommandData FromBytes(byte[] data, int startIdx)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            var commIdBytes = new byte[sizeof(Int64)];
            var argLenghtBytes = new byte[sizeof(Int32)];
            var commandBytes = new byte[sizeof(TimerNetworkCommand)];

            Buffer.BlockCopy(data, startIdx + CommunicationIdIndex, commIdBytes, 0, commIdBytes.Length);
            Int64 communicationId = BitConverter.ToInt64(commIdBytes, 0);

            Buffer.BlockCopy(data, startIdx + ArgumentsLengthIndex, argLenghtBytes, 0, argLenghtBytes.Length);
            int argsLength = BitConverter.ToInt32(argLenghtBytes, 0);

            Buffer.BlockCopy(data, startIdx + CommandIndex, commandBytes, 0, commandBytes.Length);
            TimerNetworkCommand command = (TimerNetworkCommand)BitConverter.ToInt32(commandBytes, 0);

            var arguments = new byte[argsLength];
            Buffer.BlockCopy(data, startIdx + ArgumentsIndex, arguments, 0, arguments.Length);

            return new TimerCommandData(communicationId, command, arguments);
        }

        /// <summary>
        /// Gets the Network packet as a byte array with the followign protocol
        /// 
        /// commnication id = 8 bytes
        /// arg length = 4 bytes
        /// command = 1 byte
        /// arg = remaning
        /// 
        /// </summary>
        /// <returns>This <see cref="TimerNetworkPacket"/> as a byte array</returns>
        protected override byte[] GetBytes(byte[] data, int startIdx)
        {
            //var data = new byte[this.DataLength];

            // Transfer the Commnuication Id
            var commIdBytes = BitConverter.GetBytes(this.CommunicationId);
            Buffer.BlockCopy(commIdBytes, 0, data, startIdx + CommunicationIdIndex, commIdBytes.Length);

            // Transfer the length of the arguments
            var argLenghtBytes = BitConverter.GetBytes(this.Arguments.Length);
            Buffer.BlockCopy(argLenghtBytes, 0, data, startIdx + ArgumentsLengthIndex, argLenghtBytes.Length);

            // Transfer the command
            var commandBytes = BitConverter.GetBytes((int)this.Command);
            Buffer.BlockCopy(commandBytes, 0, data, startIdx + CommandIndex, commandBytes.Length);

            // Finally, transger the argumets to the command
            Buffer.BlockCopy(this.Arguments, 0, data, startIdx + ArgumentsIndex, this.Arguments.Length);

            return data;
        }*/

        protected override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            info.AddValue(nameof(CommunicationId), this.CommunicationId);
            info.AddValue(nameof(Command), this.Command);
            info.AddValue(nameof(Arguments), this.Arguments);
        }
    }
}
