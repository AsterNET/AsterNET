namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     Stops recording a specified conference.
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_ConfbridgeStopRecord">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_ConfbridgeStopRecord</see>
    /// </summary>
    public class ConfbridgeStopRecordAction : ManagerAction
    {
        /// <summary>
        ///     Creates a new empty <see cref="ConfbridgeStopRecordAction"/>.
        /// </summary>
        public ConfbridgeStopRecordAction()
        {
        }

        /// <summary>
        ///     Stops recording a specified conference.
        ///     Creates a new <see cref="ConfbridgeStopRecordAction"/> using the given conference.
        /// </summary>
        /// <param name="conference"></param>
        public ConfbridgeStopRecordAction(string conference)
        {
            Conference = conference;
        }

        /// <summary>
        ///     Gets or sets the conference.
        /// </summary>
        public string Conference { get; set; }

        /// <summary>
        ///     Get the name of this action, i.e. "ConfbridgeStopRecord".
        /// </summary>
        public override string Action
        {
            get { return "ConfbridgeStopRecord"; }
        }
    }
}