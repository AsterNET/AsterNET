namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A PeerEntryEvent is triggered in response to a SIPPeersAction or SIPShowPeerAction and contains information about a peer.<br/>
	/// It is implemented in <code>channels/chan_sip.c</code>
	/// </summary>
	public class PeerEntryEvent : ResponseEvent
	{
		private string channelType;
		private string objectName;
		private string chanObjectType;
		private string ipAddress;
		private int ipPort;
		private bool dynamic;
		private bool natSupport;
		private bool videoSupport;
		private bool textSupport;
		private bool acl;
		private string status;
		private bool realtimedevice;

		/// <summary>
		/// For SIP peers this is "SIP".
		/// </summary>
		public string ChannelType
		{
			get { return this.channelType; }
			set { this.channelType = value; }
		}

		public string ObjectName
		{
			get { return this.objectName; }
			set { this.objectName = value; }
		}
		/// <summary>
		/// For SIP peers this is either "peer" or "user".
		/// </summary>
		public string ChanObjectType
		{
			get { return this.chanObjectType; }
			set { this.chanObjectType = value; }
		}
		/// <summary>
		/// Get/Set the IP address of the peer.
		/// </summary>
		public string IpAddress
		{
			get { return this.ipAddress; }
			set { this.ipAddress = value; }
		}
		public int IpPort
		{
			get { return this.ipPort; }
			set { this.ipPort = value; }
		}
		public bool Dynamic
		{
			get { return this.dynamic; }
			set { this.dynamic = value; }
		}
		public bool NatSupport
		{
			get { return this.natSupport; }
			set { this.natSupport = value; }
		}
		public bool VideoSupport
		{
			get { return this.videoSupport; }
			set { this.videoSupport = value; }
		}
		public bool TextSupport
		{
			get { return this.textSupport; }
			set { this.textSupport = value; }
		}
		public bool Acl
		{
			get { return this.acl; }
			set { this.acl = value; }
		}
		/// <summary>
		/// Get/Set the status of this peer.<br/>
		/// For SIP peers this is one of:
		/// <dl>
		/// <dt>"UNREACHABLE"</dt>
		/// <dd></dd>
		/// <dt>"LAGGED (%d ms)"</dt>
		/// <dd></dd>
		/// <dt>"OK (%d ms)"</dt>
		/// <dd></dd>
		/// <dt>"UNKNOWN"</dt>
		/// <dd></dd>
		/// <dt>"Unmonitored"</dt>
		/// <dd></dd>
		/// </dl>
		/// </summary>
		public string Status
		{
			get { return this.status; }
			set { this.status = value; }
		}

		public bool RealtimeDevice
		{
			get { return this.realtimedevice; }
			set { this.realtimedevice = value; }
		}

		/// <summary>
		/// Creates a new instance.
		/// </summary>
		public PeerEntryEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}