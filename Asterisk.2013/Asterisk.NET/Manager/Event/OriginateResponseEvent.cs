using System;

namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     Raised in response to an Originate command.<br />
    ///     See <see target="_blank" href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_OriginateResponse">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_OriginateResponse</see>
    /// </summary>
    /// <seealso cref="Manager.Action.OriginateAction" />
    public class OriginateResponseEvent : ResponseEvent
	{
		private string response;
		private string context;
		private string exten;
		private int reason;
		private string callerIdNum;
		private string callerIdName;
		private string callerId;

        /// <summary>
        ///     Gets or sets the response.
        /// </summary>
        public string Response
		{
			get { return this.response; }
			set { this.response = value; }
		}

        /// <summary>
        ///     Gets or sets the context.
        /// </summary>
        public string Context
		{
			get { return this.context; }
			set { this.context = value; }
		}

        /// <summary>
        ///     Gets or sets the exten.
        /// </summary>
        public string Exten
		{
			get { return this.exten; }
			set { this.exten = value; }
		}

        /// <summary>
        ///     Gets or sets the reason.
        /// </summary>
        public int Reason
		{
			get { return this.reason; }
			set { this.reason = value; }
		}

        /// <summary>
        ///     Gets or sets the Caller*ID.
        /// </summary>
        public string CallerId
		{
			get { return callerId; }
			set { callerId = value; }
		}

        /// <summary>
        ///     Gets or sets the Caller*ID number.
        /// </summary>
        public string CallerIdNum
		{
			get { return this.callerIdNum; }
			set { this.callerIdNum = value; }
		}

        /// <summary>
        ///     Gets or sets the Caller*ID name.
        /// </summary>
		public string CallerIdName
		{
			get { return this.callerIdName; }
			set { this.callerIdName = value; }
		}

        /// <summary>
        ///     Creates a new <see cref="OriginateResponseEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public OriginateResponseEvent(ManagerConnection source)
			: base(source)
		{
		}

	}
}
