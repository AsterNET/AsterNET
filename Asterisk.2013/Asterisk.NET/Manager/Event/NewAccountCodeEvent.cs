using System;

namespace Asterisk.NET.Manager.Event
{
	public class NewAccountCodeEvent : ManagerEvent
	{
		private string accountCode;
		private string oldAccountCode;
		
		public string AccountCode
		{
			get { return this.accountCode; }
			set { this.accountCode = value; }
		}

		public string OldAccountCode
		{
			get { return this.oldAccountCode; }
			set { this.oldAccountCode = value; }
		}

		public NewAccountCodeEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}
