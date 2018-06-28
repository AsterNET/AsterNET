namespace AspNetCore.AsterNET.Manager.Action
{
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