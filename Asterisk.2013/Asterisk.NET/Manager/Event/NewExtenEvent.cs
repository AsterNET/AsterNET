namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A NewExtenEvent is triggered when a channel is connected to a new extension.<br/>
	/// It is implemented in <code>pbx.c</code>
	/// </summary>
	public class NewExtenEvent : ManagerEvent
	{
		private string context;
		private string extension;
		private int priority;
		private string application;
		private string appData;
		private string appdEvent;

		public string AppdEvent
		{
			get { return this.appdEvent; }
			set { this.appdEvent = value; }
		}

		/// <summary>
		/// Get/Set the name of the application that is executed.
		/// </summary>
		public string Application
		{
			get { return this.application; }
			set { this.application = value; }
		}
		/// <summary>
		/// Get/Set the parameters passed to the application that is executed. The parameters are separated by a '|' character.
		/// </summary>
		public string AppData
		{
			get { return this.appData; }
			set { this.appData = value; }
		}
		/// <summary>
		/// Get/Set the name of the context of the connected extension.
		/// </summary>
		public string Context
		{
			get { return this.context; }
			set { this.context = value; }
		}
		/// <summary>
		/// Get/Set the extension.
		/// </summary>
		public string Extension
		{
			get { return this.extension; }
			set { this.extension = value; }
		}
		/// <summary>
		/// Get/Set the priority.
		/// </summary>
		public int Priority
		{
			get { return this.priority; }
			set { this.priority = value; }
		}
	
		public NewExtenEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}