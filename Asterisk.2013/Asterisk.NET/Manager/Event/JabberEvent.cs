using System;

namespace Asterisk.NET.Manager.Event
{
	public class JabberEvent : ManagerEvent
	{
		private string account;
		private string packet;

		public string Account
		{
			get { return account; }
			set { account = value; }
		}
		public string Packet
		{
			get { return packet; }
			set { packet = value; }
		}

		#region Constructor - JabberEvent(ManagerConnection source)
		public JabberEvent(ManagerConnection source)
			: base(source)
		{
		}
		#endregion
	}
}
