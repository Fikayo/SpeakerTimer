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
            //var id = random.Next() * 17;

            // Generate a new random long number. Current method allows duplicate comm ids on occasion -\_("/)_/-
            var id = LongRandom(100000000000000000, 100000000000000050, this.random);
            return (this.CommunicationId = id);
        }

        private long LongRandom(long min, long max, Random rand)
        {
            long result = rand.Next((Int32)(min >> 32), (Int32)(max >> 32));
            result = (result << 32);
            result = result | (long)rand.Next((Int32)min, (Int32)max);
            return result;
        }
    }
}
