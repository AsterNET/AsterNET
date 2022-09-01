using System;

namespace AsterNET.Manager.Response
{
    public class OriginateResponse : ManagerResponse
    {
        private string channel;
        private string channelName;
        private DateTime endTime = DateTime.MinValue;
        private int reason;

        private DateTime startTime;

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

        public OriginateResponse() : base()
        {
            startTime = DateTime.Now;
        }

        #endregion

        #region CalcDuration()

        /// <summary>
        ///     Return the duration of the call in milliseconds. If the call is has not
        ///     ended, the duration so far is calculated.
        /// </summary>
        public long CalcDuration()
        {
            DateTime compTime;
            if (endTime != DateTime.MinValue)
                compTime = endTime;
            else
                compTime = DateTime.Now;
            return (compTime.Ticks - startTime.Ticks)/10000;
        }

        #endregion
    }
}