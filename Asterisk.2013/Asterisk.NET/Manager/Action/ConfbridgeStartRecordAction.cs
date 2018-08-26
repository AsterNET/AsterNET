namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     Starts recording a specified conference, with an optional filename.
    ///     If recording is already in progress, an error will be returned.
    ///     If RecordFile is not provided, the default record_file as specified in the conferences Bridge Profile will be used.
    ///     If record_file is not specified, a file will automatically be generated in Asterisk's monitor directory.
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_ConfbridgeStartRecord">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_ConfbridgeStartRecord</see>
    /// </summary>
    public class ConfbridgeStartRecordAction : ManagerAction
    {
        /// <summary>
        ///     Creates a new empty <see cref="ConfbridgeStartRecordAction"/>.
        /// </summary>
        public ConfbridgeStartRecordAction()
        {
        }

        /// <summary>
        ///     Creates a new <see cref="ConfbridgeStartRecordAction"/>.
        /// </summary>
        /// <param name="conference"></param>
        public ConfbridgeStartRecordAction(string conference)
        {
            Conference = conference;
        }

        /// <summary>
        /// Gets or sets the conference.
        /// </summary>
        public string Conference { get; set; }

        /// <summary>
        ///     Get the name of this action, i.e. "ConfbridgeStartRecord".
        /// </summary>
        public override string Action
        {
            get { return "ConfbridgeStartRecord"; }
        }
    }
}