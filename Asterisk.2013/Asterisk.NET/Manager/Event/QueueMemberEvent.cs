namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A QueueMemberEvent is triggered in response to a QueueStatusAction and contains information about a member of a queue.<br/>
	/// It is implemented in <code>apps/app_queue.c</code>
	/// </summary>
	/// <seealso cref="Manager.Action.QueueStatusAction" />
	public class QueueMemberEvent : ResponseEvent
	{
		private string queue;
		private string location;
		private string memberName;
		private string membership;
		private int penalty;
		private int callsTaken;
		private long lastCall;
		private int status;
		private bool paused;
		private string name;

		/// <summary>
		/// Get/Set the name of the queue member.
		/// </summary>
		public string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}

		/// <summary>
		/// Get/Set the name of the queue member.
		/// </summary>
		public string MemberName
		{
			get { return this.memberName; }
			set { this.memberName = value; }
		}

		/// <summary>
		/// Get/Set the name of the queue.
		/// </summary>
		public string Queue
		{
			get { return queue; }
			set { this.queue = value; }
		}
		/// <summary>
		/// Get/Set the name of the member's interface.<br/>
		/// E.g. the channel name or agent group.
		/// </summary>
		public string Location
		{
			get { return location; }
			set { this.location = value; }
		}
		/// <summary>
		/// Get/Set value if this member has been dynamically added by the QueueAdd command
		/// (in the dialplan or via the Manager API) or if this member is has been
		/// statically defined in <code>queues.conf</code>.
		/// "dynamic" if the added member is a dynamic queue member, "static" if the added member is a static queue member.
		/// </summary>
		public string Membership
		{
			get { return membership; }
			set { this.membership = value; }
		}
		/// <summary>
		/// Get/Set the penalty for the added member. When calls are distributed members with higher penalties are considered last.
		/// </summary>
		public int Penalty
		{
			get { return this.penalty; }
			set { this.penalty = value; }
		}
		/// <summary>
		/// Get/Set the number of calls answered by the member.
		/// </summary>
		public int CallsTaken
		{
			get { return this.callsTaken; }
			set { this.callsTaken = value; }
		}
		/// <summary>
		/// Get/Set the time (in seconds since 01/01/1970) the last successful call answered by the added member was hungup.
		/// </summary>
		public long LastCall
		{
			get { return this.lastCall; }
			set { this.lastCall = value; }
		}
		/// <summary>
		/// Get/Set the status of this queue member.<br/>
		/// Available since Asterisk 1.2<br/>
		/// Valid status codes are:
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
			get { return this.status; }
			set { this.status = value; }
		}
		/// <summary>
		/// Is this queue member paused (not accepting calls)?<br/>
		/// Available since Asterisk 1.2.<br/>
		/// <code>true</code> if this member has been paused,
		/// <code>false</code> if not
		public bool Paused
		{
			get { return this.paused; }
			set { this.paused = value; }
		}

		public QueueMemberEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}