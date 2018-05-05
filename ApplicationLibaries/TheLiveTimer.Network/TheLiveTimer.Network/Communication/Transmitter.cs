namespace TheLiveTimer.Network
{
    using System.Net.Sockets;

    public class Transmitter : ITransmitterAsync
    {
        private readonly BroadcastServer broadcaster;

        public Transmitter(int sendPort)
        {
            this.broadcaster = new BroadcastServer(sendPort);
        }

        public void SendAsync(TcpClient client, byte[] data)
        {
            using (NetworkStream stream = client.GetStream())
            {
                stream.Write(data, 0, data.Length);
            }
        }

        public void BroadcastAsync(byte[] data)
        {
            this.broadcaster.SendAsync(data);
        }

        public void Dispose()
        {
            this.broadcaster.Dispose();
        }
    }
}
