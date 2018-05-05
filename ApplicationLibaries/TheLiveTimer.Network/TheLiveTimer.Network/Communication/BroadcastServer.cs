namespace TheLiveTimer.Network
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;

    public class BroadcastServer : IDisposable
    {
        private IPEndPoint ip;
        private UdpClient udpClient;
        private Thread sendThread;

        public BroadcastServer(int port)
        {
            this.udpClient = new UdpClient();
            this.ip = new IPEndPoint(IPAddress.Broadcast, port);
        }

        public void SendAsync(byte[] data)
        {
            this.sendThread = new Thread(new ParameterizedThreadStart(this.Send));
            this.sendThread.Start(data);
        }

        public void Send(object data)
        {
            byte[] bytes = (byte[])data;
            this.udpClient.Send(bytes, bytes.Length, ip);
        }

        public void Dispose()
        {
            this.udpClient.Close();
        }
    }
}
