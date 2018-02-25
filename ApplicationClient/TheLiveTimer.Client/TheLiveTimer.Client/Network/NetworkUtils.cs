namespace TheLiveTimer.Client.Network
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    public static class NetworkUtils
    {
        public static byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
    }
}
