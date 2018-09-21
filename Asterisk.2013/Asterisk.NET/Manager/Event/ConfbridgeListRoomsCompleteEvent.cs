using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     An ConfbridgeListRoomsCompleteEvent is triggered after the state of all ConfBridgeRooms has been reported in response to an ConfbridgeListRoomsAction.<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/ConfBridge+AMI+Actions">https://wiki.asterisk.org/wiki/display/AST/ConfBridge+AMI+Actions</see>
    /// </summary>
    /// <seealso cref="ConfbridgeListRoomsEvent" />
    public class ConfbridgeListRoomsCompleteEvent : ResponseEvent
    {
        /// <summary>
        ///     Creates a new <see cref="ConfbridgeListRoomsCompleteEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public ConfbridgeListRoomsCompleteEvent(ManagerConnection source)
			: base(source)
		{
		}
    }
}
