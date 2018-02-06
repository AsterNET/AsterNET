namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     An AgentsEvent is triggered for each agent in response to an AgentsAction.<br />
    ///     Available since Asterisk 1.2
    /// </summary>
    /// <seealso cref="Manager.Action.AgentsAction" />
    public class AgentsEvent : ResponseEvent
    {
        public AgentsEvent(ManagerConnection source)
            : base(source)
        {
        }

        /// <summary>
        ///     Get/Set the agentid.
        /// </summary>
        public string Agent { get; set; }

        /// <summary>
        ///     Get/Set the name of this agent.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Get/Set the status of this agent.<br />
        ///     This is one of
        ///     <dl>
        ///         <dt>"AGENT_LOGGEDOFF"</dt>
        ///         <dd>Agent isn't logged in</dd>
        ///         <dt>"AGENT_IDLE"</dt>
        ///         <dd>Agent is logged in, and waiting for call</dd>
        ///         <dt>"AGENT_ONCALL"</dt>
        ///         <dd>Agent is logged in, and on a call</dd>
        ///         <dt>"AGENT_UNKNOWN"</dt>
        ///         <dd>Don't know anything about agent. Shouldn't ever get this.</dd>
        ///     </dl>
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        ///     Get/Set the name of channel this agent logged in from or "n/a" if the agent is not logged in.<br />
        ///     Removed on Asterisk 12 app_agent_pool.so module. Use Channel instead.
        /// </summary>
        public string LoggedInChan { get; set; }

        /// <summary>
        ///     Get/Set the numerical Caller*ID of the channel this agent is talking toor "n/a" if this agent is talking to nobody.<br />
        ///     Removed on Asterisk 12 app_agent_pool.so module. Use TalkingToChan instead.
        /// </summary>
        public string TalkingTo { get; set; }

        /// <summary>
        ///     Get/Set BRIDGEPEER value on agent channel.<br />
        ///     Present if Status value is AGENT_ONCALL.
        /// </summary>
        public string TalkingToChan { get; set; }

        /// <summary>
        ///     Get/Set Epoche time when the agent started talking with the caller.<br />
        ///     Present if Status value is AGENT_ONCALL.
        /// </summary>
        public string CallStarted { get; set; }

        /// <summary>
        ///     Get/Set the time (in seconds since 01/01/1970).<br />
        ///     Present if Status value is AGENT_IDLE or AGENT_ONCALL.
        /// </summary>
        public long LoggedInTime { get; set; }

        /// <summary>
        ///     Get/Set a numeric code for the channel's current state, related to ChannelStateDesc.
        /// </summary>
        public int ChannelState { get; set; }

        /// <summary>
        ///     Get/Set a description for the channel's current state.<br />
        ///     This is one of
        ///     <dl>
        ///         <dt>Down</dt>
        ///         <dt>Rsrvd</dt>
        ///         <dt>OffHook</dt>
        ///         <dt>Dialing</dt>
        ///         <dt>Ring</dt>
        ///         <dt>Ringing</dt>
        ///         <dt>Up</dt>
        ///         <dt>Busy</dt>
        ///         <dt>Dialing Offhook</dt>
        ///         <dt>Pre-ring</dt>
        ///         <dt>Unknown</dt>
        ///     </dl>
        /// </summary>
        public string ChannelStateDesc { get; set; }

        /// <summary>
        ///     Get/Set the callerID number.
        /// </summary>
        public string CallerIDNum { get; set; }

        /// <summary>
        ///     Get/Set the callerID name.
        /// </summary>
        public string CallerIDName { get; set; }

        /// <summary>
        ///     Get/Set the connected line number.
        /// </summary>
        public string ConnectedLineNum { get; set; }

        /// <summary>
        ///     Get/Set the connected line name.
        /// </summary>
        public string ConnectedLineName { get; set; }

        /// <summary>
        ///     Get/Set the account codee.
        /// </summary>
        public string AccountCode { get; set; }

        /// <summary>
        ///     Get/Set the context.
        /// </summary>
        public string Context { get; set; }

        /// <summary>
        ///     Get/Set the extension.
        /// </summary>
        public string Exten { get; set; }

        /// <summary>
        ///     Get/Set the agent priority.
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        ///     Get/Set the uniqueid of the oldest channel associated with this channel.
        /// </summary>
        public int Linkedid { get; set; }
    }
}