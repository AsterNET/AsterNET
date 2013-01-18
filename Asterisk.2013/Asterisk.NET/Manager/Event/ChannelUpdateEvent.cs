using System;

namespace Asterisk.NET.Manager.Event
{
	public class ChannelUpdateEvent : ManagerEvent
	{
		private string channelType;
		private string sipCallId;
		private string sipFullContact;
		private string peerName;
		private string iax2callnoLocal;
		private string iax2callnoRemote;
		private string iax2peer;
		private string gtalkSID;

		/// <summary>
		/// Get/Set channel type
		/// "SIP",
		/// "IAX2",
		/// "GTALK"
		/// </summary>
		public string ChannelType
		{
			get { return this.channelType; }
			set { this.channelType = value; }
		}

		public string SipCallId
		{
			get { return this.sipCallId; }
			set { this.sipCallId = value; }
		}

		public string SipFullContact
		{
			get { return this.sipFullContact; }
			set { this.sipFullContact = value; }
		}

		public string PeerName
		{
			get { return this.peerName; }
			set { this.peerName = value; }
		}

		public string IAX2CallnoLocal
		{
			get { return this.iax2callnoLocal; }
			set { this.iax2callnoLocal = value; }
		}
		public string IAX2CallnoRemote
		{
			get { return this.iax2callnoRemote; }
			set { this.iax2callnoRemote = value; }
		}
		public string IAX2Peer
		{
			get { return this.iax2peer; }
			set { this.iax2peer = value; }
		}
		public string GTalkSID
		{
			get { return this.gtalkSID; }
			set { this.gtalkSID = value; }
		}

		/// <summary>
		/// Creates a new ChannelUpdateEvent.
		/// </summary>
		public ChannelUpdateEvent(ManagerConnection source)
			: base(source)
		{
		}
}
}
