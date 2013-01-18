namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// An AgentDumpEvent is triggered when an agent dumps the caller while listening
	/// to the queue announcement.
	/// </summary>
	public class AgentDumpEvent : AbstractAgentEvent
	{
		public AgentDumpEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}