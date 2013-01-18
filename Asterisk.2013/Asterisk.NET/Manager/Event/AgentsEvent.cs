namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// An AgentsEvent is triggered for each agent in response to an AgentsAction.<br/>
	/// Available since Asterisk 1.2
	/// </summary>
	/// <seealso cref="Manager.Action.AgentsAction" />
	public class AgentsEvent : ResponseEvent
	{
		private string agent;
		private string name;
		private string status;
		private string loggedInChan;
		private string talkingTo;
		private long loggedInTime;

		/// <summary>
		/// Get/Set the agentid.
		/// </summary>
		public string Agent
		{
			get { return this.agent; }
			set { this.agent = value; }
		}
		/// <summary>
		/// Get/Set the name of this agent.
		/// </summary>
		public string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}
		/// <summary>
		/// Get/Set the status of this agent.<br/>
		/// This is one of
		/// <dl>
		/// <dt>"AGENT_LOGGEDOFF"</dt>
		/// <dd>Agent isn't logged in</dd>
		/// <dt>"AGENT_IDLE"</dt>
		/// <dd>Agent is logged in, and waiting for call</dd>
		/// <dt>"AGENT_ONCALL"</dt>
		/// <dd>Agent is logged in, and on a call</dd>
		/// <dt>"AGENT_UNKNOWN"</dt>
		/// <dd>Don't know anything about agent. Shouldn't ever get this.</dd>
		/// </dl>
		/// </summary>
		public string Status
		{
			get { return this.status; }
			set { this.status = value; }
		}
		/// <summary>
		/// Get/Set the name of channel this agent logged in from or "n/a" if the agent is not logged in.
		/// </summary>
		public string LoggedInChan
		{
			get { return this.loggedInChan; }
			set { this.loggedInChan = value; }
		}
		/// <summary>
		/// Get/Set the time (in seconds since 01/01/1970) when the agent logged in or 0 if the user is not logged.
		/// </summary>
		public long LoggedInTime
		{
			get { return this.loggedInTime; }
			set { this.loggedInTime = value; }
		}
		/// <summary>
		/// Get/Set the numerical Caller*ID of the channel this agent is talking toor "n/a" if this agent is talking to nobody.
		/// </summary>
		public string TalkingTo
		{
			get { return this.talkingTo; }
			set { this.talkingTo = value; }
		}

		public AgentsEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}