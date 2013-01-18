using System;
using System.Text;

namespace Asterisk.NET.Manager.Response
{
	public class OriginateResponse
	{
		private string uniqueId;
		private int reason;
		private string channel;
		private string channelName;
		private string response;

		private DateTime startTime;
		private DateTime endTime = DateTime.MinValue;

		#region IsSuccess 
		public bool IsSuccess
		{
			get { return response == "Success"; }
		}
		#endregion

		#region UniqueId
		public string UniqueId
		{
			get { return uniqueId; }
			set { this.uniqueId = value; }
		}
		#endregion

		#region Channel
		public string Channel
		{
			get { return channel; }
			set { this.channel = value; }
		}
		#endregion

		#region ChannelName
		public string ChannelName
		{
			get { return channelName; }
			set { this.channelName = value; }
		}
		#endregion

		#region Reason 
		public int Reason
		{
			get { return reason; }
			set { this.reason = value; }
		}
		#endregion

		#region Response 
		public string Response
		{
			get { return response; }
			set { response = value; }
		}
		#endregion

		#region StartTime
		public DateTime StartTime
		{
			get { return startTime; }
			set { this.startTime = value; }
		}
		#endregion

		#region EndTime
		public DateTime EndTime
		{
			get { return endTime; }
			set { this.endTime = value; }
		}
		#endregion

		#region Constructor - Call()
		public OriginateResponse()
		{
			startTime = DateTime.Now;
		}
		#endregion

		#region CalcDuration()
		/// <summary>
		/// Return the duration of the call in milliseconds. If the call is has not
		/// ended, the duration so far is calculated.
		/// </summary>
		public long CalcDuration()
		{
			DateTime compTime;
			if (endTime != DateTime.MinValue)
				compTime = endTime;
			else
				compTime = DateTime.Now;
			return (compTime.Ticks - startTime.Ticks) / 10000;
		}
		#endregion

		#region ToString()
		public override string ToString()
		{
			return Helper.ToString(this);
		}
		#endregion
	}
}