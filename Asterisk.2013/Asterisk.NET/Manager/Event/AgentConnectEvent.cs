namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     An AgentConnectEvent is triggered when a caller is connected to an agent.
    /// </summary>
    public class AgentConnectEvent : AbstractAgentEvent
    {
        public AgentConnectEvent(ManagerConnection source)
            : base(source)
        {
        }

        /// <summary>
        ///     Get/Set the amount of time the caller was on hold.
        /// </summary>
        public long HoldTime { get; set; }

        /// <summary>
        ///     Get/Set bridged channel.
        /// </summary>
        public string BridgedChannel { get; set; }

        /// <summary>
        ///     Get/Set the amount of time the caller was on ring.
        /// </summary>
        public long RingTime { get; set; }
    }
}