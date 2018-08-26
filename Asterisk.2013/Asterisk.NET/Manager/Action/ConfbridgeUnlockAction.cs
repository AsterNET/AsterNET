namespace AsterNET.Manager.Action
{
    public class ConfbridgeUnlockAction : ManagerAction
    {
        /// <summary>
        ///     Unlocks a specified conference.
        ///     
        ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_ConfbridgeStopRecord">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_ConfbridgeStopRecord</see>
        /// </summary>
        public ConfbridgeUnlockAction()
        {
        }

        /// <summary>
        ///     Unlocks a specified conference.
        /// </summary>
        /// <param name="conference"></param>
        public ConfbridgeUnlockAction(string conference)
        {
            Conference = conference;
        }

        public string Conference { get; set; }

        public override string Action
        {
            get { return "ConfbridgeUnlock"; }
        }
    }
}