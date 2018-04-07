namespace TheLiveTimer.Network
{
    using System;
    using System.Runtime.Serialization;
    using Marshal = System.Runtime.InteropServices.Marshal;

    /// <summary>
    /// The Timer Network Packet is the primary packet responsible for transmitting data across The Live Timer network.
    /// </summary>
    [Serializable]
    public class TimerNetworkPacket : ISerializable
    {
        /*
        /// <summary>
        /// The index of the packet identifier in the network packet byte array.
        /// </summary>
        public const int PacketIdIndex = 0;

        /// <summary>
        /// The index of the data size in the network packet byte array
        /// </summary>
        public const int DataSizeIndex = PacketIdIndex + 8;

        /// <summary>
        /// The index of where the data starts in the network packet byte array.
        /// </summary>
        public const int DataIndex = DataSizeIndex + 8;
        */

        public TimerNetworkPacket(Int64 packetId, NetworkData data)
        {
            this.PacketId = packetId;
            this.NetworkData = data;
        }

        protected TimerNetworkPacket(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));

            this.PacketId = info.GetInt64(nameof(PacketId));

            Type dataType = (Type)info.GetValue("DataType", typeof(Type));
            this.NetworkData = info.GetValue(nameof(NetworkData), dataType) as NetworkData;
        }

        /// <summary>
        /// The packet id for this network packet
        /// </summary>
        public Int64 PacketId { get; private set; }

        public NetworkData NetworkData { get; private set; }

        /// <summary>
        /// Converts the byte array into a <see cref="TimerNetworkPacket"/>
        /// </summary>
        /// <returns>A <see cref="TimerNetworkPacket"/></returns>
        /// <param name="data">A byte array</param>
        /*public static TimerNetworkPacket FromBytes(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            var packIdBytes = new byte[sizeof(Int64)];
            var networkDataSizeBytes = new byte[sizeof(Int64)];

            Buffer.BlockCopy(data, PacketIdIndex, packIdBytes, 0, packIdBytes.Length);
            Int64 packetId = BitConverter.ToInt64(packIdBytes, 0);

            Buffer.BlockCopy(data, DataSizeIndex, networkDataSizeBytes, 0, networkDataSizeBytes.Length);
            Int64 networkDataSize = BitConverter.ToInt64(networkDataSizeBytes, 0);

            var networkDataBytes = new byte[networkDataSize];
            Buffer.BlockCopy(data, DataIndex, networkDataBytes, 0, networkDataBytes.Length);
            NetworkData networkData = NetworkData.FromBytes(networkDataBytes);

            return new TimerNetworkPacket(packetId, networkData);
        }*/

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
        /*public byte[] ToByteArray()
        {
            int networkDataSize = Marshal.SizeOf(this.NetworkData);
            int dataLength = 2 * sizeof(Int64) + sizeof(Int64) + networkDataSize;
            var data = new byte[dataLength];

            // Transfer the packet ID
            var packIdBytes = BitConverter.GetBytes(this.PacketId);
            Buffer.BlockCopy(packIdBytes, 0, data, PacketIdIndex, packIdBytes.Length);

            // Transfer the size of the data
            var networkDataSizeBytes = BitConverter.GetBytes(networkDataSize);
            Buffer.BlockCopy(networkDataSizeBytes, 0, data, DataSizeIndex, networkDataSizeBytes.Length);

            // Transfer the data
            var databytes = NetworkUtils.ObjectToByteArray(this.NetworkData);
            Buffer.BlockCopy(databytes, 0, data, DataIndex, databytes.Length);

            return data;
        }*/

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));

            info.AddValue(nameof(PacketId), this.PacketId);
            info.AddValue(nameof(NetworkData), this.NetworkData);
            info.AddValue("DataType", this.NetworkData.GetType());
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));

            this.GetObjectData(info, context);
        }
    }
}
