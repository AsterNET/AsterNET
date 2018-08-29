namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     An AgentCallbackLogoffEvent is triggered when an agent that previously logged in using AgentLogin is logged of.
    ///     It is implemented in channels/chan_agent.c
    /// </summary>
    /// <seealso cref="Manager.Event.AgentLoginEvent" />
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