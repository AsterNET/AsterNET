namespace AsterNET.Manager.Event
{
    /// <summary>
    /// A dial begin event is triggered whenever when a dial action has completed.<br/>
    /// </summary>
	public class DialEndEvent : DialEvent
    {
        /// <summary>
        /// Creates a new DialEndEvent.
        /// </summary>
        public DialEndEvent(ManagerConnection source)
			: base(source)
		{
        }

        public string Forward { get; set; }
    }
}