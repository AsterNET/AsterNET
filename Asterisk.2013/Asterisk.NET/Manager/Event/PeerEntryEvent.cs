namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     A PeerEntryEvent is triggered in response to a SIPPeersAction or SIPShowPeerAction and contains information about a peer.<br/>
    ///     It is implemented in channels/chan_sip.c
    /// </summary>
    /// <seealso cref="Manager.Action.SIPPeersAction"/>
    /// <seealso cref="Manager.Action.SIPShowPeerAction"/>
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
		///     For SIP peers this is "SIP".
		/// </summary>
		public string ChannelType
		{
			get { return this.channelType; }
			set { this.channelType = value; }
		}
        /// <summary>
        ///     Gets or sets the name of the object.
        /// </summary>
        public string ObjectName
		{
			get { return this.objectName; }
			set { this.objectName = value; }
		}
		/// <summary>
		///     For SIP peers this is either "peer" or "user".
		/// </summary>
		public string ChanObjectType
		{
			get { return this.chanObjectType; }
			set { this.chanObjectType = value; }
		}
		/// <summary>
		///     Get/Set the IP address of the peer.
		/// </summary>
		public string IpAddress
		{
			get { return this.ipAddress; }
			set { this.ipAddress = value; }
		}
        /// <summary>
        ///     Gets or sets the ip port.
        /// </summary>
        public int IpPort
		{
			get { return this.ipPort; }
			set { this.ipPort = value; }
		}
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PeerEntryEvent"/> is dynamic.
        /// </summary>
        public bool Dynamic
		{
			get { return this.dynamic; }
			set { this.dynamic = value; }
		}
        /// <summary>
        /// Gets or sets a value indicating whether [nat support].
        /// </summary>
        public bool NatSupport
		{
			get { return this.natSupport; }
			set { this.natSupport = value; }
		}
        /// <summary>
        /// Gets or sets a value indicating whether [video support].
        /// </summary>
        public bool VideoSupport
		{
			get { return this.videoSupport; }
			set { this.videoSupport = value; }
		}
        /// <summary>
        /// Gets or sets a value indicating whether [text support].
        /// </summary>
        public bool TextSupport
		{
			get { return this.textSupport; }
			set { this.textSupport = value; }
		}
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PeerEntryEvent"/> is acl.
        /// </summary>
        public bool Acl
		{
			get { return this.acl; }
			set { this.acl = value; }
		}
		/// <summary>
		///     Get/Set the status of this peer.<br/>
		///     For SIP peers this is one of:
		///     <dl>
		///         <dt>"UNREACHABLE"</dt>
		///         <dd></dd>
		///         <dt>"LAGGED (%d ms)"</dt>
		///         <dd></dd>
		///         <dt>"OK (%d ms)"</dt>
		///         <dd></dd>
		///         <dt>"UNKNOWN"</dt>
		///         <dd></dd>
		///         <dt>"Unmonitored"</dt>
		///         <dd></dd>
		///     </dl>
		/// </summary>
		public string Status
		{
			get { return this.status; }
			set { this.status = value; }
		}

        /// <summary>
        ///     Gets or sets a value indicating whether [realtime device].
        /// </summary>
        public bool RealtimeDevice
		{
			get { return this.realtimedevice; }
			set { this.realtimedevice = value; }
		}

        /// <summary>
        ///     Creates a new <see cref="PeerEntryEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public PeerEntryEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}