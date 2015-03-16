using System;
using System.Collections.Generic;
using System.Text;

namespace AsterNET.Manager.Event
{
	public class AttendedTransferEvent : ManagerEvent
	{
        public bool Result { get; set; }
        public string OrigTransfererChannel { get; set; }
        public string OrigTransfererChannelState { get; set; }
        public string OrigTransfererChannelStatedesc { get; set; }
        public string OrigTransfererCalleridNum { get; set; }
        public string OrigTransfererCalleridName { get; set; }
        public string OrigTransfererConnectedLineNum { get; set; }
        public string OrigTransfererConnectedLineName { get; set; }
        public string OrigTransfererLanguage { get; set; }
        public string OrigTransfererAccountCode { get; set; }
        public string OrigTransfererContext { get; set; }
        public string OrigTransfererPriority { get; set; }
        public string OrigTransfererUniqueId { get; set; }
        public string OrigBridgeUniqueId { get; set; }
        public string OrigBridgeType { get; set; }
        public string OrigBridgetechnology { get; set; }
        public string OrigBridgeCreator { get; set; }
        public string OrigBridgeName { get; set; }
        public string OrigBridgeNumChannels { get; set; }

        public string SecondTransfererChannel { get; set; }
        public string SecondTransfererChannelState { get; set; }
        public string SecondTransfererChannelStatedesc { get; set; }
        public string SecondTransfererCalleridNum { get; set; }
        public string SecondTransfererCalleridName { get; set; }
        public string SecondTransfererConnectedLineNum { get; set; }
        public string SecondTransfererConnectedLineName { get; set; }
        public string SecondTransfererLanguage { get; set; }
        public string SecondTransfererAccountCode { get; set; }
        public string SecondTransfererContext { get; set; }
        public string SecondTransfererExten { get; set; }
        public string SecondTransfererPriority { get; set; }
        public string SecondTransfererUniqueId { get; set; }

        public string SecondBridgeUniqueId { get; set; }
        public string SecondBridgeType { get; set; }
        public string SecondBridgeTechnology { get; set; }
        public string SecondBridgeCreator { get; set; }
        public string SecondBridgeName { get; set; }
        public string SecondBridgeNumChannels { get; set; }

        public string TransfereeChannel { get; set; }
        public string TransfereeChannelState { get; set; }
        public string TransfereeChannelStatedesc { get; set; }
        public string TransfereeCalleridNum { get; set; }
        public string TransfereeCalleridName { get; set; }
        public string TransfereeConnectedLineNum { get; set; }
        public string TransfereeConnectedLineName { get; set; }
        public string TransfereeLanguage { get; set; }
        public string TransfereeAccountCode { get; set; }
        public string TransfereeContext { get; set; }
        public string TransfereeExten { get; set; }
        public string TransfereePriority { get; set; }
        public string TransfereeUniqueId { get; set; }

        public string TransferTargetChannel { get; set; }
        public string TransferTargetChannelState { get; set; }
        public string TransferTargetChannelStatedesc { get; set; }
        public string TransferTargetCalleridNum { get; set; }
        public string TransferTargetCalleridName { get; set; }
        public string TransferTargetConnectedLineNum { get; set; }
        public string TransferTargetConnectedLineName { get; set; }
        public string TransferTargetLanguage { get; set; }
        public string TransferTargetAccountCode { get; set; }
        public string TransferTargetContext { get; set; }
        public string TransferTargetPriority { get; set; }
        public string TransferTargetUniqueId { get; set; }

        public bool IsExternal { get; set; }
        public string DestType { get; set; }
        public string DestBridgeUniqueId { get; set; }

        #region Constructor - AttendedTransferEvent(ManagerConnection source)
        public AttendedTransferEvent(ManagerConnection source)
			: base(source)
		{
		}
		#endregion
	}
}
