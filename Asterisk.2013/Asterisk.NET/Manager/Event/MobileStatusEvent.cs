using System;

namespace AsterNET.Manager.Event
{
	public class MobileStatusEvent : ManagerEvent
	{
		private string status;
		private string device;
		public string Status
		{
			get { return status; }
			set { status = value; }
		}
		public string Device
		{
			get { return device; }
			set { device = value; }
		}

		#region Constructor - MobileStatus(ManagerConnection source)
		public MobileStatusEvent(ManagerConnection source)
			: base(source)
		{
		}
		#endregion
	}
}
