using System;

namespace Asterisk.NET.Manager.Event
{
	public class AsyncAGIEvent : ManagerEvent
	{
		private string subEvent;
		private string env;
		private string result;
		private string commandId;

		public string Result
		{
			get { return result; }
			set { result = value; }
		}
		public string CommandId
		{
			get { return commandId; }
			set { commandId = value; }
		}
		public string SubEvent
		{
			get { return subEvent; }
			set { subEvent = value; }
		}
		public string Env
		{
			get { return env; }
			set { env = value; }
		}

		#region Constructor - AsyncAGIEvent(ManagerConnection source)
		public AsyncAGIEvent(ManagerConnection source)
			: base(source)
		{
		}
		#endregion
	}
}
