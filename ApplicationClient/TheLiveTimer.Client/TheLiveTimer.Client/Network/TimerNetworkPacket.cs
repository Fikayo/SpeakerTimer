namespace TheLiveTimer.Client.Network
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Security.Permissions;

    [Serializable]
    class TimerNetworkPacket : ISerializable
    {
        /// <summary>
        /// The index of the packet identifier in the network packet byte array.
        /// </summary>
        public const int PacketIdIndex = 0;

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
        public const int ArgumentsIndex = 21;

        /* --------------------- */

        /// <summary>
        /// The packet id for this network packet
        /// </summary>
        public Int64 PacketId { get; private set; }

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

        public TimerNetworkPacket(Int64 packetId, Int64 commnicationId, TimerNetworkCommand command, byte[] arguments)
        {
            this.PacketId = packetId;
            this.CommunicationId = commnicationId;
            this.Command = command;
            this.Arguments = arguments == null ? new byte[0] : arguments;
        }

        protected TimerNetworkPacket(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));

            this.PacketId = info.GetInt64(nameof(PacketId));
            this.CommunicationId = info.GetInt64(nameof(CommunicationId));
            this.Command = (TimerNetworkCommand)info.GetValue(nameof(Command), typeof(TimerNetworkCommand));
            this.Arguments = NetworkUtils.ObjectToByteArray(info.GetValue(nameof(Arguments), typeof(byte[])));
        }


        /// <summary>
        /// Converts the byte array into a <see cref="TimerNetworkPacket"/>
        /// </summary>
        /// <returns>A <see cref="TimerNetworkPacket"/></returns>
        /// <param name="data">A byte array</param>
        public static TimerNetworkPacket FromBytes(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            var packIdBytes = new byte[sizeof(Int64)];
            var commIdBytes = new byte[sizeof(Int64)];
            var argLenghtBytes = new byte[sizeof(Int32)];
            var commandBytes = new byte[sizeof(TimerNetworkCommand)];

            Buffer.BlockCopy(data, PacketIdIndex, packIdBytes, 0, packIdBytes.Length);
            Int64 packetId = BitConverter.ToInt64(packIdBytes, 0);

            Buffer.BlockCopy(data, CommunicationIdIndex, commIdBytes, 0, commIdBytes.Length);
            Int64 communicationId = BitConverter.ToInt64(commIdBytes, 0);

            Buffer.BlockCopy(data, ArgumentsLengthIndex, argLenghtBytes, 0, argLenghtBytes.Length);
            int argsLength = BitConverter.ToInt32(argLenghtBytes, 0);

            Buffer.BlockCopy(data, CommandIndex, commandBytes, 0, commandBytes.Length);
            TimerNetworkCommand command = (TimerNetworkCommand)BitConverter.ToInt32(commandBytes, 0);

            var arguments = new byte[argsLength];
            Buffer.BlockCopy(data, ArgumentsIndex, arguments, 0, arguments.Length);

            return new TimerNetworkPacket(packetId, communicationId, command, arguments);
        }

        /// <summary>
        /// Gets the Network packet as a byte array with the followign protocol
        /// 
        /// packet id = 8 bytes
        /// commnication id = 8 bytes
        /// arg length = 4 bytes
        /// command = 1 byte
        /// arg = remaning
        /// 
        /// </summary>
        /// <returns>This <see cref="TimerNetworkPacket"/> as a byte array</returns>
        public byte[] ToByteArray()
        {
            int dataLength = 2 * sizeof(Int64) + sizeof(TimerNetworkCommand) + sizeof(Int32) + this.Arguments.Length;
            var data = new byte[dataLength];

            var packIdBytes = BitConverter.GetBytes(this.PacketId);
            var commIdBytes = BitConverter.GetBytes(this.CommunicationId);
            var argLenghtBytes = BitConverter.GetBytes(this.Arguments.Length);
            var commandBytes = BitConverter.GetBytes((int)this.Command);


            Buffer.BlockCopy(packIdBytes, 0, data, PacketIdIndex, packIdBytes.Length);
            Buffer.BlockCopy(commIdBytes, 0, data, CommunicationIdIndex, commIdBytes.Length);
            Buffer.BlockCopy(argLenghtBytes, 0, data, ArgumentsLengthIndex, argLenghtBytes.Length);
            Buffer.BlockCopy(commandBytes, 0, data, CommandIndex, commandBytes.Length);
            Buffer.BlockCopy(this.Arguments, 0, data, ArgumentsIndex, this.Arguments.Length);

            return data;
        }

        //[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));

            info.AddValue(nameof(PacketId), this.PacketId);
            info.AddValue(nameof(CommunicationId), this.CommunicationId);
            info.AddValue(nameof(Command), this.Command);
            info.AddValue(nameof(Arguments), this.Arguments);
        }

        //[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));

            GetObjectData(info, context);
        }
    }
}
