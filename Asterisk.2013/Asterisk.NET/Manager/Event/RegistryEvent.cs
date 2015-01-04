namespace AsterNET.Manager.Event
{
	/// <summary>
	/// A RegistryEvent is triggered when this asterisk server attempts to register
	/// as a client at another SIP or IAX server.<br/>
	/// This event is implemented in channels/chan_iax2.c and
	/// channels/chan_sip.c
	/// </summary>
	public class RegistryEvent : ManagerEvent
	{
		private string channelType;
		private string domain;
		private string username;
		private string status;
		private string cause;

		/// <summary>
		/// Channel type
		/// "SIP",
		/// "IAX2"
		/// </summary>
		public string ChannelType
		{
			get { return this.channelType; }
			set { this.channelType = value; }
		}
		/// <summary>
		/// Get/Set the domain or host name of the SIP or IAX2 server.<br/>
		/// This is the host part used in the register lines in
		/// iax.conf and sip.conf.
		/// </summary>
		public string Domain
		{
			get { return domain; }
			set { this.domain = value; }
		}
		/// <summary>
		/// Get/Set the username used for registration.<br/>
		/// SIP send the username in case of a registration timeout, IAX2 in case of
		/// a registration failure. Otherwise the username is null.
		/// </summary>
		public string Username
		{
			get { return username; }
			set { this.username = value; }
		}
		/// <summary>
		/// Sets the username used for registration.
		/// </summary>
		/// <deprecated> Please do not use this method it is a workaround for Asterisk 1.0.x servers. See Asterisk bug 4916.</deprecated>
		public string User
		{
			set { this.username = value; }
		}
		/// <summary>
		/// Get/Set the registration state.<br/>
		/// For sip this may be one of (not sure if all of these are exposed via the
		/// manager api, at least "Registered" and "Timeout" are used though)
		/// <ul>
		/// <li>Registered</li>
		/// <li>Unregistered</li>
		/// <li>Request Sent</li>
		/// <li>Auth. Sent</li>
		/// <li>Rejected</li>
		/// <li>Timeout</li>
		/// <li>No Authentication</li>
		/// <li>Unreachable</li>
		/// </ul>
		/// IAX2 only uses
		/// <ul>
		/// <li>Rejected</li>
		/// </ul>
		/// Successful IAX2 registrations do not use the this property at all.
		/// </summary>
		public string Status
		{
			get { return status; }
			set { this.status = value; }
		}
		/// <summary>
		/// Get/Set the cause of a rejected registration.
		/// The cause of a rejected registration or "&lt;unknown&gt;" if the cause is unknown.
		/// </summary>
		public string Cause
		{
			get { return cause; }
			set { this.cause = value; }
		}
		
		public RegistryEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}