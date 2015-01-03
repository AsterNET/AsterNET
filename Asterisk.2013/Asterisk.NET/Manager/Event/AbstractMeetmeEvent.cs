namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     Abstract base class providing common properties for meet me (asterisk's conference system) events.
    /// </summary>
    public abstract class AbstractMeetmeEvent : ManagerEvent
    {
        public AbstractMeetmeEvent(ManagerConnection source)
            : base(source)
        {
        }

        /// <summary>
        ///     Get/Set the conference number.
        /// </summary>
        public string Meetme { get; set; }

        public int Usernum { get; set; }
    }
}