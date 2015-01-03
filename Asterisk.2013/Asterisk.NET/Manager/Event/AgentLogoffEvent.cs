namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     An AgentCallbackLogoffEvent is triggered when an agent that previously logged in using AgentLogin is logged of.
    ///     <br />
    ///     It is implemented in <code>channels/chan_agent.c</code>
    /// </summary>
    /// <seealso cref="Manager.event.AgentLoginEvent" />
    public class AgentLogoffEvent : ManagerEvent
    {
        public AgentLogoffEvent(ManagerConnection source)
            : base(source)
        {
        }

        /// <summary>
        ///     Get/Set the name of the agent that logged off.
        /// </summary>
        public string Agent { get; set; }

        public string LoginTime { get; set; }
    }
}