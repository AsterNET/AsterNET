using System;

namespace AsterNET.Manager.Event
{
	public class QueueCallerAbandonEvent : ManagerEvent, QueueCallerAbandonEventInterface
	{
		public const PrivilegeEnum Privilege = PrivilegeEnum.agent;

		private string calleridnum;
		private string queue;
		private int position;
		private int originalPosition;
		private int holdTime;

		public string Queue
		{
			get { return this.queue ?? string.Empty; }
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
		public string CallerIdNum
		{
			get { return this.calleridnum ?? string.Empty; }
			set { this.calleridnum = value; }
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
