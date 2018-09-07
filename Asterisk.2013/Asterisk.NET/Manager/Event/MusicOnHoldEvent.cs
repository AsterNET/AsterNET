namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     A MusicOnHoldEvent is triggered when music on hold starts or stops on a channel.<br/>
    ///     It is implemented in res/res_musiconhold.c.<br/>
    ///     Available since Asterisk 1.6
    /// </summary>
    public class MusicOnHoldEvent : ManagerEvent 
	{
        /// <summary>
        ///     Creates a new <see cref="MusicOnHoldEvent" />.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public MusicOnHoldEvent(ManagerConnection source) : base(source)
		{
		}

		/// <summary>
		///     Gets or sets the state.
		/// </summary>
		public string State { get; set; }

        /// <summary>
        ///     Gets or sets the class.<br/>
        ///     The class of music being played on the channel.
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        ///     Gets or sets the account code.
        /// </summary>
        public string AccountCode { get; set; }

        /// <summary>
        ///     Gets or sets the language.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        ///     Gets or sets the Linked Id<br/>
        ///     UniqueId of the oldest channel associated with this channel.
        /// </summary>
        public string LinkedId { get; set; }
    }
}
