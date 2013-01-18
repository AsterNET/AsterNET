namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// An UnlinkEvent is triggered when a link between two voice channels is discontinued,
	/// for example, just before call completion.
	/// </summary>
	public class UnlinkEvent : BridgeEvent
	{
		public UnlinkEvent(ManagerConnection source)
			: base(source)
		{
			isunlink = true;
			bridgeState = BridgeStates.BRIDGE_STATE_UNLINK;
		}
	}
}