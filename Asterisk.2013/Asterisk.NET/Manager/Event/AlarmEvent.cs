namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     An AlarmEvent is triggered when a Zap channel enters or changes alarm state.<br />
    ///     It is implemented in channels/chan_zap.c<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_Alarm">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_Alarm</see>
    /// </summary>
    public class AlarmEvent : ManagerEvent
    {
        /// <summary>
        ///     Creates a new <see cref="AlarmEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        /// <param name="source"></param>
        public AlarmEvent(ManagerConnection source)
            : base(source)
        {
        }

        /// <summary>
        ///     Get/Set the kind of alarm that happened.<br />
        ///     This may be one of
        ///     <ul>
        ///         <li>Red Alarm</li>
        ///         <li>Yellow Alarm</li>
        ///         <li>Blue Alarm</li>
        ///         <li>Recovering</li>
        ///         <li>Loopback</li>
        ///         <li>Not Open</li>
        ///     </ul>
        /// </summary>
        public string Alarm { get; set; }
    }
}