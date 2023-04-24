using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     Raised when a bridge is destroyed.<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_BridgeDestroy">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_BridgeDestroy</see>
    /// </summary>
    public class BridgeDestroyEvent : BridgeStateEvent
    {
        /// <summary>
        ///     Creates a new <see cref="BridgeDestroyEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public BridgeDestroyEvent(ManagerConnection source) : base(source)
        {
        }
    }
}
