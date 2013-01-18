using System;
using System.Collections.Generic;
using System.Text;

namespace Asterisk.NET.Manager.Event
{
	public class RTPSenderStatEvent : ManagerEvent
	{
		private long ssrc;
		private long sentPackets;
		private long lostPackets;
		private long jitter;
		private long srCount;
		private double rtt;


		public long SSRC
		{
			get { return this.ssrc; }
			set { this.ssrc = value; }
		}
		public long SentPackets
		{
			get { return this.sentPackets; }
			set { this.sentPackets = value; }
		}
		public long LostPackets
		{
			get { return this.lostPackets; }
			set { this.lostPackets = value; }
		}
		public long SRCount
		{
			get { return this.srCount; }
			set { this.srCount = value; }
		}
		public long Jitter
		{
			get { return this.jitter; }
			set { this.jitter = value; }
		}
		public double RTT
		{
			get { return this.rtt; }
			set { this.rtt = value; }
		}

		#region Constructor - RTPSenderStatEvent(ManagerConnection source)
		public RTPSenderStatEvent(ManagerConnection source)
			: base(source)
		{
		}
		#endregion
	}
}
