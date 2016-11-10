namespace AsterNET.Manager.Event
{
    /// <summary>
    /// A dial begin event is triggered whenever when a dial action has started.<br/>
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