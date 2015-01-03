namespace AsterNET.Manager.Action
{
    public class ConfbridgeUnlockAction : ManagerAction
    {
        /// <summary>
        ///     Unlocks a specified conference.
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