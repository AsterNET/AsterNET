using System;
using System.Collections.Generic;

namespace AsterNET.Manager.Event
{
	/// <summary>
	/// </summary>
	public abstract class BridgeStateEvent : ManagerEvent
	{
        public string BridgeUniqueId { get; set; }
        public string BridgeType { get; set; }
        public string BridgeTechnology { get; set; }
        public string BridgeCreator { get; set; }
        public string BridgeName { get; set; }
        public int BridgeNumChannels { get; set; }

		#region Constructors
        protected BridgeStateEvent(ManagerConnection source)
            : base(source)
		{
		}
		#endregion
	}
}
