namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// An AgentConnectEvent is triggered when a caller is connected to an agent.
	/// </summary>
	public class AgentConnectEvent : AbstractAgentEvent
	{
		private string bridgedChannel;
		private long holdTime;
		private long ringTime;

		/// <summary>
		/// Get/Set the amount of time the caller was on hold.
		/// </summary>
		public long HoldTime
		{
			get { return holdTime; }
			set { this.holdTime = value; }
		}

		/// <summary>
		/// Get/Set bridged channel.
		/// </summary>
		public string BridgedChannel
		{
			get { return this.bridgedChannel; }
			set { this.bridgedChannel = value; }
		}

		/// <summary>
		/// Get/Set the amount of time the caller was on ring.
		/// </summary>
		public long RingTime
		{
			get { return ringTime; }
			set { this.ringTime = value; }
		}

		public AgentConnectEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}