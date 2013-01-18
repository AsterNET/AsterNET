using System;
namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A LogChannelEvent is triggered when logging is turned on or off.<br/>
	/// It is implemented in <code>logger.c</code><br/>
	/// </summary>
	public class LogChannelEvent : ManagerEvent
	{
		private bool enabled;
		private string reason;
		private int reasonCode;

		/// <summary>
		/// Get/Set if logging has been enabled or disabled.
		/// </summary>
		public bool Enabled
		{
			get { return enabled; }
			set { this.enabled = value; }
		}
		/// <summary>
		/// Get the textual representation of the reason for disabling logging.
		/// </summary>
		public string Reason
		{
			get { return this.reason; }
			set
			{
				reason = "";
				reasonCode = 0;

				if (string.IsNullOrEmpty(value))
					return;

				int spaceIdx;

				if ((spaceIdx = value.IndexOf(' ')) <= 0)
					spaceIdx = value.Length;
				int.TryParse(value.Substring(0, spaceIdx), out this.reasonCode);
				if (value.Length > spaceIdx + 3)
					this.reason = value.Substring(spaceIdx + 3, value.Length - spaceIdx + 3);
			}
		}

		/// <summary>
		/// Get the reason code for disabling logging.
		/// </summary>
		public int ReasonCode
		{
			get { return this.reasonCode; }
		}
		
		public LogChannelEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}