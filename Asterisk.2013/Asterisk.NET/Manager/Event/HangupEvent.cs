namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     A HangupEvent is triggered when a channel is hung up.<br/>
    ///     It is implemented in channel.c<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_Hangup">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_Hangup</see>
    /// </summary>
    public class HangupEvent : AbstractChannelEvent
	{
		private int cause;
		private string causeTxt;

		/// <summary>
		///     Get/Set the cause of the hangup.
		/// </summary>
		public int Cause
		{
			get { return cause; }
			set { this.cause = value; }
		}
		/// <summary>
		///     Get/Set the textual representation of the hangup cause.
		/// </summary>
		public string CauseTxt
		{
			get { return causeTxt; }
			set { this.causeTxt = value; }
		}

        /// <summary>
        ///     Creates a new <see cref="HangupEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        /// <param name="source"></param>
        public HangupEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}