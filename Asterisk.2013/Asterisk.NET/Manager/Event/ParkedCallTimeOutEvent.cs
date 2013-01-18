namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A ParkedCallTimeOutEvent is triggered when call parking times out for a given channel.<br/>
	/// It is implemented in <code>res/res_features.c</code><br/>
	/// Available since Asterisk 1.2
	/// </summary>
	public class ParkedCallTimeOutEvent : AbstractParkedCallEvent
	{
		public ParkedCallTimeOutEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}