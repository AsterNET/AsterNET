namespace AsterNET.Manager.Event
{
	/// <summary>
	///     A DisconnectEvent is triggered when the connection to the asterisk server is lost.<br/>
	///     It is a pseudo event not directly related to an asterisk generated event.
	/// </summary>
	public class DisconnectEvent : ConnectionStateEvent
	{
        /// <summary>
        ///     Creates a new <see cref="DisconnectEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public DisconnectEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}