using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     Raised when a channel joins a Confbridge conference.<br />
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_ConfbridgeJoin">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_ConfbridgeJoin</see>
    /// </summary>
    public class ConfbridgeJoinEvent : AbstractConfbridgeEvent
    {
        /// <summary>
        ///     Gets or sets the Caller*ID number.
        /// </summary>
        public string CallerIDnum { get; set; }

        /// <summary>
        ///     Gets or sets the Caller*ID name.
        /// </summary>
        public string CallerIDname { get; set; }

        /// <summary>
        ///     Creates a new <see cref="ConfbridgeJoinEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public ConfbridgeJoinEvent(ManagerConnection source)
			: base(source)
		{
		}
    }
}
