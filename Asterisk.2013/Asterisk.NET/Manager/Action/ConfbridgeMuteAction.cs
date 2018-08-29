namespace AsterNET.Manager.Action
{
    public class ConfbridgeMuteAction : ManagerAction
    {
        /// <summary>
        ///     Mutes a specified user in a specified conference.
        /// </summary>
        public ConfbridgeMuteAction()
        {
        }

        /// <summary>
        ///     Mutes a specified user in a specified conference.
        /// </summary>
        /// <param name="conference"></param>
        /// <param name="channel"></param>
        public ConfbridgeMuteAction(string conference, string channel)
        {
            Conference = conference;
            Channel = channel;
        }

        public string Conference { get; set; }
        public string Channel { get; set; }

        public override string Action
        {
            get { return "ConfbridgeMute"; }
        }
    }
}