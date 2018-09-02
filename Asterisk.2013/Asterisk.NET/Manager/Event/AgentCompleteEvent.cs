namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     An AgentCompleteEvent is triggered when at the end of a call if the caller was connected to an agent.<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_AgentComplete">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_AgentComplete</see>
    /// </summary>
    public class AgentCompleteEvent : AbstractAgentEvent
    {
        /// <summary>
        ///     Creates a new <see cref="AgentCompleteEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public AgentCompleteEvent(ManagerConnection source)
            : base(source)
        {
        }

        /// <summary>
        ///     Get/Set the amount of time the caller was on hold.
        /// </summary>
        public long HoldTime { get; set; }

        /// <summary>
        ///     Get/Set the amount of time the caller talked to the agent.
        /// </summary>
        public long TalkTime { get; set; }

        /// <summary>
        ///     Get/Set if the agent or the caller terminated the call.
        /// </summary>
        public string Reason { get; set; }
    }
}