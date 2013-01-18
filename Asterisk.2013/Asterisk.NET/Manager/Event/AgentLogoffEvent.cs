namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// An AgentCallbackLogoffEvent is triggered when an agent that previously logged in using AgentLogin is logged of.<br/>
	/// It is implemented in <code>channels/chan_agent.c</code>
	/// </summary>
	/// <seealso cref="Manager.event.AgentLoginEvent" />
	public class AgentLogoffEvent : ManagerEvent
	{
		private string agent;
		private string loginTime;
		
		/// <summary>
		/// Get/Set the name of the agent that logged off.
		/// </summary>
		public string Agent
		{
			get { return agent; }
			set { this.agent = value; }
		}
		public string LoginTime
		{
			get { return loginTime; }
			set { this.loginTime = value; }
		}
		
		public AgentLogoffEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}