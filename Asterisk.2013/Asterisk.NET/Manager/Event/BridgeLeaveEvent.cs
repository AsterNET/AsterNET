﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     Raised when a channel leaves a bridge.<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_BridgeLeave">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_BridgeLeave</see>
    /// </summary>
    public class BridgeLeaveEvent : BridgeActivityEvent
    {
        /// <summary>
        ///     Creates a new <see cref="BridgeLeaveEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public BridgeLeaveEvent(ManagerConnection source) : base(source)
        {
        }
    }
}
