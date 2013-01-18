namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A QueueMemberAddedEvent is triggered when a queue member is added to a queue.<br/>
	/// It is implemented in <code>apps/app_queue.c</code>.<br/>
	/// Available since Asterisk 1.2
	/// </summary>
	public class QueueMemberAddedEvent : AbstractQueueMemberEvent
	{
		private string memberName;
		private string membership;
		private int penalty;
		private int callsTaken;
		private long lastCall;
		private int status;
		private bool paused;

		/// <summary>
		/// Returns the name of the member's interface.<br/>
		/// E.g. the channel name or agent group.
		/// </summary>
		public string MemberName
		{
			get { return this.memberName; }
			set { this.memberName = value; }
		}

		/// <summary>
		/// Get/Set if the added member is a dynamic or static queue member.
		/// "dynamic" if the added member is a dynamic queue member,
		/// "static" if the added member is a static queue member.
		/// </summary>
		public string Membership
		{
			get { return membership; }
			set { this.membership = value; }
		}
		/// <summary>
		/// Get/Set the penalty for the added member. When calls are distributed
		/// members with higher penalties are considered last.
		/// </summary>
		public int Penalty
		{
			get { return penalty; }
			set { this.penalty = value; }
		}
		/// <summary>
		/// Get/Set the number of calls answered by the member.
		/// </summary>
		public int CallsTaken
		{
			get { return callsTaken; }
			set { this.callsTaken = value; }
		}
		/// <summary>
		/// Get/Set the time (in seconds since 01/01/1970) the last successful call answered by the added member was hungup.
		/// </summary>
		public long LastCall
		{
			get { return lastCall; }
			set { this.lastCall = value; }
		}
		/// <summary>
		/// Get/Set the status of this queue member.<br/>
		/// Valid status codes are:<br/>
		/// <dl>
		/// <dt>AST_DEVICE_UNKNOWN (0)</dt>
		/// <dd>Queue member is available</dd>
		/// <dt>AST_DEVICE_NOT_INUSE (1)</dt>
		/// <dd>?</dd>
		/// <dt>AST_DEVICE_INUSE (2)</dt>
		/// <dd>?</dd>
		/// <dt>AST_DEVICE_BUSY (3)</dt>
		/// <dd>?</dd>
		/// <dt>AST_DEVICE_INVALID (4)</dt>
		/// <dd>?</dd>
		/// <dt>AST_DEVICE_UNAVAILABLE (5)</dt>
		/// <dd>?</dd>
		/// </dl>
		/// </summary>
		public int Status
		{
			get { return status; }
			set { this.status = value; }
		}
		/// <summary>
		/// Get/Set value if this queue member is paused (not accepting calls).<br/>
		/// <code>true</code> if this member has been paused or <code>false</code> if not.
		/// </summary>
		public bool Paused
		{
			get { return paused; }
			set { this.paused = value; }
		}

		public QueueMemberAddedEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}