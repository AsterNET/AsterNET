using System;

namespace Asterisk.NET.Manager.Event
{
	public class PRIEvent : ManagerEvent
	{
		private string priEvent;
		private string priEventCode;
		private string dChannel;
		private string span;

		public string PriEvent
		{
			get { return this.priEvent; }
			set { this.priEvent = value; }
		}
		public string PriEventCode
		{
			get { return this.priEventCode; }
			set { this.priEventCode = value; }
		}
		public string DChannel
		{
			get { return this.dChannel; }
			set { this.dChannel = value; }
		}
		public string Span
		{
			get { return this.span; }
			set { this.span = value; }
		}

		/// <summary>
		/// Creates a new DNDStateEvent.
		/// </summary>
		public PRIEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}
