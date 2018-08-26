namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     An AgentCallbackLogoffEvent is triggered when an agent that previously logged in using
    ///     AgentCallbackLogin is logged of.<br />
    ///     It is implemented in channels/chan_agent.c
    /// </summary>
    /// <seealso cref="Manager.Event.AgentCallbackLoginEvent" />
    public class AgentCallbackLogoffEvent : ManagerEvent
    {
        #region Agent

        /// <summary> Returns the name of the agent that logged off.</summary>
        /// <summary> Sets the name of the agent that logged off.</summary>
        public string Agent { get; set; }

        #endregion

        #region LoginChan

        /// <summary>
        /// Gets or sets the login channel.
        /// </summary>
        public string LoginChan { get; set; }

        #endregion

        #region LoginTime

        /// <summary>
        /// Gets or sets the login time.
        /// </summary>
        public string LoginTime { get; set; }

        #endregion

        #region Reason

        /// <summary>
        ///     Returns the reason for the logoff. The reason is set to Autologoff if the agent has been
        ///     logged off due to not answering the phone in time. Autologoff is configured by setting
        ///     autologoff to the appropriate number of seconds in agents.conf.
        /// </summary>
        /// <summary>Sets the reason for the logoff.</summary>
        public string Reason { get; set; }

        #endregion

        /// <summary>
        ///     Creates a new <see cref="AgentCallbackLogoffEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        /// <param name="source">ManagerConnection passed through in the event.</param>
        public AgentCallbackLogoffEvent(ManagerConnection source)
            : base(source)
        {
        }
    }
}