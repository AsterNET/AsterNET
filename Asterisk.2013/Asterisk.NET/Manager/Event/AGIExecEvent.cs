namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     AgiExecEvents are triggered when an AGI command is executed.<br />
    ///     For each command two events are triggered: one before execution ("Start") and one after execution ("End").<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_AGIExecStart">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_AGIExecStart</see><br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_AGIExecEnd">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_AGIExecEnd</see>
    /// </summary>
    public class AGIExecEvent : ManagerEvent
    {
        /// <summary>
        ///     Creates a new <see cref="AGIExecEvent" />.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public AGIExecEvent(ManagerConnection source)
            : base(source)
        {
        }
        /// <summary>
        ///     Get/Set the command ID<br/>
        ///     <b>Available since : </b> <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+12+Documentation" target="_blank" alt="Asterisk 12 wiki docs">Asterisk 12</see>.
        /// </summary>
        public long CommandId { get; set; }
        /// <summary>
        ///     Get/Set the command<br/>
        ///     <b>Available since : </b> <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+12+Documentation" target="_blank" alt="Asterisk 12 wiki docs">Asterisk 12</see>.
        /// </summary>
        public string Command { get; set; }
        /// <summary>
        ///     <b>Available since : </b> <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+12+Documentation" target="_blank" alt="Asterisk 12 wiki docs">Asterisk 12</see>.
        /// </summary>
        public string SubEvent { get; set; }
        /// <summary>
        ///     Get/Set the result<br/>
        ///     <b>Available since : </b> <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+12+Documentation" target="_blank" alt="Asterisk 12 wiki docs">Asterisk 12</see>.
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        ///     Get/Set the result number<br/>
        ///     <b>Available since : </b> <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+12+Documentation" target="_blank" alt="Asterisk 12 wiki docs">Asterisk 12</see>.
        /// </summary>
        public int ResultCode { get; set; }
    }
}