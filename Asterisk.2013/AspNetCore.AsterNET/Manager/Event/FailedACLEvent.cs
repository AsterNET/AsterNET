using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// </summary>

namespace AspNetCore.AsterNET.Manager.Event
{
    public class FailedACLEvent : ManagerEvent
    {

        public FailedACLEvent()
            : base() { }

        public FailedACLEvent(ManagerConnection source)
            : base(source) { }

        /// <summary>
        /// <b>Available since : </b> <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+12+Documentation" target="_blank" alt="Asterisk 12 wiki docs">Asterisk 12</see>.
        /// </summary>
        public string LocalAddress { get; set; }
        /// <summary>
        /// <b>Available since : </b> <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+12+Documentation" target="_blank" alt="Asterisk 12 wiki docs">Asterisk 12</see>.
        /// </summary>
        public string RemoteAddress { get; set; }
        /// <summary>
        /// <b>Available since : </b> <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+12+Documentation" target="_blank" alt="Asterisk 12 wiki docs">Asterisk 12</see>.
        /// </summary>
        public string ACLName { get; set; }

    }
}
