namespace AsterNET.Manager.Event
{
	/// <summary>
	/// A ParkedCallGiveUpEvent is triggered when a channel that has been parked is hung up.<br/>
	/// It is implemented in res/res_features.c<br/>
	/// Available since Asterisk 1.2
	/// </summary>
	public class ParkedCallGiveUpEvent : AbstractParkedCallEvent
	{
		public ParkedCallGiveUpEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}