using System;

namespace AsterNET.Manager.Event
{
	public class MonitorStopEvent : ManagerEvent
	{
		#region Constructor - MonitorStop(ManagerConnection source)
		public MonitorStopEvent(ManagerConnection source)
			: base(source)
		{
		}
		#endregion
	}
}
