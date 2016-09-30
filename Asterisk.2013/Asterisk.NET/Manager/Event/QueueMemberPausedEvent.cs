using System;

namespace AsterNET.Manager.Event
{
	/// <summary>
	/// A QueueMemberPausedEvent is triggered when a queue member is paused or unpaused.<br/>
	/// It is implemented in apps/app_queue.c.<br/>
	/// Available since Asterisk 1.2
	/// </summary>
    [Obsolete("Removed since Asterisk 13", false)]
	public class QueueMemberPausedEvent : AbstractQueueMemberEvent
	{
		private string memberName;
		private bool paused;
		private string reason;

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
		/// Get/Set if this queue member is paused (not accepting calls).<br/>
		/// true if this member has been paused or
		/// false if not.
		/// </summary>
		public bool Paused
		{
			get { return this.paused; }
			set { this.paused = value; }
		}

		public string Reason
		{
			get { return this.reason; }
			set { this.reason = value; }
		}
		public QueueMemberPausedEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}