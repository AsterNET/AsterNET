using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsterNET.Manager.Action
{

    /// <summary>
    /// Lists data about all active conferences. ConfbridgeListRooms will follow as separate events, 
    /// followed by a final event called ConfbridgeListRoomsComplete.
    /// </summary>
    public class ConfbridgeListRoomsAction : ManagerActionEvent
    {

        public override string Action
		{
            get { return "ConfbridgeListRooms"; }
		}
		public override Type ActionCompleteEventClass()
		{
			return typeof(Event.ConfbridgeListRoomsCompleteEvent);
		}
		
		/// <summary>
        /// Lists data about all active conferences. ConfbridgeListRooms will follow as separate events, 
        /// followed by a final event called ConfbridgeListRoomsComplete.
		/// </summary>
        public ConfbridgeListRoomsAction()
		{
		}
    }
}
