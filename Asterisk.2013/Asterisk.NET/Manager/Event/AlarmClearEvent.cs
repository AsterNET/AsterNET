namespace AsterNET.Manager.Event
{
	/// <summary>
	/// An AlarmEvent is triggered when a Zap channel leaves alarm state.<br/>
	/// It is implemented in channels/chan_zap.c
	/// </summary>
	public class AlarmClearEvent : ManagerEvent
	{
		public AlarmClearEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}