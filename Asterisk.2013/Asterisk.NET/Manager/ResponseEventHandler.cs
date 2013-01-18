using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Asterisk.NET.Manager.Action;
using Asterisk.NET.Manager.Event;
using Asterisk.NET.Manager.Response;

namespace Asterisk.NET.Manager
{
	/// <summary>
	/// A combinded event and response handler that adds received events and the response to a ResponseEvents object.
	/// </summary>
	public class ResponseEventHandler : IResponseHandler
	{
		private ManagerConnection connection;
		private AutoResetEvent autoEvent;
		private ResponseEvents events;
		private ManagerActionEvent action;
		private int hash;

		/// <summary>
		/// Creates a new instance.
		/// </summary>
		/// <param name="events">the ResponseEvents to store the events in</param>
		/// <param name="actionCompleteEventClass">the type of event that indicates that all events have been received</param>
		/// <param name="thread">the thread to interrupt when the actionCompleteEventClass has been received</param>
		public ResponseEventHandler(ManagerConnection connection, ManagerActionEvent action, AutoResetEvent autoEvent)
		{
			this.connection = connection;
			this.events = new ResponseEvents();
			this.action = action;
			this.autoEvent = autoEvent;
		}

		public ManagerAction Action
		{
			get { return action; }
		}

		public ResponseEvents ResponseEvents
		{
			get { return events; }
		}

		public int Hash
		{
			get { return hash; }
			set { hash = value; }
		}

		public void Free()
		{
			connection = null;
			autoEvent = null;
			action = null;
			events.Events.Clear();
			events.Response = null;
			events = null;
		}

		public void HandleEvent(ManagerEvent e)
		{
			// should always be a ResponseEvent, anyway...
			if (e is Event.ResponseEvent)
			{
				ResponseEvent responseEvent = (ResponseEvent)e;
				events.AddEvent(responseEvent);
			}

			// finished?
			if (action.ActionCompleteEventClass().IsAssignableFrom(e.GetType()))
			{
				lock (events)
					events.Complete = true;
				if (events.Response != null)
					autoEvent.Set();
			}
		}

		public void HandleResponse(ManagerResponse response)
		{
			events.Response = response;
			if (response is ManagerError)
				events.Complete = true;

			if (events.Complete && autoEvent != null)
				autoEvent.Set();
		}
	}
}
