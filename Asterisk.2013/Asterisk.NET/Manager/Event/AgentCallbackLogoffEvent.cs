namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// An AgentCallbackLogoffEvent is triggered when an agent that previously logged in using
	/// AgentCallbackLogin is logged of.<br/>
	/// It is implemented in <code>channels/chan_agent.c</code>
	/// </summary>
	/// <seealso cref="Manager.event.AgentCallbackLoginEvent" />
	public class AgentCallbackLogoffEvent : ManagerEvent
	{
		private string agent;
		private string loginChan;
		private string loginTime;
		private string reason;

		#region Agent
		/// <summary> Returns the name of the agent that logged off.</summary>
		/// <summary> Sets the name of the agent that logged off.</summary>
		public string Agent
		{
			get
			{
				return agent;
			}
			
			set
			{
				this.agent = value;
			}

		}
		#endregion

		#region LoginChan
		public string LoginChan
		{
			get
			{
				return loginChan;
			}
			
			set
			{
				this.loginChan = value;
			}

		}
		#endregion

		#region LoginTime
		public string LoginTime
		{
			get
			{
				return loginTime;
			}
			
			set
			{
				this.loginTime = value;
			}

		}
		#endregion

		#region Reason
		/// <summary>
		/// Returns the reason for the logoff. The reason is set to Autologoff if the agent has been
		/// logged off due to not answering the phone in time. Autologoff is configured by setting
		/// <code>autologoff</code> to the appropriate number of seconds in <code>agents.conf</code>.
		/// </summary>
		/// <summary>Sets the reason for the logoff.</summary>
		public string Reason
		{
			get
			{
				return reason;
			}
			
			set
			{
				this.reason = value;
			}

		}
		#endregion

		public AgentCallbackLogoffEvent(ManagerConnection source)
			: base(source)
		{ }
	}
}