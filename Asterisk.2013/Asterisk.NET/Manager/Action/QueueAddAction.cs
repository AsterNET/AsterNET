namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     The QueueAddAction adds a new member to a queue.<br />
    ///     It is implemented in apps/app_queue.c
    /// </summary>
    public class QueueAddAction : ManagerAction
    {
        /// <summary>
        ///     Creates a new empty QueueAddAction.
        /// </summary>
        public QueueAddAction()
        {
        }

        /// <summary>
        ///     Creates a new QueueAddAction that adds a new member on the given interface to the given queue.
        /// </summary>
        /// <param name="queue">the name of the queue the new member will be added to</param>
        /// <param name="iface">Sets the interface to add. To add a specific channel just use the channel name, e.g. "SIP/1234".</param>
        public QueueAddAction(string queue, string iface)
        {
            this.Queue = queue;
            this.Interface = iface;
        }

        /// <summary>
        ///     Creates a new QueueAddAction that adds a new member on the given interface to the given queue.
        /// </summary>
        /// <param name="queue">the name of the queue the new member will be added to</param>
        /// <param name="iface">Sets the interface to add. To add a specific channel just use the channel name, e.g. "SIP/1234".</param>
        /// <param name="memberName">the name of the the new member will be added to</param>
        public QueueAddAction(string queue, string iface, string memberName)
        {
            this.Queue = queue;
            this.Interface = iface;
            this.MemberName = memberName;
        }

        /// <summary>
        ///     Creates a new QueueAddAction that adds a new member on the given
        ///     interface to the given queue with the given penalty.
        /// </summary>
        /// <param name="queue">the name of the queue the new member will be added to</param>
        /// <param name="iface">Sets the interface to add. To add a specific channel just use the channel name, e.g. "SIP/1234".</param>
        /// <param name="memberName">the name of the the new member will be added to</param>
        /// <param name="penalty">
        ///     the penalty for this member.<br />
        ///     The penalty must be a positive integer or 0 for no penalty. When calls are
        ///     distributed members with higher penalties are considered last.
        /// </param>
        public QueueAddAction(string queue, string iface, string memberName, int penalty)
        {
            this.Queue = queue;
            this.Interface = iface;
            this.MemberName = memberName;
            this.Penalty = penalty;
        }

        /// <summary>
        ///     Get the name of this action, i.e. "QueueAdd".
        /// </summary>
        public override string Action
        {
            get { return "QueueAdd"; }
        }

        /// <summary>
        ///     Get/Set the name of the queue the new member will be added to.<br />
        ///     This property is mandatory.
        /// </summary>
        public string Queue { get; set; }

        /// <summary>
        ///     Get/Set the interface to add. To add a specific channel just use the channel name, e.g. "SIP/1234".<br />
        ///     This property is mandatory.
        /// </summary>
        public string Interface { get; set; }

        /// <summary>
        ///     Get/Set the member to add.
        /// </summary>
        public string MemberName { get; set; }

        /// <summary>
        ///     Get/Set the penalty for this member.<br />
        ///     The penalty must be a positive integer or 0 for no penalty. If it is not set 0 is assumed.<br />
        ///     When calls are distributed members with higher penalties are considered last.
        /// </summary>
        public int Penalty { get; set; }

        /// <summary>
        ///     Get/Set if the queue member should be paused when added.<br />
        ///     true if the queue member should be paused when added.
        /// </summary>
        public bool Paused { get; set; }
    }
}