using System;

namespace Asterisk.NET.Manager.Event
{
	public class ShowDialPlanCompleteEvent : ManagerEvent
	{
		private string eventList;
		private int listItems;
		private int listExtensions;
		private int listPriorities;
		private int listContexts;

		public string EventList
		{
			get { return this.eventList; }
			set { this.eventList = value; }
		}
		public int ListItems
		{
			get { return this.listItems; }
			set { this.listItems = value; }
		}
		public int ListExtensions
		{
			get { return this.listExtensions; }
			set { this.listExtensions = value; }
		}
		public int ListPriorities
		{
			get { return this.listPriorities; }
			set { this.listPriorities = value; }
		}
		public int ListContexts
		{
			get { return this.listContexts; }
			set { this.listContexts = value; }
		}

		public ShowDialPlanCompleteEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}