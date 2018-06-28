namespace AspNetCore.AsterNET.Manager.Event
{
    public class ChannelUpdateEvent : ManagerEvent
    {
        /// <summary>
        ///     Creates a new ChannelUpdateEvent.
        /// </summary>
        public ChannelUpdateEvent(ManagerConnection source)
            : base(source)
        {
        }

        /// <summary>
        ///     Get/Set channel type
        ///     "SIP",
        ///     "IAX2",
        ///     "GTALK"
        /// </summary>
        public string ChannelType { get; set; }

        public string SipCallId { get; set; }

        public string SipFullContact { get; set; }

        public string PeerName { get; set; }

        public string IAX2CallnoLocal { get; set; }

        public string IAX2CallnoRemote { get; set; }

        public string IAX2Peer { get; set; }

        public string GTalkSID { get; set; }
    }
}