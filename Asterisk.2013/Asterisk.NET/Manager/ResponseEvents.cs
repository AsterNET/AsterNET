using System.Collections;
using System.Collections.Generic;
using AsterNET.Manager.Event;
using AsterNET.Manager.Response;

namespace AsterNET.Manager
{
    /// <summary>
    ///     Collection of ResponseEvent. Use in events generation actions.
    /// </summary>
    public class ResponseEvents
    {
        private readonly List<ResponseEvent> events;

        /// <summary> Creates a new instance.</summary>
        public ResponseEvents()
        {
            events = new List<ResponseEvent>();
            Complete = false;
        }

        public ManagerResponse Response { get; set; }

        public List<ResponseEvent> Events
        {
            get { return events; }
        }

        /// <summary>
        ///     Indicats if all events have been received.
        /// </summary>
        public bool Complete { get; set; }

        /// <summary>
        ///     Adds a ResponseEvent that has been received.
        /// </summary>
        /// <param name="e">the ResponseEvent that has been received.</param>
        public void AddEvent(ResponseEvent e)
        {
            lock (((IList) events).SyncRoot)
            {
                events.Add(e);
            }
        }
    }
}