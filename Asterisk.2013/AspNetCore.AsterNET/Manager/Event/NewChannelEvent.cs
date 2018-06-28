namespace AspNetCore.AsterNET.Manager.Event
{
	/// <summary>
	/// A NewChannelEvent is triggered when a new channel is created.<br/>
	/// It is implemented in channel.c
	/// </summary>
	public class NewChannelEvent : AbstractChannelEvent
	{
		public NewChannelEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}