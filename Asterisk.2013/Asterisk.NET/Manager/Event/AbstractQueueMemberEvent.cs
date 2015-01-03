namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     Abstract base class for several queue member related events.
    /// </summary>
    public abstract class AbstractQueueMemberEvent : ManagerEvent
    {
        public AbstractQueueMemberEvent(ManagerConnection source)
            : base(source)
        {
        }

        /// <summary>
        ///     Returns the name of the queue.
        /// </summary>
        public string Queue { get; set; }

        /// <summary>
        ///     Returns the name of the member's interface.<br />
        ///     E.g. the channel name or agent group.
        /// </summary>
        public string Location { get; set; }
    }
}