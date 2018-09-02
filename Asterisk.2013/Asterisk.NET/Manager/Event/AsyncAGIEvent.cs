namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     Raised when AsyncAGI completes an AGI command.<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_AsyncAGIExec">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_AsyncAGIExec</see><br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_AGIExecStart">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_AGIExecStart</see><br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_AGIExecEnd">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_AGIExecEnd</see>
    /// </summary>
    public class AsyncAGIEvent : ManagerEvent
    {
        /// <summary>
        ///     Get/Set the Result<br/>
        ///     <b>Available since : </b> <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+12+Documentation" target="_blank" alt="Asterisk 12 wiki docs">Asterisk 12</see>.
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        ///     Get/Set the command ID<br/>
        ///     <b>Available since : </b> <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+12+Documentation" target="_blank" alt="Asterisk 12 wiki docs">Asterisk 12</see>.
        /// </summary>
        public string CommandId { get; set; }
        /// <summary>
        ///     <b>Available since : </b> <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+12+Documentation" target="_blank" alt="Asterisk 12 wiki docs">Asterisk 12</see>.
        /// </summary>
        public string SubEvent { get; set; }

        /// <summary>
        ///     Gets or sets the env.
        /// </summary>
        public string Env { get; set; }

        #region Constructor - AsyncAGIEvent(ManagerConnection source)

        /// <summary>
        ///     Creates a new <see cref="AsyncAGIEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        /// <param name="source"></param>
        public AsyncAGIEvent(ManagerConnection source)
            : base(source)
        {
        }

        #endregion
    }
}