namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     Raised when monitoring has stopped on a channel.<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_MonitorStop">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_MonitorStop</see>
    /// </summary>
	public class MonitorStopEvent : ManagerEvent
	{
        #region Constructor - MonitorStop(ManagerConnection source)        
        /// <summary>
        ///     Creates a new <see cref="MonitorStopEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public MonitorStopEvent(ManagerConnection source)
			: base(source)
		{
		}
		#endregion
	}
}
