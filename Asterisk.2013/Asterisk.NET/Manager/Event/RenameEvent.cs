namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A RenameEvent is triggered when the name of a channel is changed.<br/>
	/// It is implemented in <code>channel.c</code>
	/// </summary>
	public class RenameEvent : ManagerEvent
	{
		protected internal string oldName;
		protected internal string newName;

		/// <summary>
		/// Get/Set the new name of the channel.
		/// </summary>
		public string NewName
		{
			get { return newName; }
			set { this.newName = value; }
		}
		/// <summary>
		/// Get/Set the old name of the channel.
		/// </summary>
		public string OldName
		{
			get { return oldName; }
			set { this.oldName = value; }
		}

		public RenameEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}