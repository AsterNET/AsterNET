namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     The AgentLogoffAction sets an agent as no longer logged in.
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_AgentLogoff">Asterisk Documentation</see>
    /// </summary>
    public class AgentLogoffAction : ManagerAction
    {
        #region Action 

        /// <summary>
        ///     Returns the name of this action, i.e. "AgentLogoff".
        /// </summary>
        /// <returns>the name of this action</returns>
        public override string Action
        {
            get { return "AgentLogoff"; }
        }

        #endregion

        #region Agent 

        /// <summary>
        ///     Returns the name of the agent to log off, for example "1002".
        /// </summary>
        /// <returns>the name of the agent to log off</returns>
        /// <summary>
        ///     Sets the name of the agent to log off, for example "1002".<br />
        ///     This is property is mandatory.
        /// </summary>
        /// <param name="agent">the name of the agent to log off</param>
        public string Agent { get; set; }

        #endregion

        #region Soft 

        /// <summary>
        ///     Get/Set whether to hangup existing calls or not.<br />
        ///     Default is to hangup existing calls on logoff.
        /// </summary>
        /// <returns>
        ///     true if existing calls should not be hung up, false otherwise.<br />
        ///     null if default should be used.
        /// </returns>
        public bool Soft { get; set; }

        #endregion

        #region Constructors - AgentLogoffAction() 

        /// <summary> Creates a new empty AgentLogoffAction.</summary>
        public AgentLogoffAction()
        {
        }

        /// <summary>
        ///     Creates a new AgentLogoffAction that logs off the given agent
        /// </summary>
        /// <param name="agent">the name of the agent to log off.</param>
        public AgentLogoffAction(string agent)
        {
            Agent = agent;
        }

        #endregion

        #region Constructors - AgentLogoffAction(string agent, bool soft) 

        /// <summary>
        ///     Creates a new AgentLogoffAction that logs off the given agent
        /// </summary>
        /// <param name="agent">the name of the agent to log off.</param>
        /// <param name="soft">true if exisiting calls should not be hung up on logout.</param>
        public AgentLogoffAction(string agent, bool soft)
            : this(agent)
        {
            Soft = soft;
        }

        #endregion
    }
}