using System.Collections;
using Asterisk.NET.Manager.Response;
using Asterisk.NET.Manager.Event;
using System.Collections.Generic;

namespace Asterisk.NET.Manager
{
	/// <summary>
	/// Collection of ResponseEvent. Use in events generation actions.
	/// </summary>
	public class ResponseEvents
	{
		private ManagerResponse response;
		private List<ResponseEvent> events;
		private bool complete;

		public ManagerResponse Response
		{
			get { return this.response; }
			set { this.response = value; }
		}

		public List<ResponseEvent> Events
		{
			get { return events; }
		}
		/// <summary>
		/// Indicats if all events have been received.
		/// </summary>
		public bool Complete
		{
			get { return this.complete; }
			set { this.complete = value; }
		}

		/// <summary> Creates a new instance.</summary>
		public ResponseEvents()
		{
			this.events = new List<ResponseEvent>();
			this.complete = false;
		}
		
		/// <summary>
		/// Adds a ResponseEvent that has been received.
		/// </summary>
		/// <param name="e">the ResponseEvent that has been received.</param>
		public void AddEvent(ResponseEvent e)
		{
			lock (((IList)events).SyncRoot)
			{
				events.Add(e);
			}
		}
	}
}