namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     A CdrEvent is triggered when a call detail record is generated, usually at the end of a call.<br />
    ///     To enable CdrEvents you have to add enabled = yes to the general section in
    ///     cdr_manager.conf.<br />
    ///     This event is implemented in cdr/cdr_manager.c
    /// </summary>
    public class CdrEvent : ManagerEvent
    {
        public CdrEvent(ManagerConnection source)
            : base(source)
        {
        }

        public string AccountCode { get; set; }

        public string Src { get; set; }

        public string Destination { get; set; }

        public string DestinationContext { get; set; }

        public string CallerId { get; set; }

        public string DestinationChannel { get; set; }

        public string LastApplication { get; set; }

        public string LastData { get; set; }

        public string StartTime { get; set; }

        public string AnswerTime { get; set; }

        public string EndTime { get; set; }

        public long Duration { get; set; }

        public long BillableSeconds { get; set; }

        public string Disposition { get; set; }

        public string AmaFlags { get; set; }

        public string UserField { get; set; }
    }
}