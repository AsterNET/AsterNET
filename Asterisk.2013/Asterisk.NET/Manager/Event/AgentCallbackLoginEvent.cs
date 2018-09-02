namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     An AgentCallbackLoginEvent is triggered when an agent is successfully logged in using AgentCallbackLogin.<br />
    ///     It is implemented in channels/chan_agent.c
    /// </summary>
    /// <seealso cref="Manager.Event.AgentCallbackLogoffEvent" />
    public class AgentCallbackLoginEvent : ManagerEvent
    {
        /// <summary>
        ///     Creates a new <see cref="AsterNET.Manager.Event.AgentCallbackLoginEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public AgentCallbackLoginEvent(ManagerConnection source)
            : base(source)
        {
        }

        /// <summary>
        ///     Get/Set the name of the agent that logged in.
        /// </summary>
        public string Agent { get; set; }

        /// <summary>
        ///     Get/Set the channel to login.
        /// </summary>
        public string LoginChan { get; set; }
    }
}