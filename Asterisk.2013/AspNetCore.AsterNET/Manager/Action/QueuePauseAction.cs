namespace AspNetCore.AsterNET.Manager.Action
{
    /// <summary>
    ///     The QueuePauseAction makes a queue member temporarily unavailabe (or available again).<br />
    ///     It is implemented in apps/app_queue.c<br />
    ///     Available since Asterisk 1.2.
    /// </summary>
    public class QueuePauseAction : ManagerAction
    {
        /// <summary>
        ///     Creates a new empty QueuePauseAction.
        /// </summary>
        public QueuePauseAction()
        {
        }

        /// <summary>
        ///     Creates a new QueuePauseAction that makes the member on the given
        ///     interface unavailable on all queues.
        /// </summary>
        /// <param name="iface">the interface of the member to make unavailable</param>
        public QueuePauseAction(string iface)
        {
            this.Interface = iface;
            Paused = true;
        }

        /// <summary>
        ///     Creates a new QueuePauseAction that makes the member on the given
        ///     interface unavailable on the given queue.
        /// </summary>
        /// <param name="iface">the interface of the member to make unavailable</param>
        /// <param name="queue">the queue the member is made unvailable on</param>
        public QueuePauseAction(string iface, string queue)
        {
            this.Interface = iface;
            this.Queue = queue;
            Paused = true;
        }

        /// <summary>
        ///     Creates a new QueuePauseAction that makes the member on the given
        ///     interface available or unavailable on all queues.
        /// </summary>
        /// <param name="iface">the interface of the member to make unavailable</param>
        /// <param name="paused">true to make the member unavailbale, false to make the member available</param>
        public QueuePauseAction(string iface, bool paused)
        {
            this.Interface = iface;
            this.Paused = paused;
        }

        /// <summary>
        ///     Creates a new QueuePauseAction that makes the member on the given
        ///     interface unavailable on the given queue.
        /// </summary>
        /// <param name="iface">the interface of the member to make unavailable</param>
        /// <param name="queue">the queue the member is made unvailable on</param>
        /// <param name="paused">true to make the member unavailbale, false to make the member available</param>
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
        ///     Get/Set the interface of the member to make available or unavailable.<br />
        ///     This property is mandatory.
        /// </summary>
        public string Interface { get; set; }

        /// <summary>
        ///     Get/Set Returns the name of the queue the member is made available or unavailable on.
        /// </summary>
        public string Queue { get; set; }

        /// <summary>
        ///     Get/Set if the member is made available or unavailable.<br />
        ///     true to make the member unavailbale,<br />
        ///     false make the member available
        /// </summary>
        public bool Paused { get; set; }
    }
}