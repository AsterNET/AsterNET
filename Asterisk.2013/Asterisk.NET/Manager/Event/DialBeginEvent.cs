namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     A dial begin event is triggered whenever when a dial action has started.<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_DialBegin">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_DialBegin</see>
    /// </summary>
    public class DialBeginEvent : DialEvent
    {
        /// <summary>
        ///     Creates a new <see cref="DialBeginEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        public DialBeginEvent(ManagerConnection source)
			: base(source)
		{
        }
    }
}