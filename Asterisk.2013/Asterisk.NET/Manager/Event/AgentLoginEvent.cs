namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     An AgentLoginEvent is triggered when an agent is successfully logged in using AgentLogin.<br />
    ///     It is implemented in <code>channels/chan_agent.c</code>
    /// </summary>
    /// <seealso cref="Manager.event.AgentLogoffEvent" />
    public class AgentLoginEvent : ManagerEvent
    {
        public AgentLoginEvent(ManagerConnection source)
            : base(source)
        {
        }

        /// <summary>
        ///     Get/Set the name of the agent that logged in.
        /// </summary>
        public string Agent { get; set; }

        public string LoginChan { get; set; }
    }
}