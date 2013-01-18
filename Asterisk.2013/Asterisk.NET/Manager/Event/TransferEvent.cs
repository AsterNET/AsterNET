using System;
using System.Collections.Generic;
using System.Text;

namespace Asterisk.NET.Manager.Event
{
	public class TransferEvent : ManagerEvent
	{
		private string transferMethod;
		private string transferExten;
		private string transferType;
		private string sipCallId;
		private string targetChannel;
		private string targetUniqueId;
		private string transferContext;
		private bool transfer2Parking;

		/// <summary>
		/// SIP, 
		/// </summary>
		public string TransferMethod
		{
			get { return this.transferMethod; }
			set { this.transferMethod = value; }
		}
		public string TransferExten
		{
			get { return this.transferExten; }
			set { this.transferExten = value; }
		}

		/// <summary>
		/// Blind,
		/// Attended
		/// </summary>
		public string TransferType
		{
			get { return this.transferType; }
			set { this.transferType = value; }
		}
		public string SipCallId
		{
			get { return this.sipCallId; }
			set { this.sipCallId = value; }
		}
		public string TargetUniqueId
		{
			get { return this.targetUniqueId; }
			set { this.targetUniqueId = value; }
		}
		public string TargetChannel
		{
			get { return this.targetChannel; }
			set { this.targetChannel = value; }
		}
		public string TransferContext
		{
			get { return this.transferContext; }
			set { this.transferContext = value; }
		}

		public bool Transfer2Parking
		{
			get { return this.transfer2Parking; }
			set { this.transfer2Parking = value; }
		}

		#region Constructor - TransferEvent(ManagerConnection source)
		public TransferEvent(ManagerConnection source)
			: base(source)
		{
		}
		#endregion
	}
}
