namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     An AlarmEvent is triggered when a Zap channel leaves alarm state.<br/>
    ///     It is implemented in channels/chan_zap.c<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_AlarmClear">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_AlarmClear</see>
    /// </summary>
    public class AlarmClearEvent : ManagerEvent
	{
        /// <summary>
        ///     Creates a new <see cref="AlarmClearEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        /// <param name="source"></param>
        public AlarmClearEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}