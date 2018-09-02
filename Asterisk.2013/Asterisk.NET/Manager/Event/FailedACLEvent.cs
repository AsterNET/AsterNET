using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     Raised when a request violates an ACL check.<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_FailedACL">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_FailedACL</see>
    /// </summary>
    public class FailedACLEvent : ManagerEvent
    {
        /// <summary>
        ///     Creates a new empty <see cref="FailedACLEvent"/>.
        /// </summary>
        public FailedACLEvent()
            : base() { }

        /// <summary>
        ///     Creates a new <see cref="FailedACLEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        /// <param name="source"></param>
        public FailedACLEvent(ManagerConnection source)
            : base(source) { }

        /// <summary>
        ///     <b>Available since : </b> <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+12+Documentation" target="_blank" alt="Asterisk 12 wiki docs">Asterisk 12</see>.
        /// </summary>
        public string LocalAddress { get; set; }
        /// <summary>
        ///     <b>Available since : </b> <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+12+Documentation" target="_blank" alt="Asterisk 12 wiki docs">Asterisk 12</see>.
        /// </summary>
        public string RemoteAddress { get; set; }
        /// <summary>
        ///     <b>Available since : </b> <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+12+Documentation" target="_blank" alt="Asterisk 12 wiki docs">Asterisk 12</see>.
        /// </summary>
        public string ACLName { get; set; }

    }
}
