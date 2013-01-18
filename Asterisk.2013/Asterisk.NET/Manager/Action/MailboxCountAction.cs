using System;

namespace Asterisk.NET.Manager.Action
{
	/// <summary>
	/// The MailboxCountAction queries the number of unread and read messages in a mailbox.<br/>
	/// The MailboxCountAction returns a MailboxStatusResponse.
	/// </summary>
	/// <seealso cref="Manager.Response.MailboxCountResponse" />
	public class MailboxCountAction : ManagerAction
	{
		private string mailbox;

		/// <summary>
		/// Get the name of this action, i.e. "MailboxCount".
		/// </summary>
		override public string Action
		{
			get { return "MailboxCount"; }
		}
		/// <summary>
		/// Get/Set the name of the mailbox to query.<br/>
		/// This can either be only the number of the mailbox or a string of the form
		/// mailboxnumber@context.If no context is specified "default" is assumed.<br/>
		/// This property is mandatory.
		/// </summary>
		public string Mailbox
		{
			get { return this.mailbox; }
			set { this.mailbox = value; }
		}
		
		/// <summary>
		/// Creates a new empty MailboxCountAction.
		/// </summary>
		public MailboxCountAction()
		{
		}
		
		/// <summary>
		/// Creates a new MailboxCountAction that queries the number of unread and
		/// read messages in the given mailbox.
		/// </summary>
		/// <param name="mailbox">the name of the mailbox to query.<br/>
		/// This can either be only the number of the mailbox or a string
		/// of the form mailboxnumber@context.If no context is specified
		/// "default" is assumed.
		/// </param>
		public MailboxCountAction(string mailbox)
		{
			this.mailbox = mailbox;
		}
	}
}