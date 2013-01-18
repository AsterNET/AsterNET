namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// An ExtensionStatusEvent is triggered when the state of an extension changes.<br/>
	/// It is implemented in <code>manager.c</code>
	/// </summary>
	public class ExtensionStatusEvent : ManagerEvent
	{
		private string exten;
		private string context;
		private string hint;
		private int status;

		/// <summary>
		/// Get/Set the extension hint.
		/// </summary>
		public string Hint
		{
			get { return this.hint; }
			set { this.hint = value; }
		}
		/// <summary>
		/// Get/Set the extension.
		/// </summary>
		public string Exten
		{
			get { return exten; }
			set { this.exten = value; }
		}
		/// <summary>
		/// Get/Set the context of the extension.
		/// </summary>
		public string Context
		{
			get { return context; }
			set { this.context = value; }
		}
		/// <summary>
		/// Get/Set the state of the extension.
		/// </summary>
		public int Status
		{
			get { return status; }
			set { this.status = value; }
		}
		
		public ExtensionStatusEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}