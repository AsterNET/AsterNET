namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// An AgentCompleteEvent is triggered when at the end of a call if the caller was connected to an agent.
	/// </summary>
	public class AgentCompleteEvent : AbstractAgentEvent
	{
		private long holdTime;
		private string reason;
		private long talkTime;

		/// <summary>
		/// Get/Set the amount of time the caller was on hold.
		/// </summary>
		public long HoldTime
		{
			get { return holdTime; }
			set { this.holdTime = value; }
		}
		/// <summary>
		/// Get/Set the amount of time the caller talked to the agent.
		/// </summary>
		public long TalkTime
		{
			get { return talkTime; }
			set { this.talkTime = value; }
		}
		/// <summary>
		/// Get/Set if the agent or the caller terminated the call.
		/// </summary>
		public string Reason
		{
			get { return reason; }
			set { this.reason = value; }
		}
		
		public AgentCompleteEvent(ManagerConnection source)
			: base(source)
		{ }
	}
}