using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsterNET.Manager.Event
{
    public class FailedACLEvent : ManagerEvent
    {

        public FailedACLEvent()
            : base() { }

        public FailedACLEvent(ManagerConnection source)
            : base(source) { }

        public string LocalAddress { get; set; }
        public string RemoteAddress { get; set; }
        public string ACLName { get; set; }

    }
}
