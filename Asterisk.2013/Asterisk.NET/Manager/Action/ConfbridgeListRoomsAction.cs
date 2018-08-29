using System;
using AsterNET.Manager.Event;

namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     Lists data about all active conferences. ConfbridgeListRooms will follow as separate events,
    ///     followed by a final event called ConfbridgeListRoomsComplete.
    /// </summary>
    public class ConfbridgeListRoomsAction : ManagerActionEvent
    {
        public override string Action
        {
            get { return "ConfbridgeListRooms"; }
        }

        public override Type ActionCompleteEventClass()
        {
            return typeof (ConfbridgeListRoomsCompleteEvent);
        }
    }
}