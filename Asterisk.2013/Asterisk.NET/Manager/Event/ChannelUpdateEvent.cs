namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     A ChannelUpdateEvent provides additional channel type specific information like the SIP call id or IAX2 call numbers about a channel.<br/>
    ///     Available since Asterisk 1.6.<br/>
    ///     It is implemented in <code>channels/chan_sip.c</code>, <code>channels/chan_iax2.c</code> and <code>channels/chan_gtalk.c</code>
    /// </summary>
    public class ChannelUpdateEvent : ManagerEvent
    {
        /// <summary>
        /// Creates a new <see cref="ChannelUpdateEvent" />.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public ChannelUpdateEvent(ManagerConnection source)
            : base(source)
        {
        }

        /// <summary>
        ///     Get/Set channel type "SIP", "IAX2", "GTALK"
        /// </summary>
        public string ChannelType { get; set; }

        /// <summary>
        ///     Gets or sets the sip call identifier.
        /// </summary>
        public string SipCallId { get; set; }

        /// <summary>
        ///     Gets or sets the sip full contact.
        /// </summary>
        public string SipFullContact { get; set; }

        /// <summary>
        ///     Gets or sets the name of the peer.
        /// </summary>
        public string PeerName { get; set; }

        /// <summary>
        ///     Gets or sets the iax2 call no local.
        /// </summary>
        public string IAX2CallnoLocal { get; set; }

        /// <summary>
        ///     Gets or sets the iax2 call no remote.
        /// </summary>
        public string IAX2CallnoRemote { get; set; }

        /// <summary>
        ///     Gets or sets the iax2 peer.
        /// </summary>
        public string IAX2Peer { get; set; }

        /// <summary>
        ///     Gets or sets the g talk sid.
        /// </summary>
        public string GTalkSID { get; set; }
    }
}