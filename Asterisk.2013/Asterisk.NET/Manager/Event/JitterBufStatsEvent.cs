namespace AsterNET.Manager.Event
{
    public class JitterBufStatsEvent : ManagerEvent
    {
        public JitterBufStatsEvent(ManagerConnection source)
            : base(source)
        {
        }

        public string Owner { get; set; }

        public int Ping { get; set; }

        public int LocalJitter { get; set; }

        public int LocalJBDelay { get; set; }

        public int LocalTotalLost { get; set; }

        public int LocalLossPercent { get; set; }

        public int LocalDropped { get; set; }

        public int Localooo { get; set; }

        public int LocalReceived { get; set; }

        public int RemoteJitter { get; set; }

        public int RemoteJBDelay { get; set; }

        public int RemoteTotalLost { get; set; }

        public int RemoteLossPercent { get; set; }

        public int RemoteDropped { get; set; }

        public int Remoteooo { get; set; }

        public int RemoteReceived { get; set; }
    }
}