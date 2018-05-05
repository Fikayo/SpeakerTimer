namespace TheLiveTimer.Network
{
    using System;
    using System.Net.Sockets;

    public interface ITransmitter : IDisposable
    {
        void Send(TcpClient client, byte[] data);

        void Broadcast(byte[] data);
    }

    public interface ITransmitterAsync : IDisposable
    {
        void SendAsync(TcpClient client, byte[] data);

        void BroadcastAsync(byte[] data);
    }
}
