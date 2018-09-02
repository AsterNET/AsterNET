namespace AsterNET.Manager.Event
{
    /// <summary>
    /// 
    /// </summary>
    public class ChannelUpdateEvent : ManagerEvent
    {
        /// <summary>
        ///     Creates a new <see cref="ChannelUpdateEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
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