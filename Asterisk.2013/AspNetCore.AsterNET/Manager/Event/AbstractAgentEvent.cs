namespace AspNetCore.AsterNET.Manager.Event
{
    /// <summary>
    ///     Abstract base class for several agent related events.
    /// </summary>
    public abstract class AbstractAgentEvent : AbstractAgentVariables
    {
        public AbstractAgentEvent(ManagerConnection source)
            : base(source)
        {
        }

        /// <summary>
        ///     Get/Set the name of the queue.
        /// </summary>
        public string Queue { get; set; }

        /// <summary>
        ///     Get/Set the name of the member's interface.
        /// </summary>
        public string Member { get; set; }

        /// <summary>
        ///     Get/Set the name of the member's interface.
        /// </summary>
        public string MemberName { get; set; }
    }
}