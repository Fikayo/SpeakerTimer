namespace TheLiveTimer.Server.Network
{
    public interface INetworkServer
    {
        void Open();
    }

    public interface INetworkAsyncServer
    {
        void OpenAsync();
    }
}
