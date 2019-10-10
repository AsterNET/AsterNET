using System.Threading;
using AsterNET.Manager.Action;
using AsterNET.Manager.Response;

namespace AsterNET.Manager
{
    /// <summary>
    ///     A simple response handler that stores the received response in a ResponseHandlerResult for further processing.
    /// </summary>
    public class ResponseHandler : IResponseHandler
    {
        private ManagerAction action;
        private AutoResetEvent autoEvent;
        private int hash;
        private ManagerResponse response;

        /// <summary>
        ///     Creates a new <see cref="ResponseHandler"/>.
        /// </summary>
        /// <param name="action"><see cref="ManagerAction"/></param>
        /// <param name="autoEvent"><see cref="AutoResetEvent"/></param>
        public ResponseHandler(ManagerAction action, AutoResetEvent autoEvent)
        {
            response = null;
            this.action = action;
            this.autoEvent = autoEvent;
        }

        /// <summary>
        ///     Gets the response.
        /// </summary>
        public ManagerResponse Response
        {
            get { return this.response; }
        }

        /// <summary>
        ///     Gets the action.
        /// </summary>
        public ManagerAction Action
        {
            get { return this.action; }
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
            autoEvent = null;
            action = null;
            response = null;
        }

        /// <summary>
        ///     This method is called when a response is received.
        /// </summary>
        /// <param name="response">the response received</param>
        public virtual void HandleResponse(ManagerResponse response)
        {
            this.response = response;
            if (autoEvent != null)
                this.autoEvent.Set();
        }
    }
}