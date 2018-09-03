namespace AsterNET.Manager.Event
{

    /// <summary>
    ///     A PeerStatusEvent is triggered when a SIP or IAX client attempts to register at this asterisk server.<br/>
    ///     This event is implemented in channels/chan_iax2.c and channels/chan_sip.c<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_PeerStatus">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_PeerStatus</see>
    /// </summary>
    public class PeerStatusEvent : ManagerEvent
	{
		private string channelType;
		private string peer;
		private string peerStatus;
		private string cause;
		private int time;

        /// <summary>
        ///     Creates a new <see cref="PeerStatusEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection" /></param>
        public PeerStatusEvent(ManagerConnection source)
			: base(source)
		{
		}

		/// <summary>
		///     Channel type "SIP", "IAX2
		/// </summary>
		public string ChannelType
		{
			get { return channelType; }
			set { this.channelType = value; }
		}
        /// <summary>
        ///     Sets the name of the peer that registered.<br/>
        ///     Returns the name of the peer that registered. The peer's name starts with "IAX2/" if it is an IAX client or "SIP/" if it is a SIP client.<br/>
        ///     It is followed by the username that is used for registration.
        /// </summary>
        public string Peer
		{
			get { return peer; }
			set { this.peer = value; }
		}
        /// <summary> 
        ///     Sets the registration state.<br/>
        ///     Returns the registration state.<br/>
        ///     This may be one of:<br/>
        ///     <ul>
        ///         <li>Registered</li>
        ///         <li>Unregistered</li>
        ///         <li>Reachable</li>
        ///         <li>Lagged</li>
        ///         <li>Unreachable</li>
        ///         <li>Rejected (IAX only)</li>
        ///     </ul>
        /// </summary>
        public string PeerStatus
		{
			get { return peerStatus; }
			set { this.peerStatus = value; }
		}
        /// <summary>
        ///     Sets the cause of the rejection or unregistration.<br/>
        ///     Returns the cause of a rejection or unregistration.<br/>
        ///     For IAX peers this is set only if the status equals "Rejected".<br/>
        ///     For SIP peers this is set if the status equals "Unregistered" and the peer was unregistered due to an expiration. In that case the cause is set to "Expired".
        /// </summary>
        public string Cause
		{
			get { return cause; }
			set { this.cause = value; }
		}
		/// <summary>
		///     Returns the ping time of the client if status equals "Reachable" or "Lagged"; 
        ///     if the status equals "Unreachable" it returns how long the last response took (in ms) for IAX peers or -1 for SIP peers.
		/// </summary>
		public int Time
		{
			get { return time; }
			set { this.time = value; }
		}

	}
}