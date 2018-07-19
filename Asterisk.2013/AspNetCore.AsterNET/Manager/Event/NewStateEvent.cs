namespace AspNetCore.AsterNET.Manager.Event
{
	/// <summary>
	/// A NewStateEvent is triggered when the state of a channel has changed.<br/>
	/// It is implemented in channel.c
	/// </summary>
	public class NewStateEvent : AbstractChannelEvent
	{
		public NewStateEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}