namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     An AgentLoginEvent is triggered when an agent is successfully logged in using AgentLogin.<br />
    ///     It is implemented in channels/chan_agent.c
    /// </summary>
    /// <seealso cref="Manager.Event.AgentLogoffEvent" />
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