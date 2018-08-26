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
        ///     Locks a specified conference.
        /// </summary>
        public ConfbridgeLockAction()
        {
        }

        /// <summary>
        ///     Locks a specified conference.
        /// </summary>
        /// <param name="conference"></param>
        public ConfbridgeLockAction(string conference)
        {
            Conference = conference;
        }

        public string Conference { get; set; }

        public override string Action
        {
            get { return "ConfbridgeLock"; }
        }
    }
}