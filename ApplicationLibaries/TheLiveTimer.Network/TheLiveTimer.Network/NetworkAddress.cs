namespace TheLiveTimer.Network
{
    using System;
    using System.Net;

    [Serializable]
    public class NetworkAddress
    {
        public NetworkAddress(IPAddress ip, int port)
        {
            this.IP = ip;
            this.Port = port;
        }

        public IPAddress IP { get; }

        public int Port { get; }

		public override int GetHashCode()
		{
            return base.GetHashCode() * 17;
		}

		public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is NetworkAddress)) return false;
            if (ReferenceEquals(this, obj)) return true;

            var address = obj as NetworkAddress;

            return this.IP.Equals(address.IP) && this.Port == address.Port;

        }

    }
}
