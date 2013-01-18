namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A ReloadEvent is triggerd when the <code>reload</code> console command is executed or the asterisk server is started.<br/>
	/// It is implemented in <code>manager.c</code>
	/// </summary>
	public class ReloadEvent : ConnectionStateEvent
	{
		private string message;
		private string module;
		private string status;

		/// <summary>Reload event status.</summary>
		public string Status
		{
			get { return this.status; }
			set { this.status = value; }
		}
		/// <summary> Returns
		/// "Manager"
		/// "Enum"
		/// "DNSmgr"
		/// "CDR"
		/// </summary>
		public string Module
		{
			get { return this.module; }
			set { this.module = value; }
		}
		/// <summary> Returns
		/// "Reload Requested",
		/// "ENUM reload Requested",
		/// "DNSmgr reload Requested",
		/// "CDR subsystem reload requested"
		/// .</summary>
		public string Message
		{
			get { return this.message; }
			set { this.message = value; }
		}

		public ReloadEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}