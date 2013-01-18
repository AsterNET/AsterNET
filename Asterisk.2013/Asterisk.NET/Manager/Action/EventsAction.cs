using System;

namespace Asterisk.NET.Manager.Action
{
	/// <summary>
	/// With the EventsAction you can specify what kind of events should be sent to this manager connection.
	/// </summary>
	public class EventsAction : ManagerAction
	{
		private string eventMask;

		/// <summary>
		/// Get the name of this action, i.e. "Events".
		/// </summary>
		override public string Action
		{
			get { return "Events"; }
		}
		/// <summary>
		/// Get/Set the event mask.<br/>
		/// Set to "on" if all events should be send, "off" if not events should be
		/// sent or a combination of "system", "call" and "log" (separated by ',') to
		/// specify what kind of events should be sent.
		/// </summary>
		public string EventMask
		{
			get { return this.eventMask; }
			set { this.eventMask = value; }
		}
		
		/// <summary>
		/// Creates a new empty EventsAction.
		/// </summary>
		public EventsAction()
		{
		}
		
		/// <summary>
		/// Creates a new EventsAction that applies the given event mask to the current manager connection.
		/// </summary>
		/// <param name="eventMask">the event mask.<br/>
		/// Set to "on" if all events should be send, "off" if not events should be sent
		/// or a combination of "system", "call" and "log" (separated by ',') to specify what kind of events should be sent.
		/// </param>
		public EventsAction(string eventMask)
		{
			this.eventMask = eventMask;
		}
	}
}