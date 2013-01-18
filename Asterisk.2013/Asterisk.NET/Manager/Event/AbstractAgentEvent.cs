namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// Abstract base class for several agent related events.
	/// </summary>
	public abstract class AbstractAgentEvent : AbstractAgentVariables
	{
		private string queue;
		private string member;
		private string memberName;

		/// <summary>
		/// Get/Set the name of the queue.
		/// </summary>
		public string Queue
		{
			get { return queue; }
			set { this.queue = value; }
		}
		/// <summary>
		/// Get/Set the name of the member's interface.
		/// </summary>
		public string Member
		{
			get { return member; }
			set { this.member = value; }
		}

		/// <summary>
		/// Get/Set the name of the member's interface.
		/// </summary>
		public string MemberName
		{
			get { return memberName; }
			set { this.memberName = value; }
		}

		public AbstractAgentEvent(ManagerConnection source)
			: base(source)
		{ }
	}
}