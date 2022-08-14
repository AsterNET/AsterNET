using System;
using AsterNET.Manager.Event;

namespace AsterNET.Manager.Action
{
    /// <seealso cref="Manager.Event.EndpointDetailCompleteEvent" />
    public class PJSIPShowEndpointAction : ManagerActionEvent
    {
        public PJSIPShowEndpointAction()
        {
        }

        public PJSIPShowEndpointAction(string endpoint)
        {
            this.Endpoint = "PJSIP/" + endpoint;
        }

        public override string Action
        {
            get { return "PJSIPShowEndpoint"; }
        }

        public string Endpoint { get; set; }

        public override Type ActionCompleteEventClass()
        {
            return typeof (EndpointDetailCompleteEvent);
        }
    }
}