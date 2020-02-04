namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     Unlocks a specified conference.
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_ConfbridgeUnlock">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_ConfbridgeUnlock</see>
    /// </summary>
    public class ConfbridgeUnlockAction : ManagerAction
    {
        /// <summary>
        ///     Creates a new empty <see cref="ConfbridgeUnlockAction"/>.
        /// </summary>
        public ConfbridgeUnlockAction()
        {
        }

        /// <summary>
        ///     Creates a new <see cref="ConfbridgeUnlockAction"/> using the given conference.
        /// </summary>
        /// <param name="conference"></param>
        public ConfbridgeUnlockAction(string conference)
        {
            Conference = conference;
        }

        /// <summary>
        ///     Gets or sets the conference.
        /// </summary>
        public string Conference { get; set; }

        /// <summary>
        ///     Get the name of this action, i.e. "ConfbridgeUnlock".
        /// </summary>
        public override string Action
        {
            get { return "ConfbridgeUnlock"; }
        }
    }
}