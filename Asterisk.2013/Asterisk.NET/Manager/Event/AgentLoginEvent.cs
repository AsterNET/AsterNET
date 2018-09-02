namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     An AgentLoginEvent is triggered when an agent is successfully logged in using AgentLogin.<br />
    ///     It is implemented in channels/chan_agent.c<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_AgentLogin">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_AgentLogin</see>
    /// </summary>
    /// <seealso cref="Manager.Event.AgentLogoffEvent" />
    public class AgentLoginEvent : ManagerEvent
    {
        /// <summary>
        ///     Creates a new <see cref="AgentLoginEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public AgentLoginEvent(ManagerConnection source)
            : base(source)
        {
        }

        /// <summary>
        ///     Get/Set the name of the agent that logged in.
        /// </summary>
        public string Agent { get; set; }

        /// <summary>
        ///     Get/Set the name of the login channel
        /// </summary>
        public string LoginChan { get; set; }
    }
}