using System;

namespace Asterisk.NET.Manager.Event
{
	public class OriginateResponseEvent : ResponseEvent
	{
		private string response;
		private string context;
		private string exten;
		private int reason;
		private string callerIdNum;
		private string callerIdName;
		private string callerId;

		public string Response
		{
			get { return this.response; }
			set { this.response = value; }
		}
		public string Context
		{
			get { return this.context; }
			set { this.context = value; }
		}
		public string Exten
		{
			get { return this.exten; }
			set { this.exten = value; }
		}
		public int Reason
		{
			get { return this.reason; }
			set { this.reason = value; }
		}
		public string CallerId
		{
			get { return callerId; }
			set { callerId = value; }
		}
		public string CallerIdNum
		{
			get { return this.callerIdNum; }
			set { this.callerIdNum = value; }
		}
		public string CallerIdName
		{
			get { return this.callerIdName; }
			set { this.callerIdName = value; }
		}

		public OriginateResponseEvent(ManagerConnection source)
			: base(source)
		{
		}

	}
}
