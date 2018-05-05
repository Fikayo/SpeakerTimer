namespace TheLiveTimer.Network
{
    public class ReceivedPacket
    {
        public ReceivedPacket(TimerNetworkPacket packet, NetworkAddress sender, bool hasError = false)
        {
            this.Packet = packet;
            this.Sender = sender;
            this.HasError = hasError;
        }

        public TimerNetworkPacket Packet { get; }

        public NetworkAddress Sender { get; }

        public bool HasError { get; }
    }
}
