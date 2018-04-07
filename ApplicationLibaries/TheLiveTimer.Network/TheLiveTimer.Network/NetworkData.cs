namespace TheLiveTimer.Network
{
    using System;
    using System.Reflection;
    using System.Runtime.Serialization;

    [Serializable]
    public abstract class NetworkData : ISerializable
    {
        /*
        /// <summary>
        /// The index of the data type in the byte array.
        /// </summary>
        private const int DataTypeIndex = 4;

        /// <summary>
        /// Gets the index of the data in the byte array of this NetworkData Object
        /// </summary>
        /// <value>The index of the data.</value>
        protected int DataIndex { get; private set; }

        /// <summary>
        /// Gets the length of the data in bytes
        /// </summary>
        /// <value>The length of the data.</value>
        public abstract int DataLength { get; }

        public static NetworkData FromBytes(byte[] bytes)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));

            // First, let's find out where the data starts from
            var dataIndexBytes = new byte[sizeof(Int32)];
            Buffer.BlockCopy(bytes, 0, dataIndexBytes, 0, dataIndexBytes.Length);
            Int32 dataIndex = BitConverter.ToInt32(dataIndexBytes, 0);

            // Now we can grab the data type
            var dataTypeLength = dataIndex - dataIndexBytes.Length;
            var dataTypeBytes = new byte[dataTypeLength];
            Buffer.BlockCopy(bytes, DataTypeIndex, dataTypeBytes, 0, dataTypeBytes.Length);
            var dataType = BitConverter.ToString(dataTypeBytes);

            // Now we have the data type, let's construct the NetworkData type
            Type type = Type.GetType(dataType);
            var methodInfo = type.GetMethod("FromBytes", BindingFlags.NonPublic);
            if (methodInfo == null)
            {
                throw new Exception("Can't find 'FromBytes' function");
            }

            return methodInfo.Invoke(null, new object[] { bytes, dataIndex }) as NetworkData;
        }

        public byte[] ToByteArray()
        {
            var networkDataType = this.GetType().ToString();
            var typeBytes = NetworkUtils.ObjectToByteArray(networkDataType);
            var totalLengthOfData = this.DataLength + typeBytes.Length + sizeof(Int32);

            var data = new byte[totalLengthOfData];

            // First, set the data index to be after the data type + data index
            this.DataIndex = typeBytes.Length + sizeof(Int32);

            // Now, this is the first thing into the data array
            var dataIndexBytes = BitConverter.GetBytes(this.DataIndex);
            Buffer.BlockCopy(dataIndexBytes, 0, data, 0, dataIndexBytes.Length);

            // Now, add the data type to the byte array
            Buffer.BlockCopy(typeBytes, 0, data, DataTypeIndex, typeBytes.Length);

            // Now, have the child class fill up the rest of the data
            return GetBytes(data, this.DataIndex);
        }

        protected abstract byte[] GetBytes(byte[] data, int startIdx);
        */

        protected abstract void GetObjectData(SerializationInfo info, StreamingContext context);

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            info.AddValue("DataType", this.GetType());
            this.GetObjectData(info, context);
        }


    }
}
