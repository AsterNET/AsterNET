namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     A NewStateEvent is triggered when the state of a channel has changed.<br/>
    ///     It is implemented in channel.c<br/>
    ///     See <see target="_blank"  href="LINK">LINK</see>
    /// </summary>
    public class NewStateEvent : AbstractChannelEvent
	{
        /// <summary>
        ///     Creates a new <see cref="NewStateEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection" /></param>
        public NewStateEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}