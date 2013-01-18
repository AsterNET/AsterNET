namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A ConnectEvent is triggered after successful login to the asterisk server.<br/>
	/// It is a pseudo event not directly related to an asterisk generated event.
	/// </summary>
	public class ConnectEvent : ConnectionStateEvent
	{
		/// <summary> The version of the manager/proxy protocol.</summary>
		private string protocolIdentifier;
		public ConnectEvent(ManagerConnection source)
			: base(source)
		{
		}

		/// <summary>
		/// Get/Set the version of the protocol.
		/// </summary>
		public string ProtocolIdentifier
		{
			get { return protocolIdentifier; }
			set { this.protocolIdentifier = value; }
		}
	}
}