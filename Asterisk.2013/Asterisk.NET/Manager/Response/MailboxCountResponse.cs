namespace Asterisk.NET.Manager.Response
{
	/// <summary>
	/// A MailboxCountResponse is sent in response to a MailboxCountAction and contains the number of old
	/// and new messages in a mailbox.
	/// </summary>
	/// <seealso cref="Manager.Action.MailboxCountAction" />
	public class MailboxCountResponse:ManagerResponse
	{
		private string mailbox;
		private int newMessages;
		private int oldMessages;

		/// <summary>
		/// Get/Set the name of the mailbox.
		/// </summary>
		public string Mailbox
		{
			get { return mailbox; }
			set { this.mailbox = value; }
		}
		/// <summary>
		/// Get/Set the number of new messages in the mailbox.
		/// </summary>
		public int NewMessages
		{
			get { return newMessages; }
			set { this.newMessages = value; }
		}
		/// <summary>
		/// Returns the number of old messages in the mailbox.
		/// </summary>
		public int OldMessages
		{
			get { return oldMessages; }
			set { this.oldMessages = value; }
		}
	}
}