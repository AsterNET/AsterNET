namespace Asterisk.NET.Manager.Response
{
	/// <summary>
	/// A MailboxStatusResponse is sent in response to a MailboxStatusAction and indicates if a set
	/// of mailboxes contains waiting messages.
	/// </summary>
	/// <seealso cref="Manager.Action.MailboxStatusAction" />
	public class MailboxStatusResponse:ManagerResponse
	{
		/// <summary> The name of the mailbox.</summary>
		private string mailbox;
		/// <summary> Indicates if there are new messages waiting in the given set of mailboxes.</summary>
		private bool waiting;

		/// <summary>
		/// Get/Set the names of the mailboxes, separated by ",".
		/// </summary>
		public string Mailbox
		{
			get { return mailbox; }
			set { this.mailbox = value; }
		}
		/// <summary>
		/// Get/Set true if at least one of the given mailboxes contains new messages, false otherwise.
		/// </summary>
		public bool Waiting
		{
			get { return waiting; }
			set { this.waiting = value; }
		}
	}
}