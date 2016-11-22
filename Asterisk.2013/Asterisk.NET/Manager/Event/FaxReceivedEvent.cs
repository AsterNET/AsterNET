namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     A FaxReceivedEvent is triggered by spandsp after a new fax has been received.<br />
    ///     It is only available if you installed the spandsp patches to Asterisk.<br />
    ///     See http://soft-switch.org/installing-spandsp.html for details.<br />
    ///     Implemented in apps/app_rxfax.c.
    /// </summary>
    public class FaxReceivedEvent : AbstractAgentEvent
    {
        public FaxReceivedEvent(ManagerConnection source)
            : base(source)
        {
        }

        /// <summary>
        ///     Get/Set the extension in Asterisk's dialplan the fax was received
        ///     <b>Available since : </b> <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+12+Documentation" target="_blank" alt="Asterisk 12 wiki docs">Asterisk 12</see>.
        /// </summary>
        public string Exten { get; set; }

        /// <summary>
        ///     Get/Set the Caller*ID of the calling party or an empty string if none is
        ///     <b>Available since : </b> <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+12+Documentation" target="_blank" alt="Asterisk 12 wiki docs">Asterisk 12</see>.
        /// </summary>
        public string CallerId { get; set; }

        /// <summary>
        ///     Get/Set the identifier of the remote fax station.
        ///     <b>Available since : </b> <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+12+Documentation" target="_blank" alt="Asterisk 12 wiki docs">Asterisk 12</see>.
        /// </summary>
        public string RemoteStationId { get; set; }

        /// <summary>
        ///     Get/Set the identifier of the local fax station.
        ///     <b>Available since : </b> <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+12+Documentation" target="_blank" alt="Asterisk 12 wiki docs">Asterisk 12</see>.
        /// </summary>
        public string LocalStationId { get; set; }

        /// <summary>
        ///     Get/Set the number of pages transferred.
        ///     <b>Available since : </b> <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+12+Documentation" target="_blank" alt="Asterisk 12 wiki docs">Asterisk 12</see>.
        /// </summary>
        public int PagesTransferred { get; set; }

        /// <summary>
        ///     Get/Set the row resolution of the received fax.
        ///     <b>Available since : </b> <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+12+Documentation" target="_blank" alt="Asterisk 12 wiki docs">Asterisk 12</see>.
        /// </summary>
        public int Resolution { get; set; }

        /// <summary>
        ///     Get/Set the transfer rate in bits/s.
        ///     <b>Available since : </b> <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+12+Documentation" target="_blank" alt="Asterisk 12 wiki docs">Asterisk 12</see>.
        /// </summary>
        public int TransferRate { get; set; }

        /// <summary>
        ///     Get/Set the filename of the received fax including its full path on the Asterisk server.
        ///     <b>Available since : </b> <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+12+Documentation" target="_blank" alt="Asterisk 12 wiki docs">Asterisk 12</see>.
        /// </summary>
        public string Filename { get; set; }
    }
}