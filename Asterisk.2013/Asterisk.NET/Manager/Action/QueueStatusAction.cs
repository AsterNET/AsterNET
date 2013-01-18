using System;
namespace Asterisk.NET.Manager.Action
{
	/// <summary>
	/// The QueueStatusAction requests the state of all defined queues their members (agents) and entries (callers).<br/>
	/// For each queue a QueueParamsEvent is generated, followed by a
	/// QueueMemberEvent for each member of that queue and a QueueEntryEvent for each
	/// entry in the queue.<br/>
	/// Since Asterisk 1.2 a QueueStatusCompleteEvent is sent to denote the end of the generated dump.<br/>
	/// This action is implemented in <code>apps/app_queue.c</code>
	/// </summary>
	/// <seealso cref="Manager.event.QueueParamsEvent" />
	/// <seealso cref="Manager.event.QueueMemberEvent" />
	/// <seealso cref="Manager.event.QueueEntryEvent" />
	/// <seealso cref="Manager.event.QueueStatusCompleteEvent" />
	public class QueueStatusAction : ManagerActionEvent
	{
		private string queue;
		private string member;

		#region Action
		/// <summary>
		/// Get the name of this action, i.e. "QueueStatus".
		/// </summary>
		public override string Action
		{
			get { return "QueueStatus"; }
		}
		#endregion
		#region Queue
		/// <summary>
		/// Get/Set the queue filter.
		/// </summary>
		public string Queue
		{
			get { return queue; }
			set { this.queue = value; }
		}
		#endregion
		#region Member
		/// <summary>
		/// Get/Set the member filter.
		/// </summary>
		public string Member
		{
			get { return member; }
			set { this.member = value; }
		}
		#endregion

		#region ActionCompleteEventClass 
		public override Type ActionCompleteEventClass()
		{
			return typeof(Event.QueueStatusCompleteEvent);
		}
		#endregion

		#region QueueStatusAction()
		/// <summary> Creates a new QueueStatusAction.</summary>
		public QueueStatusAction()
		{
		}
		#endregion
	}
}