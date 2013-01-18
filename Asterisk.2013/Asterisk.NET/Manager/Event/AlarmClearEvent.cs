namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// An AlarmEvent is triggered when a Zap channel leaves alarm state.<br/>
	/// It is implemented in <code>channels/chan_zap.c</code>
	/// </summary>
	public class AlarmClearEvent : ManagerEvent
	{
		public AlarmClearEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}