namespace AsterNET.Manager.Event
{
	/// <summary>
	/// Raised when a Queue member's status has changed
	/// </summary>
	public class CoreShowChannelsCompleteEvent : ResponseEvent
	{
		/// <summary>
		/// Creates a new CoreShowChannelsCompleteEvent
		/// </summary>
		/// <param name="source">ManagerConnection passed through in the event.</param>
		public CoreShowChannelsCompleteEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}
