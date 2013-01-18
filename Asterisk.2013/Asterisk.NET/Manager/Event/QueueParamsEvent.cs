using System;
namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A QueueParamsEvent is triggered in response to a QueueStatusAction and contains the parameters of a queue.<br/>
	/// It is implemented in <code>apps/app_queue.c</code>
	/// </summary>
	/// <seealso cref="Manager.Action.QueueStatusAction" />
	public class QueueParamsEvent : ResponseEvent
	{
		private string queue;
		private int max;
		private int calls;
		private int holdtime;
		private int completed;
		private int abandoned;
		private int serviceLevel;
		private Double serviceLevelPerf;
		private int weight;
		private string strategy;

		/// <summary>
		/// Get/Set queue strategy.
		/// </summary>
		public string Strategy
		{
			get { return strategy; }
			set { this.strategy = value; }
		}
		/// <summary>
		/// Get/Set the name of the queue.
		/// </summary>
		public string Queue
		{
			get { return queue; }
			set { this.queue = value; }
		}
		/// <summary> Returns the maximum number of people waiting in the queue or 0 for unlimited.<br/>
		/// This corresponds to the <code>maxlen</code> setting in <code>queues.conf</code>.
		/// </summary>
		/// <summary> Sets the maximum number of people waiting in the queue.</summary>
		public int Max
		{
			get { return max; }
			set { this.max = value; }
		}
		/// <summary> Returns the number of calls currently waiting in the queue.</summary>
		/// <summary> Sets the number of calls currently waiting in the queue.</summary>
		public int Calls
		{
			get { return calls; }
			set { this.calls = value; }
		}
		/// <summary> Returns the current average holdtime for this queue (in seconds).</summary>
		/// <summary> Sets the current average holdtime for this queue.</summary>
		public int Holdtime
		{
			get { return holdtime; }
			set { this.holdtime = value; }
		}
		/// <summary> Returns the number of completed calls.</summary>
		/// <summary> Sets the number of completed calls.</summary>
		public int Completed
		{
			get { return completed; }
			set { this.completed = value; }
		}
		/// <summary> Returns the number of abandoned calls.</summary>
		/// <summary> Sets the number of abandoned calls.</summary>
		public int Abandoned
		{
			get { return abandoned; }
			set { this.abandoned = value; }
		}
		/// <summary> Returns the service level (in seconds) as defined by the <code>servicelevel</code> setting
		/// in <code>queues.conf</code>.
		/// </summary>
		/// <summary> Sets the service level.</summary>
		public int ServiceLevel
		{
			get { return serviceLevel; }
			set { this.serviceLevel = value; }
		}
		/// <summary> Returns the ratio of calls answered within the specified service level per total completed
		/// calls (in percent).
		/// </summary>
		/// <summary> Sets the ratio of calls answered within the specified service level per total completed
		/// calls.
		/// </summary>
		public Double ServiceLevelPerf
		{
			get { return serviceLevelPerf; }
			set { this.serviceLevelPerf = value; }
		}

		/// <summary>
		/// Returns the weight of this queue.<br/>
		/// A queues can be assigned a 'weight' to ensure calls waiting in a 
		/// higher priority queue will deliver its calls first. Only delays 
		/// the lower weight queue's call if the member is also in the 
		/// higher weight queue.
		/// </summary>
		public int Weight
		{
			get { return weight; }
			set { this.weight = value; }
		}
		
		public QueueParamsEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}