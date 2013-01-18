using System;

namespace Asterisk.NET.Manager.Event
{
	public class JitterBufStatsEvent : ManagerEvent
	{
		private string owner;
		private int ping;
		private int localJitter;
		private int localJBDelay;
		private int localTotalLost;
		private int localLossPercent;
		private int localDropped;
		private int localooo;
		private int localReceived;
		private int remoteJitter;
		private int remoteJBDelay;
		private int remoteTotalLost;
		private int remoteLossPercent;
		private int remoteDropped;
		private int remoteooo;
		private int remoteReceived;

		public string Owner
		{
			get { return this.owner; }
			set { this.owner = value; }
		}
		public int Ping
		{
			get { return this.ping; }
			set { this.ping = value; }
		}
		public int LocalJitter
		{
			get { return this.localJitter; }
			set { this.localJitter = value; }
		}
		public int LocalJBDelay
		{
			get { return this.localJBDelay; }
			set { this.localJBDelay = value; }
		}
		public int LocalTotalLost
		{
			get { return this.localTotalLost; }
			set { this.localTotalLost = value; }
		}
		public int LocalLossPercent
		{
			get { return this.localLossPercent; }
			set { this.localLossPercent = value; }
		}
		public int LocalDropped
		{
			get { return this.localDropped; }
			set { this.localDropped = value; }
		}
		public int Localooo
		{
			get { return this.localooo; }
			set { this.localooo = value; }
		}
		public int LocalReceived
		{
			get { return this.localReceived; }
			set { this.localReceived = value; }
		}
		public int RemoteJitter
		{
			get { return this.remoteJitter; }
			set { this.remoteJitter = value; }
		}
		public int RemoteJBDelay
		{
			get { return this.remoteJBDelay; }
			set { this.remoteJBDelay = value; }
		}
		public int RemoteTotalLost
		{
			get { return this.remoteTotalLost; }
			set { this.remoteTotalLost = value; }
		}
		public int RemoteLossPercent
		{
			get { return this.remoteLossPercent; }
			set { this.remoteLossPercent = value; }
		}
		public int RemoteDropped
		{
			get { return this.remoteDropped; }
			set { this.remoteDropped = value; }
		}
		public int Remoteooo
		{
			get { return this.remoteooo; }
			set { this.remoteooo = value; }
		}
		public int RemoteReceived
		{
			get { return this.remoteReceived; }
			set { this.remoteReceived = value; }
		}

		public JitterBufStatsEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}
