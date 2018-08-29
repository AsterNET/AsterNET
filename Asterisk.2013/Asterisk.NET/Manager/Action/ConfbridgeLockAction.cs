namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     Lock a Confbridge conference.
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_ConfbridgeLock">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_ConfbridgeLock</see>
    /// </summary>
    public class ConfbridgeLockAction : ManagerAction
    {
        /// <summary>
        ///     Creates a new empty <see cref="ConfbridgeLockAction"/>.
        /// </summary>
        public ConfbridgeLockAction()
        {
        }

        /// <summary>
        ///     Creates a new <see cref="ConfbridgeLockAction"/>.
        /// </summary>
        /// <param name="conference"></param>
        public ConfbridgeLockAction(string conference)
        {
            Conference = conference;
        }

        /// <summary>
        ///     Gets or sets the conference.
        /// </summary>
        public string Conference { get; set; }

        /// <summary>
        ///     Get the name of this action, i.e. "ConfbridgeLock".
        /// </summary>
        public override string Action
        {
            get { return "ConfbridgeLock"; }
        }
    }
}