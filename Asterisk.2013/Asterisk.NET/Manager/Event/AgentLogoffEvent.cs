namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     An AgentCallbackLogoffEvent is triggered when an agent that previously logged in using AgentLogin is logged of.<br/>
    ///     It is implemented in channels/chan_agent.c<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_AgentLogoff">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_AgentLogoff</see>
    /// </summary>
    /// <seealso cref="Manager.Event.AgentLoginEvent" />
    public class AgentLogoffEvent : ManagerEvent
    {
        /// <summary>
        ///     Creates a new <see cref="AgentLogoffEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public AgentLogoffEvent(ManagerConnection source)
            : base(source)
        {
        }

        /// <summary>
        ///     Get/Set the name of the agent that logged off.
        /// </summary>
        public string Agent { get; set; }

        /// <summary>
        ///     Gets or sets the login time.
        /// </summary>
        public string LoginTime { get; set; }
    }
}