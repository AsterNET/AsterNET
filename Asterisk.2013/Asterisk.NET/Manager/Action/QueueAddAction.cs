using System;

namespace Asterisk.NET.Manager.Action
{
	/// <summary>
	/// The QueueAddAction adds a new member to a queue.<br/>
	/// It is implemented in <code>apps/app_queue.c</code>
	/// </summary>
	public class QueueAddAction : ManagerAction
	{
		private string queue;
		private string iface;
		private string memberName;
		private int penalty;
		private bool paused;

		/// <summary>
		/// Get the name of this action, i.e. "QueueAdd".
		/// </summary>
		override public string Action
		{
			get { return "QueueAdd"; }
		}
		/// <summary>
		/// Get/Set the name of the queue the new member will be added to.<br/>
		/// This property is mandatory.
		/// </summary>
		public string Queue
		{
			get { return this.queue; }
			set { this.queue = value; }
		}
		/// <summary>
		/// Get/Set the interface to add. To add a specific channel just use the channel name, e.g. "SIP/1234".<br/>
		/// This property is mandatory.
		/// </summary>
		public string Interface
		{
			get { return this.iface; }
			set { this.iface = value; }
		}
		/// <summary>
		/// Get/Set the member to add.
		/// </summary>
		public string MemberName
		{
			get { return this.memberName; }
			set { this.memberName = value; }
		}
		/// <summary>
		/// Get/Set the penalty for this member.<br/>
		/// The penalty must be a positive integer or 0 for no penalty. If it is not set 0 is assumed.<br/>
		/// When calls are distributed members with higher penalties are considered last.
		/// </summary>
		public int Penalty
		{
			get { return this.penalty; }
			set { this.penalty = value; }
		}
		/// <summary>
		/// Get/Set if the queue member should be paused when added.<br/>
		/// <code>true</code> if the queue member should be paused when added.
		/// </summary>
		public bool Paused
		{
			get { return this.paused; }
			set { this.paused = value; }
		}
		
		/// <summary>
		/// Creates a new empty QueueAddAction.
		/// </summary>
		public QueueAddAction()
		{
		}
		
		/// <summary>
		/// Creates a new QueueAddAction that adds a new member on the given interface to the given queue.
		/// </summary>
		/// <param name="queue">the name of the queue the new member will be added to</param>
		/// <param name="iface">Sets the interface to add. To add a specific channel just use the channel name, e.g. "SIP/1234".</param>
		public QueueAddAction(string queue, string iface)
		{
			this.queue = queue;
			this.iface = iface;
		}
		
		/// <summary>
		/// Creates a new QueueAddAction that adds a new member on the given interface to the given queue.
		/// </summary>
		/// <param name="queue">the name of the queue the new member will be added to</param>
		/// <param name="iface">Sets the interface to add. To add a specific channel just use the channel name, e.g. "SIP/1234".</param>
		/// <param name="memberName">the name of the the new member will be added to</param>
		public QueueAddAction(string queue, string iface, string memberName)
		{
			this.queue = queue;
			this.iface = iface;
			this.memberName = memberName;
		}

		/// <summary>
		/// Creates a new QueueAddAction that adds a new member on the given
		/// interface to the given queue with the given penalty.
		/// </summary>
		/// <param name="queue">the name of the queue the new member will be added to</param>
		/// <param name="iface">Sets the interface to add. To add a specific channel just use the channel name, e.g. "SIP/1234".</param>
		/// <param name="memberName">the name of the the new member will be added to</param>
		/// <param name="penalty">the penalty for this member.<br/>
		/// The penalty must be a positive integer or 0 for no penalty. When calls are
		/// distributed members with higher penalties are considered last.
		/// </param>
		public QueueAddAction(string queue, string iface, string memberName, int penalty)
		{
			this.queue = queue;
			this.iface = iface;
			this.memberName = memberName;
			this.penalty = penalty;
		}
	}
}