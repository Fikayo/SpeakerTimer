using System;
namespace TheLiveTimer.Network
{
    public class NetworkPacketFactory
    {
        private volatile int totalPackets;
        private object _lock = new object();
        private static readonly NetworkPacketFactory instance = new NetworkPacketFactory();

        private NetworkPacketFactory() { }

        public static NetworkPacketFactory Instance
        {
            get { return instance; }
        }

        public int TotalPackets
        {
            get { return this.totalPackets; }

            set
            {
                lock (this._lock)
                {
                    this.totalPackets = value;
                }
            }
        }

        public TimerNetworkPacket GetNetworkPacket(NetworkData data)
        {
            return new TimerNetworkPacket(++this.TotalPackets, data);
        }

    }
}
