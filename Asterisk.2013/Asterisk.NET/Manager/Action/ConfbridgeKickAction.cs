namespace AsterNET.Manager.Action
{
    public class ConfbridgeKickAction : ManagerAction
    {
        /// <summary>
        ///     Removes a specified user from a specified conference.
        ///     
        ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_ConfbridgeKick">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_ConfbridgeKick</see>
        /// </summary>
        public ConfbridgeKickAction()
        {
        }

        /// <summary>
        ///     Removes a specified user from a specified conference.
        /// </summary>
        /// <param name="conference"></param>
        /// <param name="channel"></param>
        public ConfbridgeKickAction(string conference, string channel)
        {
            Conference = conference;
            Channel = channel;
        }

        public string Conference { get; set; }
        public string Channel { get; set; }

        public override string Action
        {
            get { return "ConfbridgeKick"; }
        }
    }
}