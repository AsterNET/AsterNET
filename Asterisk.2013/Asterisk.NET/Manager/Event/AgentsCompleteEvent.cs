namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// An AgentsCompleteEvent is triggered after the state of all agents has been
	/// reported in response to an AgentsAction.<br/>
	/// Available since Asterisk 1.2
	/// </summary>
	/// <seealso cref="Manager.Action.AgentsAction" />
	public class AgentsCompleteEvent : ResponseEvent
	{
		public AgentsCompleteEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}