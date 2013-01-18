using System;

namespace Asterisk.NET.Manager.Action
{
	/// <summary>
	/// The QueuePauseAction makes a queue member temporarily unavailabe (or available again).<br/>
	/// It is implemented in <code>apps/app_queue.c</code><br/>
	/// Available since Asterisk 1.2.
	/// </summary>
	public class QueuePauseAction : ManagerAction
	{
		private string iface;
		private bool paused;
		private string queue;

		/// <summary>
		/// Get the name of this action, i.e. "QueuePause".
		/// </summary>
		override public string Action
		{
			get
			{
				return "QueuePause";
			}
			
		}
		/// <summary>
		/// Get/Set the interface of the member to make available or unavailable.<br/>
		/// This property is mandatory.
		/// </summary>
		public string Interface
		{
			get { return this.iface; }
			set { this.iface = value; }
		}
		/// <summary>
		/// Get/Set Returns the name of the queue the member is made available or unavailable on.
		/// </summary>
		public string Queue
		{
			get { return this.queue; }
			set { this.queue = value; }
		}
		/// <summary>
		/// Get/Set if the member is made available or unavailable.<br/>
		/// <code>true</code> to make the member unavailbale,<br/>
		/// <code>false</code> make the member available
		/// </summary>
		public bool Paused
		{
			get { return this.paused; }
			set { this.paused = value; }
		}
		
		/// <summary>
		/// Creates a new empty QueuePauseAction.
		/// </summary>
		public QueuePauseAction()
		{
		}
		
		/// <summary>
		/// Creates a new QueuePauseAction that makes the member on the given
		/// interface unavailable on all queues.
		/// </summary>
		/// <param name="iface">the interface of the member to make unavailable</param>
		public QueuePauseAction(string iface)
		{
			this.iface = iface;
			this.paused = true;
		}
		
		/// <summary>
		/// Creates a new QueuePauseAction that makes the member on the given
		/// interface unavailable on the given queue.
		/// </summary>
		/// <param name="iface">the interface of the member to make unavailable</param>
		/// <param name="queue">the queue the member is made unvailable on</param>
		public QueuePauseAction(string iface, string queue)
		{
			this.iface = iface;
			this.queue = queue;
			this.paused = true;
		}
		
		/// <summary>
		/// Creates a new QueuePauseAction that makes the member on the given
		/// interface available or unavailable on all queues.
		/// </summary>
		/// <param name="iface">the interface of the member to make unavailable</param>
		/// <param name="paused"><code>true</code> to make the member unavailbale, <code>false</code> to make the member available</param>
		public QueuePauseAction(string iface, bool paused)
		{
			this.iface = iface;
			this.paused = paused;
		}
		
		/// <summary>
		/// Creates a new QueuePauseAction that makes the member on the given
		/// interface unavailable on the given queue.
		/// </summary>
		/// <param name="iface">the interface of the member to make unavailable</param>
		/// <param name="queue">the queue the member is made unvailable on</param>
		/// <param name="paused"><code>true</code> to make the member unavailbale, <code>false</code> to make the member available</param>
		public QueuePauseAction(string iface, string queue, bool paused)
		{
			this.iface = iface;
			this.queue = queue;
			this.paused = paused;
		}
	}
}