namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A NewStateEvent is triggered when the state of a channel has changed.<br/>
	/// It is implemented in <code>channel.c</code>
	/// </summary>
	public class NewStateEvent : AbstractChannelEvent
	{
		public NewStateEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}