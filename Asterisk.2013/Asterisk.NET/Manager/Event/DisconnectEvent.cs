namespace AsterNET.Manager.Event
{
	/// <summary>
	/// A DisconnectEvent is triggered when the connection to the asterisk server is lost.<br/>
	/// It is a pseudo event not directly related to an asterisk generated event.
	/// </summary>
	public class DisconnectEvent : ConnectionStateEvent
	{
        public DisconnectEvent(ManagerConnection source)
            : this(source, "no reason")
        {
        }

        public DisconnectEvent(ManagerConnection source, string reason)
			: base(source)
		{
            Reason = reason;
		}

        public string Reason { get; }
    }
}