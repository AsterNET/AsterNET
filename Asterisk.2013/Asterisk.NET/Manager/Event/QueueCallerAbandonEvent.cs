using System;

namespace Asterisk.NET.Manager.Event
{
	public class QueueCallerAbandonEvent : ManagerEvent
	{
		private string queue;
		private int position;
		private int originalPosition;
		private int holdTime;

		public string Queue
		{
			get { return this.queue; }
			set { this.queue = value; }
		}
		public int HoldTime
		{
			get { return this.holdTime; }
			set { this.holdTime = value; }
		}
		public int Position
		{
			get { return this.position; }
			set { this.position = value; }
		}
		public int OriginalPosition
		{
			get { return this.originalPosition; }
			set { this.originalPosition = value; }
		}
		/// <summary>
		/// Creates a new DNDStateEvent.
		/// </summary>
		public QueueCallerAbandonEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}
