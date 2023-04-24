namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     Raised when monitoring has started on a channel.<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_MonitorStart">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_MonitorStart</see>
    /// </summary>
    public class MonitorStartEvent : ManagerEvent
	{
        #region Constructor - MonitorStart(ManagerConnection source)
        /// <summary>
        ///     Creates a new <see cref="MonitorStartEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public MonitorStartEvent(ManagerConnection source)
			: base(source)
		{
		}
		#endregion
	}
}
