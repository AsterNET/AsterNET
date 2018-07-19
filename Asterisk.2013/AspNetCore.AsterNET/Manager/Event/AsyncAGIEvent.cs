namespace AspNetCore.AsterNET.Manager.Event
{
    public class AsyncAGIEvent : ManagerEvent
    {
        /// <summary>
        ///     Get/Set the Result
        ///     <b>Available since : </b> <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+12+Documentation" target="_blank" alt="Asterisk 12 wiki docs">Asterisk 12</see>.
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        ///     Get/Set the command ID
        ///     <b>Available since : </b> <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+12+Documentation" target="_blank" alt="Asterisk 12 wiki docs">Asterisk 12</see>.
        /// </summary>
        public string CommandId { get; set; }
        /// <summary>
        ///     <b>Available since : </b> <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+12+Documentation" target="_blank" alt="Asterisk 12 wiki docs">Asterisk 12</see>.
        /// </summary>
        public string SubEvent { get; set; }

        public string Env { get; set; }

        #region Constructor - AsyncAGIEvent(ManagerConnection source)

        public AsyncAGIEvent(ManagerConnection source)
            : base(source)
        {
        }

        #endregion
    }
}