namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     An AgentConnectEvent is triggered when a caller is connected to an agent.<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_AgentConnect">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_AgentConnect</see>
    /// </summary>
    public class AgentConnectEvent : AbstractAgentEvent
    {
        /// <summary>
        ///     Creates a new <see cref="AgentConnectEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
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