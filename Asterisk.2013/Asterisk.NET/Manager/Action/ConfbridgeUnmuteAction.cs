namespace AsterNET.Manager.Action
{
    public class ConfbridgeUnmuteAction : ManagerAction
    {
        /// <summary>
        ///     Unmutes a specified user in a specified conference.
        /// </summary>
        public ConfbridgeUnmuteAction()
        {
        }

        /// <summary>
        ///     Unmutes a specified user in a specified conference.
        /// </summary>
        /// <param name="conference"></param>
        /// <param name="channel"></param>
        public ConfbridgeUnmuteAction(string conference, string channel)
        {
            Conference = conference;
            Channel = channel;
        }

        public string Conference { get; set; }
        public string Channel { get; set; }

        public override string Action
        {
            get { return "ConfbridgeUnmute"; }
        }
    }
}