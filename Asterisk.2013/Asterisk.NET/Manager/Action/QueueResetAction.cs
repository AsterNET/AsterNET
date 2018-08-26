namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     Reset queue statistics.
    /// </summary>
    public class QueueResetAction : ManagerAction
    {
        /// <summary>
        ///     Creates a new empty <see cref="QueueResetAction"/>.
        /// </summary>
        public QueueResetAction()
        {
        }

        /// <summary>
        ///     Creates a new <see cref="QueueResetAction"/> using the given queue.
        /// </summary>
        /// <param name="queue"></param>
        public QueueResetAction(string queue)
        {
            Queue = queue;
        }

        /// <summary>
        ///     Get the name of this action, i.e. "QueueReset".
        /// </summary>
        public override string Action
        {
            get { return "QueueReset"; }
        }

        /// <summary>
        /// Gets or sets the queue.
        /// </summary>
        public string Queue { get; set; }
    }
}