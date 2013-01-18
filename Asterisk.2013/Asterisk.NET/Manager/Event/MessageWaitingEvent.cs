namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A MessageWaitingEvent is triggered when someone leaves voicemail.<br/>
	/// It is implemented in <code>apps/app_voicemail.c</code>
	/// </summary>
	public class MessageWaitingEvent : ManagerEvent
	{
		private string mailbox;
		private int waiting;
		private int newMessages;
		private int oldMessages;

		/// <summary>
		/// Get/Set the name of the mailbox that has waiting messages.<br/>
		/// The name of the mailbox is of the form numberOfMailbox@context, e.g. 1234@default.
		/// </summary>
		public string Mailbox
		{
			get { return this.mailbox; }
			set { this.mailbox = value; }
		}
		/// <summary>
		/// Get/Set the number of new messages in the mailbox.
		/// </summary>
		public int Waiting
		{
			get { return this.waiting; }
			set { this.waiting = value; }
		}
		/// <summary>
		/// Get/Set the number of new messages in this mailbox.
		/// </summary>
		public int New
		{
			get { return this.newMessages; }
			set { this.newMessages = value; }
		}
		/// <summary>
		/// Get/Set the number of old messages in this mailbox.
		/// </summary>
		public int Old
		{
			get { return this.oldMessages; }
			set { this.oldMessages = value; }
		}
		
		public MessageWaitingEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}