namespace AsterNET.Manager.Event
{
	/// <summary>
	///     A DisconnectEvent is triggered when the connection to the asterisk server is lost.<br/>
	///     It is a pseudo event not directly related to an asterisk generated event.
	/// </summary>
	public class DisconnectEvent : ConnectionStateEvent
	{
        /// <summary>
        ///     Creates a new <see cref="DisconnectEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        /// <param name="source"></param>
        public DisconnectEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}