namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     The QueuePauseAction makes a queue member temporarily unavailable (or available again).<br />
    ///     Available since Asterisk 1.2.
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_QueuePause">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_QueuePause</see>
    /// </summary>
    public class QueuePauseAction : ManagerAction
    {
        /// <summary>
        ///     Creates a new empty <see cref="QueuePauseAction"/>.
        /// </summary>
        public QueuePauseAction()
        {
        }

        /// <summary>
        ///     Creates a new <see cref="QueuePauseAction"/> that makes the member on the given
        ///     interface unavailable on all queues.
        /// </summary>
        /// <param name="iface">the interface of the member to make unavailable</param>
        public QueuePauseAction(string iface)
        {
            this.Interface = iface;
            Paused = true;
        }

        /// <summary>
        ///     Creates a new <see cref="QueuePauseAction"/> that makes the member on the given
        ///     interface unavailable on the given queue.
        /// </summary>
        /// <param name="iface">the interface of the member to make unavailable</param>
        /// <param name="queue">the queue the member is made unavailable on</param>
        public QueuePauseAction(string iface, string queue)
        {
            this.Interface = iface;
            this.Queue = queue;
            Paused = true;
        }

        /// <summary>
        ///     Creates a new <see cref="QueuePauseAction"/> that makes the member on the given
        ///     interface available or unavailable on all queues.
        /// </summary>
        /// <param name="iface">the interface of the member to make unavailable</param>
        /// <param name="paused">true to make the member unavailable, false to make the member available</param>
        public QueuePauseAction(string iface, bool paused)
        {
            this.Interface = iface;
            this.Paused = paused;
        }

        /// <summary>
        ///     Creates a new <see cref="QueuePauseAction"/> that makes the member on the given
        ///     interface unavailable on the given queue.
        /// </summary>
        /// <param name="iface">the interface of the member to make unavailable</param>
        /// <param name="queue">the queue the member is made unavailable on</param>
        /// <param name="paused">true to make the member unavailable, false to make the member available</param>
        public QueuePauseAction(string iface, string queue, bool paused)
        {
            this.Interface = iface;
            this.Queue = queue;
            this.Paused = paused;
        }

        /// <summary>
        ///     Get the name of this action, i.e. "QueuePause".
        /// </summary>
        public override string Action
        {
            get { return "QueuePause"; }
        }

        /// <summary>
        ///     The name of the interface (tech/name) to pause or unpause.<br />
        ///     This property is mandatory.
        /// </summary>
        public string Interface { get; set; }

        /// <summary>
        ///     The name of the queue in which to pause or unpause this member.<br />
        ///     If null, the member will be paused or unpaused in all the queues it is a member of.
        /// </summary>
        public string Queue { get; set; }

        /// <summary>
        ///     Pause or unpause the interface.<br />
        //      Set to 'true' to pause the member or 'false' to unpause.
        /// </summary>
        public bool Paused { get; set; }

        /// <summary>
        ///     Text description, returned in the event QueueMemberPaused.
        /// </summary>
        public string Reason { get; set; }
    }
}
