using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     Raised when a channel leaves a bridge.
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_BridgeLeave">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_BridgeLeave</see>
    /// </summary>
    public class BridgeLeaveEvent : BridgeActivityEvent
    {
        /// <summary>
        ///     Creates a new <see cref="BridgeLeaveEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        /// <param name="source"></param>
        public BridgeLeaveEvent(ManagerConnection source) : base(source)
        {
        }
    }
}
