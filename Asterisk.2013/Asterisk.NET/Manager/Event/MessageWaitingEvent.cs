namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     A MessageWaitingEvent is triggered when someone leaves voicemail.<br />
    ///     It is implemented in apps/app_voicemail.c<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+12+ManagerEvent_MessageWaiting">https://wiki.asterisk.org/wiki/display/AST/Asterisk+12+ManagerEvent_MessageWaiting</see>
    /// </summary>
    public class MessageWaitingEvent : ManagerEvent
    {
        /// <summary>
        ///     Creates a new <see cref="MessageWaitingEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        /// <param name="source"></param>
        public MessageWaitingEvent(ManagerConnection source)
            : base(source)
        {
        }

        /// <summary>
        ///     Get/Set the name of the mailbox that has waiting messages.<br />
        ///     The name of the mailbox is of the form numberOfMailbox@context, e.g. 1234@default.
        /// </summary>
        public string Mailbox { get; set; }

        /// <summary>
        ///     Get/Set the number of new messages in the mailbox.
        /// </summary>
        public int Waiting { get; set; }

        /// <summary>
        ///     Get/Set the number of new messages in this mailbox.
        /// </summary>
        public int New { get; set; }

        /// <summary>
        ///     Get/Set the number of old messages in this mailbox.
        /// </summary>
        public int Old { get; set; }
    }
}