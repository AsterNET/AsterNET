using System;
using System.Collections.Generic;
using System.Text;

namespace Asterisk.NET.Manager.Event
{
	class DTMFEvent : ManagerEvent
	{
		private string digit;
		private string direction;
		private bool begin;
		private bool end;

		public string Direction
		{
			get { return direction; }
			set { this.direction = value; }
		}
		public string Digit
		{
			get { return digit; }
			set { this.digit = value; }
		}
		public bool Begin
		{
			get { return begin; }
			set { this.begin = value; }
		}
		public bool End
		{
			get { return end; }
			set { this.end = value; }
		}

		/// <summary>
		/// Creates a new DialEvent.
		/// </summary>
		public DTMFEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}
