namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     A ParkedCallGiveUpEvent is triggered when a channel that has been parked is hung up.<br/>
    ///     It is implemented in res/res_features.c<br/>
    ///     Available since Asterisk 1.2<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_ParkedCallGiveUp">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_ParkedCallGiveUp</see>
    /// </summary>
    public class ParkedCallGiveUpEvent : AbstractParkedCallEvent
	{
        /// <summary>
        ///     Creates a new <see cref="ParkedCallGiveUpEvent"/> .
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection" /></param>
        public ParkedCallGiveUpEvent(ManagerConnection source)
			: base(source)
        {
            
		}
	}
}