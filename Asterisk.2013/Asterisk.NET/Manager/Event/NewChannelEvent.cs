namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     A NewChannelEvent is triggered when a new channel is created.<br/>
    ///     It is implemented in channel.c<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_Newchannel">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_Newchannel</see>
    /// </summary>
    public class NewChannelEvent : AbstractChannelEvent
	{
        /// <summary>
        ///     Creates a new <see cref="NewChannelEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public NewChannelEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}