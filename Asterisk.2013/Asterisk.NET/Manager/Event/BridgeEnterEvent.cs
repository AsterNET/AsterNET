using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     Raised when a channel enters a bridge.<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_BridgeEnter">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_BridgeEnter</see>
    /// </summary>
    public class BridgeEnterEvent : BridgeActivityEvent
    {
        /// <summary>
        ///     Creates a new <see cref="BridgeEnterEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        /// <param name="source"></param>
        public BridgeEnterEvent(ManagerConnection source) : base(source)
        {
        }
    }
}
