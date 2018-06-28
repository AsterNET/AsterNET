namespace AspNetCore.AsterNET.Manager.Event
{
	/// <summary>
	/// A ZapShowChannelsCompleteEvent is triggered after the state of all zap channels has been reported
	/// in response to a ZapShowChannelsAction.
	/// </summary>
	/// <seealso cref="Manager.Action.ZapShowChannelsAction" />
	/// <seealso cref="Manager.Event.ZapShowChannelsEvent" />
	public class ZapShowChannelsCompleteEvent : ResponseEvent
	{
		public ZapShowChannelsCompleteEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}