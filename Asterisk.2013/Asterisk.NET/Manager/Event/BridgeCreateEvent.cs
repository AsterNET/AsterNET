using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     Raised when a bridge is created.<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_BridgeCreate">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_BridgeCreate</see>
    /// </summary>
    public class BridgeCreateEvent : BridgeStateEvent
    {
        /// <summary>
        ///     Creates a new <see cref="BridgeCreateEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public BridgeCreateEvent(ManagerConnection source) : base(source)
        {
        }
    }
}
