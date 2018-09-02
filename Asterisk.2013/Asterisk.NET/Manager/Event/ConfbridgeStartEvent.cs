using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     Raised when a conference starts.<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_ConfbridgeStart">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_ConfbridgeStart</see>
    /// </summary>
    public class ConfbridgeStartEvent : AbstractConfbridgeEvent
    {
        /// <summary>
        ///     Creates a new <see cref="ConfbridgeStartEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public ConfbridgeStartEvent(ManagerConnection source)
			: base(source)
		{
		}
    }
}
