using System;

namespace Asterisk.NET.Manager.Event
{
	public class ModuleLoadReportEvent : ManagerEvent
	{
		private string moduleLoadStatus;
		private string moduleSelection;
		private int moduleCount;

		public string ModuleLoadStatus
		{
			get { return this.moduleLoadStatus; }
			set { this.moduleLoadStatus = value; }
		}
		public string ModuleSelection
		{
			get { return this.moduleSelection; }
			set { this.moduleSelection = value; }
		}
		public int ModuleCount
		{
			get { return this.moduleCount; }
			set { this.moduleCount = value; }
		}

		public ModuleLoadReportEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}
