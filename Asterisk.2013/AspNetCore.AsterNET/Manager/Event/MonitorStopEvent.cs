using System;

namespace AspNetCore.AsterNET.Manager.Event
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
