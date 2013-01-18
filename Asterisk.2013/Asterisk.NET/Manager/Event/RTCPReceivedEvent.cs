using System;
using System.Collections.Generic;
using System.Text;

namespace Asterisk.NET.Manager.Event
{
	public class RTCPReceivedEvent : ManagerEvent
	{
		private string from;
		private string pt;
		private int receptionReports;
		private long senderSSRC;
		private long fractionLost;
		private int packetsLost;
		private long highestSequence;
		private int sequenceNumberCycles;
		private long iaJitter;
		private string lastSR;
		private string dlsr;
		private string rtt;

		public string From
		{
			get { return this.from; }
			set { this.from = value; }
		}

		public int SequenceNumberCycles
		{
			get { return this.sequenceNumberCycles; }
			set { this.sequenceNumberCycles = value; }
		}
		public string RTT
		{
			get { return this.rtt; }
			set { this.rtt = value; }
		}

		public long IAJitter
		{
			get { return this.iaJitter; }
			set { this.iaJitter = value; }
		}
		public string PT
		{
			get { return this.pt; }
			set { this.pt = value; }
		}
		public int ReceptionReports
		{
			get { return this.receptionReports; }
			set { this.receptionReports = value; }
		}
		public string LastSR
		{
			get { return this.lastSR; }
			set { this.lastSR = value; }
		}
		public string DLSR
		{
			get { return this.dlsr; }
			set { this.dlsr = value; }
		}
		public long FractionLost
		{
			get { return this.fractionLost; }
			set { this.fractionLost = value; }
		}
		public long SenderSSRC
		{
			get { return this.senderSSRC; }
			set { this.senderSSRC = value; }
		}
		public long HighestSequence
		{
			get { return this.highestSequence; }
			set { this.highestSequence = value; }
		}
		public int PacketsLost
		{
			get { return this.packetsLost; }
			set { this.packetsLost = value; }
		}

		#region Constructor - RTCPReceivedEvent(ManagerConnection source)
		public RTCPReceivedEvent(ManagerConnection source)
			: base(source)
		{ }
		#endregion

	}
}
