namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     AgiExecEvents are triggered when an AGI command is executed.<br />
    ///     For each command two events are triggered: one before excution ("Start") and one after execution ("End").
    /// </summary>
    public class AGIExecEvent : ManagerEvent
    {
        /// <summary>
        ///     Creates a new AGIExecEvent.
        /// </summary>
        public AGIExecEvent(ManagerConnection source)
            : base(source)
        {
        }
        /// <summary>
        ///     Get/Set the command ID
        ///     <b>Available since : </b> <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+12+Documentation" target="_blank" alt="Asterisk 12 wiki docs">Asterisk 12</see>.
        /// </summary>
        public long CommandId { get; set; }
        /// <summary>
        ///     Get/Set the command
        ///     <b>Available since : </b> <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+12+Documentation" target="_blank" alt="Asterisk 12 wiki docs">Asterisk 12</see>.
        /// </summary>
        public string Command { get; set; }
        /// <summary>
        ///     <b>Available since : </b> <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+12+Documentation" target="_blank" alt="Asterisk 12 wiki docs">Asterisk 12</see>.
        /// </summary>
        public string SubEvent { get; set; }
        /// <summary>
        ///     Get/Set the result
        ///     <b>Available since : </b> <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+12+Documentation" target="_blank" alt="Asterisk 12 wiki docs">Asterisk 12</see>.
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        ///     Get/Set the result number
        ///     <b>Available since : </b> <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+12+Documentation" target="_blank" alt="Asterisk 12 wiki docs">Asterisk 12</see>.
        /// </summary>
        public int ResultCode { get; set; }
    }
}