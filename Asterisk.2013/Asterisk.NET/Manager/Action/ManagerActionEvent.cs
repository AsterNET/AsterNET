using System;

namespace Asterisk.NET.Manager.Action
{
	/// <summary>
	/// The ManagerActionEvent is implemented by ManagerActions that
	/// return their result not in a ManagerResponse but by sending a series of events.<br/>
	/// The event type that indicates that Asterisk is finished is returned by the
	/// ActionCompleteEventClass property.
	/// </summary>
	/// <seealso cref="Asterisk.NET.Manager.Event.ResponseEvent"/>
	public abstract class ManagerActionEvent : ManagerAction
	{
		/// <summary>
		/// Returns the event type that indicates that Asterisk is finished sending response events for this action.
		/// </summary>
		/// <seealso cref="Asterisk.NET.Manager.Event.ResponseEvent"/>
		public abstract Type ActionCompleteEventClass();
	}
}