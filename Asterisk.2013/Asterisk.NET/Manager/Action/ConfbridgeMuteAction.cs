namespace AsterNET.Manager.Action
{
    public class ConfbridgeMuteAction : ManagerAction
    {
        /// <summary>
        ///     Mutes a specified user in a specified conference.
        ///     
        ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_ConfbridgeMute">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_ConfbridgeMute</see>
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