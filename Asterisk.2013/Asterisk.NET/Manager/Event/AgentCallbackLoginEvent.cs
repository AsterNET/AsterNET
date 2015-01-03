namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     An AgentCallbackLoginEvent is triggered when an agent is successfully logged in using AgentCallbackLogin.<br />
    ///     It is implemented in <code>channels/chan_agent.c</code>
    /// </summary>
    /// <seealso cref="Manager.event.AgentCallbackLogoffEvent" />
    public class AgentCallbackLoginEvent : ManagerEvent
    {
        public AgentCallbackLoginEvent(ManagerConnection source)
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