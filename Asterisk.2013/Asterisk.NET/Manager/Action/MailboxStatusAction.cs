using System;

namespace Asterisk.NET.Manager.Action
{
	/// <summary>
	/// The MailboxStatusAction checks if a mailbox contains waiting messages.<br/>
	/// The MailboxStatusAction returns a MailboxStatusResponse.
	/// </summary>
	/// <seealso cref="Manager.Response.MailboxStatusResponse" />
	public class MailboxStatusAction : ManagerAction
	{
		private string mailbox;

		/// <summary>
		/// Get the name of this action, i.e. "MailboxStatus".
		/// </summary>
		override public string Action
		{
			get { return "MailboxStatus"; }
		}
		/// <summary>
		/// Get/Set the name of the mailbox to query.<br/>
		/// This can either be only the name of the mailbox or a string of the form
		/// mailboxnumber@context. If no context is specified "default" is assumed.<br/>
		/// Multiple mailboxes may be given, separated by ','. In this case the
		/// action checks whether at least one of the given mailboxes has waiting
		/// messages.<br/>
		/// This property is mandatory.<br/>
		/// Example: "1234,1235@mycontext"
		/// </summary>
		public string Mailbox
		{
			get { return this.mailbox; }
			set { this.mailbox = value; }
		}
		
		/// <summary>
		/// Creates a new empty MailboxStatusAction.
		/// </summary>
		public MailboxStatusAction()
		{
		}
		
		/// <summary>
		/// Creates a new MailboxStatusAction that checks for waiting messages in the given mailbox.
		/// </summary>
		/// <param name="mailbox">the name of the mailbox to check.<br/>
		/// This can either be only the number of the mailbox or a string
		/// of the form mailboxnumber@context.If no context is specified
		/// "default" is assumed.
		/// </param>
		public MailboxStatusAction(string mailbox)
		{
			this.mailbox = mailbox;
		}
	}
}