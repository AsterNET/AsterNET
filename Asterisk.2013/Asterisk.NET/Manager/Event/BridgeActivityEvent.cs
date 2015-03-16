using System;
using System.Collections.Generic;

namespace AsterNET.Manager.Event
{
	/// <summary>
	/// </summary>
	public abstract class BridgeActivityEvent : ManagerEvent
	{
        public string BridgeUniqueId { get; set; }
        public string BridgeType { get; set; }
        public string BridgeTechnology { get; set; }
        public string BridgeCreator { get; set; }
        public string BridgeName { get; set; }
        public string BridgeNumChannels { get; set; }
        public string ChannelState { get; set; }
        public string ChannelStatedDesc { get; set; }
        public string CallerIdNum { get; set; }
        public string CallerIdName { get; set; }
        public string ConnectedLineNum { get; set; }
        public string ConnectedLineName { get; set; }
        public string Language { get; set; }
        public string AccountCode { get; set; }
        public string Context { get; set; }
        public string Exten { get; set; }
        public string Priority { get; set; }

		#region Constructors
        protected BridgeActivityEvent(ManagerConnection source)
            : base(source)
		{
		}
		#endregion
	}
}
