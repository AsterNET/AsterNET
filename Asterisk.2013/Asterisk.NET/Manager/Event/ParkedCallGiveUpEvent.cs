namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A ParkedCallGiveUpEvent is triggered when a channel that has been parked is hung up.<br/>
	/// It is implemented in <code>res/res_features.c</code><br/>
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