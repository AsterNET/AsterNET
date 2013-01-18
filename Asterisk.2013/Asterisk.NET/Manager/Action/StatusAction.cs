using System;

namespace Asterisk.NET.Manager.Action
{
	/// <summary>
	/// The StatusAction requests the state of all active channels.<br/>
	/// For each active channel a StatusEvent is generated. After the state of all
	/// channels has been reported a StatusCompleteEvent is generated.
	/// </summary>
	/// <seealso cref="Manager.event.StatusEvent" />
	/// <seealso cref="Manager.event.StatusCompleteEvent" />
	public class StatusAction : ManagerActionEvent
	{
		/// <summary>
		/// Get the name of this action, i.e. "Status".
		/// </summary>
		public override string Action
		{
			get { return "Status"; }
		}
		public override Type ActionCompleteEventClass()
		{
			return typeof(Event.StatusCompleteEvent);
		}
		
		/// <summary>
		/// Creates a new StatusAction.
		/// </summary>
		public StatusAction()
		{
		}
	}
}