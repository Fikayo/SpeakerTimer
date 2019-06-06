namespace TheLiveTimer.Server.Network
{
    using System;
    using TheLiveTimer.Network;

    public class CommandDataFactory
    {
        private long commId;
        private Random random = new Random();
        private object _lock = new object();

        private static readonly CommandDataFactory instance = new CommandDataFactory();

        private CommandDataFactory() { }

        public static CommandDataFactory Instance
        {
            get { return instance; }
        }

        public long CommunicationId
        {
            get { return this.commId; }

            set
            {
                lock (this._lock)
                {
                    this.commId = value;
                }
            }
        }

        public TimerCommandData GetCommandData(TimerCommand command, byte[] args)
        {
            return new TimerCommandData(this.CommunicationId, command, args);
        }

        public long NextCommunicationId()
        {
            var id = random.Next() * 17;

            return (this.CommunicationId = id);
        }
    }
}
