namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     An AlarmEvent is triggered when a Zap channel enters or changes alarm state.<br />
    ///     It is implemented in channels/chan_zap.c
    /// </summary>
    public class AlarmEvent : ManagerEvent
    {
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