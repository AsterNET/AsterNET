using System;

namespace Asterisk.NET.Manager.Action
{
	/// <summary>
	/// The QueueRemoveAction removes a member from a queue.<br/>
	/// It is implemented in <code>apps/app_queue.c</code>
	/// </summary>
	public class QueueRemoveAction : ManagerAction
	{
		/// <summary> The name of the queue the member will be removed from.</summary>
		private string queue;
		private string iface;

		/// <summary>
		/// Get the name of this action, i.e. "QueueRemove".
		/// </summary>
		override public string Action
		{
			get
			{
				return "QueueRemove";
			}
			
		}
		/// <summary>
		/// Get/Set the name of the queue the member will be removed from.
		/// </summary>
		public string Queue
		{
			get { return this.queue; }
			set { this.queue = value; }
		}
		/// <summary>
		/// Get/Set the interface to remove.<br/>
		/// This property is mandatory.
		/// </summary>
		public string Interface
		{
			get { return this.iface; }
			set { this.iface = value; }
		}
		
		/// <summary>
		/// Creates a new empty QueueRemoveAction.
		/// </summary>
		public QueueRemoveAction()
		{
		}
		
		/// <summary>
		/// Creates a new QueueRemoveAction that removes the member on the given interface from the given queue.
		/// </summary>
		/// <param name="queue">the name of the queue the member will be removed from</param>
		/// <param name="iface">the interface of the member to remove</param>
		public QueueRemoveAction(string queue, string iface)
		{
			this.queue = queue;
			this.iface = iface;
		}
	}
}