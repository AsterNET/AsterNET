namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     An AgentCallbackLogoffEvent is triggered when an agent that previously logged in using AgentCallbackLogin is logged of.<br />
    ///     It is implemented in channels/chan_agent.c
    /// </summary>
    /// <seealso cref="Manager.Event.AgentCallbackLoginEvent" />
    public class AgentCallbackLogoffEvent : ManagerEvent
    {
        #region Agent

        /// <summary> 
        ///     Gets or sets the name of the agent that logged off.
        /// </summary>
        public string Agent { get; set; }

        #endregion

        #region LoginChan

        /// <summary>
        ///     Gets or sets the login channel.
        /// </summary>
        public string LoginChan { get; set; }

        #endregion

        #region LoginTime

        /// <summary>
        ///     Gets or sets the login time.
        /// </summary>
        public string LoginTime { get; set; }

        #endregion

        #region Reason

        /// <summary>
        ///     Gets or sets the reason for the logoff.<br/>
        ///     The reason is set to Autologoff if the agent has been logged off due to not answering the phone in time.<br/>
        ///     Autologoff is configured by setting autologoff to the appropriate number of seconds in agents.conf.
        /// </summary>
        public string Reason { get; set; }

        #endregion

        /// <summary>
        ///     Creates a new <see cref="AgentCallbackLogoffEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        /// <param name="source"></param>
        public AgentCallbackLogoffEvent(ManagerConnection source)
            : base(source)
        {
        }
    }
}