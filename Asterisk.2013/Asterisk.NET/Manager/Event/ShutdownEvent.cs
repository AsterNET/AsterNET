namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A ShutdownEvent is triggered when the asterisk server is shut down or restarted.<br/>
	/// It is implemented in <code>asterisk.c</code>
	/// </summary>
	public class ShutdownEvent : ConnectionStateEvent
	{
		private string shutdown;
		private bool restart = false;
		private string file;
		private string func;
		private int line;
		private int sequencenumber;

		/// <summary>
		/// Get/Set the kind of shutdown or restart. Possible values are "Uncleanly" and "Cleanly". A
		/// shutdown is considered unclean if there are any active channels when the system is shut down.
		/// </summary>
		public string Shutdown
		{
			get { return shutdown; }
			set { this.shutdown = value; }
		}
		/// <summary>
		/// Get/Set <code>true</code> if the server has been restarted; <code>false</code> if it has been halted.
		/// </summary>
		public bool Restart
		{
			get { return restart; }
			set { this.restart = value; }
		}

		public string File
		{
			get { return file; }
			set { file = value; }
		}
		public string Func
		{
			get { return func; }
			set { func = value; }
		}
		public int Line
		{
			get { return line; }
			set { line = value; }
		}
		public int SequenceNumber
		{
			get { return sequencenumber; }
			set { sequencenumber = value; }
		}

		public ShutdownEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}