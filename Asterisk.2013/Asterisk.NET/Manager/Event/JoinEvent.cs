namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A JoinEvent is triggered when a channel joines a queue.<br/>
	/// It is implemented in <code>apps/app_queue.c</code>
	/// </summary>
	public class JoinEvent : QueueEvent
	{
		private string callerId;
		private string callerIdName;
		private int position;

		/// <summary>
		/// Get/Set the Caller*ID number of the channel that joined the queue if set.
		/// If the channel has no caller id set "unknown" is returned.
		/// </summary>
		public string CallerId
		{
			get { return callerId; }
			set { this.callerId = value; }
		}
		/// <summary>
		/// Get/Set the Caller*ID name of the channel that joined the queue if set.
		/// If the channel has no caller id set "unknown" is returned.
		/// </summary>
		public string CallerIdName
		{
			get { return callerIdName; }
			set { this.callerIdName = value; }
		}
		/// <summary>
		/// Get/Set the position of the joined channel in the queue.
		/// </summary>
		public int Position
		{
			get { return position; }
			set { this.position = value; }
		}
		
		public JoinEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}