using System;

namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     This event is implemented in <code>channels/chan_dahdi.c</code>.<br/>
    ///     Available since Asterisk 1.6.1
    /// </summary>
    public class PRIEvent : ManagerEvent
	{
		private string priEvent;
		private string priEventCode;
		private string dChannel;
		private string span;

        /// <summary>
        ///     Gets or sets the pri event.<br/>
        ///     This is one of:<br/>
        ///     <ul>
        ///         <li>"On hook"</li>
        ///         <li>"Ring/Answered"</li>
        ///         <li>"Wink/Flash"</li>
        ///         <li>"Alarm"</li>
        ///         <li>"No more alarm"</li>
        ///         <li>"HDLC Abort"</li>
        ///         <li>"HDLC Overrun"</li>
        ///         <li>"HDLC Bad FCS"</li>
        ///         <li>"Dial Complete"</li>
        ///         <li>"Ringer On"</li>
        ///         <li>"Ringer Off"</li>
        ///         <li>"Hook Transition Complete"</li>
        ///         <li>"Bits Changed"</li>
        ///         <li>"Pulse Start"</li>
        ///         <li>"Timer Expired"</li>
        ///         <li>"Timer Ping"</li>
        ///         <li>"Polarity Reversal"</li>
        ///         <li>"Ring Begin"</li>
        ///     </ul>
        /// </summary>
        public string PriEvent
		{
			get { return this.priEvent; }
			set { this.priEvent = value; }
		}
        /// <summary>
        ///     Gets or sets the pri event code.
        /// </summary>
        public string PriEventCode
		{
			get { return this.priEventCode; }
			set { this.priEventCode = value; }
		}
        /// <summary>
        ///     Gets or sets the d channel.
        /// </summary>
        public string DChannel
		{
			get { return this.dChannel; }
			set { this.dChannel = value; }
		}
        /// <summary>
        ///     Gets or sets the span.
        /// </summary>
        public string Span
		{
			get { return this.span; }
			set { this.span = value; }
		}

        /// <summary>
        ///     Creates a new <see cref="PRIEvent"/> .
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection" /></param>
        public PRIEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}
