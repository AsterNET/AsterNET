using System.Threading;
using AsterNET.Manager.Action;
using AsterNET.Manager.Event;
using AsterNET.Manager.Response;

namespace AsterNET.Manager
{
    /// <summary>
    ///     A combined event and response handler that adds received events and the response to a ResponseEvents object.
    /// </summary>
    public class ResponseEventHandler : IResponseHandler
    {
        private ManagerActionEvent action;
        private AutoResetEvent autoEvent;
        private ManagerConnection connection;
        private ResponseEvents events;
        private int hash;

        /// <summary>
        ///     Creates a new instance<see cref="ResponseEventHandler"/>.
        /// </summary>
        /// <param name="connection"><see cref="ManagerConnection"/></param>
        /// <param name="action"><see cref="ManagerActionEvent"/></param>
        /// <param name="autoEvent"><see cref="AutoResetEvent"/></param>
        public ResponseEventHandler(ManagerConnection connection, ManagerActionEvent action, AutoResetEvent autoEvent)
        {
            this.connection = connection;
            this.events = new ResponseEvents();
            this.action = action;
            this.autoEvent = autoEvent;
        }

        /// <summary>
        ///     Gets the response events.
        /// </summary>
        public ResponseEvents ResponseEvents
        {
            get { return events; }
        }

        /// <summary>
        ///     Gets the action.
        /// </summary>
        public ManagerAction Action
        {
            get { return action; }
        }

        /// <summary>
        ///     Gets or sets the hash.
        /// </summary>
        public int Hash
        {
            get { return hash; }
            set { hash = value; }
        }

        /// <summary>
        ///     Frees this instance.
        /// </summary>
        public void Free()
        {
            connection = null;
            autoEvent = null;
            action = null;
            events.Events.Clear();
            events.Response = null;
            events = null;
        }

        /// <summary>
        ///     This method is called when a response is received.
        /// </summary>
        /// <param name="response"><see cref="ManagerResponse"/></param>
        public void HandleResponse(ManagerResponse response)
        {
            events.Response = response;
            if (response is ManagerError)
                events.Complete = true;

            if (events.Complete && autoEvent != null)
                autoEvent.Set();
        }

        /// <summary>
        ///     Handles the event.
        /// </summary>
        /// <param name="e"><see cref="ManagerEvent"/></param>
        public void HandleEvent(ManagerEvent e)
        {
            // should always be a ResponseEvent, anyway...
            if (e is ResponseEvent)
            {
                var responseEvent = (ResponseEvent) e;
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
    }
}