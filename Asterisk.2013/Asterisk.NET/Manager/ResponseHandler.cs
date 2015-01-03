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
        ///     Creates a new instance.
        /// </summary>
        /// <param name="result">the result to store the response in</param>
        /// <param name="thread">the thread to interrupt when the response has been received</param>
        public ResponseHandler(ManagerAction action, AutoResetEvent autoEvent)
        {
            response = null;
            this.action = action;
            this.autoEvent = autoEvent;
        }

        public ManagerResponse Response
        {
            get { return this.response; }
        }

        public ManagerAction Action
        {
            get { return this.action; }
        }

        public int Hash
        {
            get { return hash; }
            set { hash = value; }
        }

        public void Free()
        {
            autoEvent = null;
            action = null;
            response = null;
        }

        public virtual void HandleResponse(ManagerResponse response)
        {
            this.response = response;
            if (autoEvent != null)
                this.autoEvent.Set();
        }
    }
}