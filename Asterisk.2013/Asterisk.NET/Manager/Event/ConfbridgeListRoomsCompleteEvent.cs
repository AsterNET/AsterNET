using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     Raised after all <see cref="ConfbridgeListRoomsEvent"/> are complete.<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/ConfBridge+AMI+Actions#ConfBridgeAMIActions-ConfbridgeListRooms">https://wiki.asterisk.org/wiki/display/AST/ConfBridge+AMI+Actions#ConfBridgeAMIActions-ConfbridgeListRooms</see>
    /// </summary>
    /// <seealso cref="Manager.Action.ConfbridgeListRoomsAction"/>
    /// <seealso cref="Manager.Event.ConfbridgeListRoomsEvent"/>
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
