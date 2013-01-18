using System;

namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// AgiExecEvents are triggered when an AGI command is executed.<br/>
	/// For each command two events are triggered: one before excution ("Start") and one after execution ("End").
	/// </summary>
	public class AGIExecEvent : ManagerEvent
	{
		private string subEvent;
		private long commandId;
		private string command;
		private int resultCode;
		private string result;

		/// <summary>
		/// Creates a new AGIExecEvent.
		/// </summary>
		public AGIExecEvent(ManagerConnection source)
			: base(source)
		{
		}

		public long CommandId
		{
			get { return commandId; }
			set { this.commandId = value; }
		}
		public string Command
		{
			get { return command; }
			set { this.command = value; }
		}
		public string SubEvent
		{
			get { return subEvent; }
			set { this.subEvent = value; }
		}
		public string Result
		{
			get { return result; }
			set { this.result = value; }
		}
		public int ResultCode
		{
			get { return resultCode; }
			set { this.resultCode = value; }
		}
	}
}
