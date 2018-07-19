namespace AspNetCore.AsterNET.Manager.Event
{
	/// <summary>
	/// A ParkedCallTimeOutEvent is triggered when call parking times out for a given channel.<br/>
	/// It is implemented in res/res_features.c<br/>
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