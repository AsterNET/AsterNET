namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     A CdrEvent is triggered when a call detail record is generated, usually at the end of a call.<br />
    ///     To enable CdrEvents you have to add enabled = yes to the general section in cdr_manager.conf.<br />
    ///     This event is implemented in cdr/cdr_manager.c<br />
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_Cdr">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_Cdr</see>
    /// </summary>
    public class CdrEvent : ManagerEvent
    {
        /// <summary>
        ///     Creates a new <see cref="CdrEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public CdrEvent(ManagerConnection source)
            : base(source)
        {
        }

        /// <summary>
        ///     Gets or sets the account code.
        /// </summary>
        public string AccountCode { get; set; }

        /// <summary>
        ///     Gets or sets the source.
        /// </summary>
        public string Src { get; set; }

        /// <summary>
        ///     Gets or sets the destination.
        /// </summary>
        public string Destination { get; set; }

        /// <summary>
        ///     Gets or sets the destination context.
        /// </summary>
        public string DestinationContext { get; set; }

        /// <summary>
        ///     Gets or sets the caller identifier.
        /// </summary>
        public string CallerId { get; set; }

        /// <summary>
        ///     Gets or sets the destination channel.
        /// </summary>
        public string DestinationChannel { get; set; }

        /// <summary>
        ///     Gets or sets the last application.
        /// </summary>
        public string LastApplication { get; set; }

        /// <summary>
        ///     Gets or sets the last data.
        /// </summary>
        public string LastData { get; set; }

        /// <summary>
        ///     Gets or sets the start time.
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        ///     Gets or sets the answer time.
        /// </summary>
        public string AnswerTime { get; set; }

        /// <summary>
        ///     Gets or sets the end time.
        /// </summary>
        public string EndTime { get; set; }

        /// <summary>
        ///     Gets or sets the duration.
        /// </summary>
        public long Duration { get; set; }

        /// <summary>
        ///     Gets or sets the billable seconds.
        /// </summary>
        public long BillableSeconds { get; set; }

        /// <summary>
        ///     Gets or sets the disposition.
        /// </summary>
        public string Disposition { get; set; }

        /// <summary>
        ///     Gets or sets the ama flags.
        /// </summary>
        public string AmaFlags { get; set; }

        /// <summary>
        ///     Gets or sets the user field.
        /// </summary>
        public string UserField { get; set; }
    }
}