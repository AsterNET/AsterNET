namespace AsterNET.Manager.Event
{
	/// <summary>
	/// A dial begin event is triggered whenever a phone attempts to dial someone.<br/>
	/// This event is implemented in apps/app_dial.c.<br/>
	/// Available since Asterisk 1.2.
	/// </summary>
	public class DialBeginEvent : DialEvent
    {
        /// <summary>
        /// Creates a new DialBeginEvent.
        /// </summary>
        public DialBeginEvent(ManagerConnection source)
			: base(source)
		{
        }
    }
}