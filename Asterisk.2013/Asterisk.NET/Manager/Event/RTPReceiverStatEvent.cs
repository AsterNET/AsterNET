using System;
using System.Collections.Generic;
using System.Text;

namespace Asterisk.NET.Manager.Event
{
	public class RTPReceiverStatEvent : ManagerEvent
	{
		private long ssrc;
		private long receivedPackets;
		private long lostPackets;
		private double jitter;
		private double transit;
		private long rrCount;

		public double Transit
		{
			get { return this.transit; }
			set { this.transit = value; }
		}
		public long LostPackets
		{
			get { return this.lostPackets; }
			set { this.lostPackets = value; }
		}
		public long RRCount
		{
			get { return this.rrCount; }
			set { this.rrCount = value; }
		}
		public long ReceivedPackets
		{
			get { return this.receivedPackets; }
			set { this.receivedPackets = value; }
		}
		public double Jitter
		{
			get { return this.jitter; }
			set { this.jitter = value; }
		}
		public long SSRC
		{
			get { return this.ssrc; }
			set { this.ssrc = value; }
		}

		#region Constructor - RTPReceiverStatEvent(ManagerConnection source)
		public RTPReceiverStatEvent(ManagerConnection source)
			: base(source)
		{
		}
		#endregion
	}
}
