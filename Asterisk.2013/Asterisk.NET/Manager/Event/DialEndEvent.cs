namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     A dial begin event is triggered whenever when a dial action has completed.<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_DialEnd">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_DialEnd</see>
    /// </summary>
	public class DialEndEvent : DialEvent
    {
        /// <summary>
        ///     Creates a new <see cref="DialEndEvent" />.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public DialEndEvent(ManagerConnection source)
			: base(source)
		{
        }

        /// <summary>
        ///     Gets or sets the forward.<br/>
        ///     If the call was forwarded, where the call was forwarded to.
        /// </summary>
        public string Forward { get; set; }
    }
}