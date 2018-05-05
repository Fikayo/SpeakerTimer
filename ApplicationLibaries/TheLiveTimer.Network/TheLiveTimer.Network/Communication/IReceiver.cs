namespace TheLiveTimer.Network
{
    using System;
    using System.Threading.Tasks;

    public interface IReceiverBase : IDisposable
    {
        bool IsListening { get; }
    }

    public interface IReceiver : IReceiverBase
    {
        void StartListening();
    }

    public interface IReceiverAsync : IReceiverBase
    {
        Task StartListeningAsync();
    }
}
