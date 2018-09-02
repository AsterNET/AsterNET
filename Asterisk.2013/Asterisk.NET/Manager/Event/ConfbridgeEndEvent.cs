using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     Raised when a conference ends.<br />
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_ConfbridgeEnd">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_ConfbridgeEnd</see>
    /// </summary>
    public class ConfbridgeEndEvent : AbstractConfbridgeEvent
    {
        /// <summary>
        ///     Creates a new <see cref="ConfbridgeEndEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public ConfbridgeEndEvent(ManagerConnection source)
			: base(source)
		{
		}
    }
}
