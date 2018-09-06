namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     Raised when music on hold has started on a channel.<br />
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_MusicOnHoldStart">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_MusicOnHoldStart</see>
    /// </summary>
    public class MusicOnHoldStartEvent : ManagerEvent 
	{
        /// <summary>
        ///     Creates a new <see cref="MusicOnHoldStartEvent" />.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public MusicOnHoldStartEvent(ManagerConnection source) : base(source)
        {
        }

        /// <summary>
        ///     Gets or sets the class of music being played on the channel.
        /// </summary>
        public string Class { get; set; }

        public string ChannelState { get; set; }
        public string ChannelStateDesc { get; set; }

        public string CallerIDNum { get; set; }
        public string CallerIDName { get; set; }

        public string ConnectedLineNum { get; set; }
        public string ConnectedLineName { get; set; }

        public string Language { get; set; }
        public string AccountCode { get; set; }
        public string Context { get; set; }
        public string Exten { get; set; }
        public string Priority { get; set; }

    }
}
