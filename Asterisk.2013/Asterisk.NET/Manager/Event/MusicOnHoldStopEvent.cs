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

        /// <summary>
        ///     Gets or sets the channel state.<br/>
        ///     A numeric code for the channel's current state, related to ChannelStateDesc
        /// </summary>
        public string ChannelState { get; set; }

        /// <summary>
        ///     Gets or sets the channel state description.
        /// </summary>
        public string ChannelStateDesc { get; set; }

        /// <summary>
        ///     Gets or sets the Caller*ID number.
        /// </summary>
        public string CallerIDNum { get; set; }

        /// <summary>
        ///     Gets or sets the Caller*ID name.
        /// </summary>
        public string CallerIDName { get; set; }

        /// <summary>
        ///     Gets or sets the connected line number.
        /// </summary>
        public string ConnectedLineNum { get; set; }

        /// <summary>
        ///     Gets or sets the connected line name.
        /// </summary>
        public string ConnectedLineName { get; set; }

        /// <summary>
        ///     Gets or sets the language.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        ///     Gets or sets the account code.
        /// </summary>
        public string AccountCode { get; set; }

        /// <summary>
        ///     Gets or sets the context.
        /// </summary>
        public string Context { get; set; }

        /// <summary>
        ///     Gets or sets the exten.
        /// </summary>
        public string Exten { get; set; }

        /// <summary>
        ///     Gets or sets the priority.
        /// </summary>
        public string Priority { get; set; }

        /// <summary>
        ///     Gets or sets the Linked Id
        ///     UniqueId of the oldest channel associated with this channel.
        /// </summary>
        public string LinkedId { get; set; }
    }
}
