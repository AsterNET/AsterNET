namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A NewChannelEvent is triggered when a new channel is created.<br/>
	/// It is implemented in <code>channel.c</code>
	/// </summary>
	public class NewChannelEvent : AbstractChannelEvent
	{
		public NewChannelEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}