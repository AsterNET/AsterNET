using System;
using System.Collections.Generic;
using System.Text;

namespace Asterisk.NET.Manager.Event
{
	public class RTCPSentEvent : ManagerEvent
	{
		private string to;
		private long ourSSRC;
		private string sentNTP;
		private long sentRTP;
		private long sentPackets;
		private long sentOctets;
		private long reportBlock;
		private long fractionLost;
		private long cumulativeLoss;
		private double iaJitter;
		private long theirLastSr;
		private string dlsr;

		public string To
		{
			get { return this.to; }
			set { this.to = value; }
		}

		public long CumulativeLoss
		{
			get { return this.cumulativeLoss; }
			set { this.cumulativeLoss = value; }
		}
		public string SentNtp
		{
			get { return this.sentNTP; }
			set { this.sentNTP = value; }
		}
		public long SentRtp
		{
			get { return this.sentRTP; }
			set { this.sentRTP = value; }
		}
		public double IAJitter
		{
			get { return this.iaJitter; }
			set { this.iaJitter = value; }
		}
		public long SentPackets
		{
			get { return this.sentPackets; }
			set { this.sentPackets = value; }
		}
		public long SentOctets
		{
			get { return this.sentOctets; }
			set { this.sentOctets = value; }
		}

		public long ReportBlock
		{
			get { return this.reportBlock; }
			set { this.reportBlock = value; }
		}

		public long FractionLost
		{
			get { return this.fractionLost; }
			set { this.fractionLost = value; }
		}
		public long OursSrc
		{
			get { return this.ourSSRC; }
			set { this.ourSSRC = value; }
		}
		public string DlSr
		{
			get { return this.dlsr; }
			set { this.dlsr = value; }
		}
		public long TheirLastSr
		{
			get { return this.theirLastSr; }
			set { this.theirLastSr = value; }
		}

		#region Constructor - RTCPSentEvent(ManagerConnection source)
		public RTCPSentEvent(ManagerConnection source)
			: base(source)
		{
		}
		#endregion
	}
}
