namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     Raised when music on hold has stopped on a channel.<br />
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_MusicOnHoldStop">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_MusicOnHoldStop</see>
    /// </summary>
    public class MusicOnHoldStopEvent : ManagerEvent 
	{
        /// <summary>
        ///     Creates a new <see cref="MusicOnHoldStopEvent" />.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public MusicOnHoldStopEvent(ManagerConnection source) : base(source)
		{
		}
        
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
