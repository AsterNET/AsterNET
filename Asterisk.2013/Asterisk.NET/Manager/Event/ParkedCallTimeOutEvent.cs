namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     A ParkedCallTimeOutEvent is triggered when call parking times out for a given channel.<br/>
    ///     It is implemented in res/res_features.c<br/>
    ///     Available since Asterisk 1.2<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_ParkedCallTimeOut">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_ParkedCallTimeOut</see>
    /// </summary>
    public class ParkedCallTimeOutEvent : AbstractParkedCallEvent
	{
        /// <summary>
        ///     Creates a new <see cref="ParkedCallTimeOutEvent"/> .
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection" /></param>
        public ParkedCallTimeOutEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}