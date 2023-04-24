namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     A JitterBufStatsEvent is triggered at the end of IAX2 calls and reports jitter statistics.<br/>
    ///     It is implemented in <code>channels/chan_iax2.c</code>.<br/>
    ///     Available since Asterisk 1.6.
    /// </summary>
    public class JitterBufStatsEvent : ManagerEvent
    {
        /// <summary>
        ///     Creates a new <see cref="JitterBufStatsEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public JitterBufStatsEvent(ManagerConnection source)
            : base(source)
        {
        }

        /// <summary>
        ///     Gets or sets the owner.
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        ///     Gets or sets the ping.
        /// </summary>
        public int Ping { get; set; }

        /// <summary>
        ///     Gets or sets the local jitter.
        /// </summary>
        public int LocalJitter { get; set; }

        /// <summary>
        ///     Gets or sets the local jb delay.
        /// </summary>
        public int LocalJBDelay { get; set; }

        /// <summary>
        ///     Gets or sets the local total lost.
        /// </summary>
        public int LocalTotalLost { get; set; }

        /// <summary>
        ///     Gets or sets the local loss percent.
        /// </summary>
        public int LocalLossPercent { get; set; }

        /// <summary>
        ///     Gets or sets the local dropped.
        /// </summary>
        public int LocalDropped { get; set; }

        /// <summary>
        ///     Gets or sets the localooo.
        /// </summary>
        public int Localooo { get; set; }

        /// <summary>
        ///     Gets or sets the local received.
        /// </summary>
        public int LocalReceived { get; set; }

        /// <summary>
        ///     Gets or sets the remote jitter.
        /// </summary>
        public int RemoteJitter { get; set; }

        /// <summary>
        ///     Gets or sets the remote jb delay.
        /// </summary>
        public int RemoteJBDelay { get; set; }

        /// <summary>
        ///     Gets or sets the remote total lost.
        /// </summary>
        public int RemoteTotalLost { get; set; }

        /// <summary>
        ///     Gets or sets the remote loss percent.
        /// </summary>
        public int RemoteLossPercent { get; set; }

        /// <summary>
        ///     Gets or sets the remote dropped.
        /// </summary>
        public int RemoteDropped { get; set; }

        /// <summary>
        ///     Gets or sets the remoteooo.
        /// </summary>
        public int Remoteooo { get; set; }

        /// <summary>
        ///     Gets or sets the remote received.
        /// </summary>
        public int RemoteReceived { get; set; }
    }
}