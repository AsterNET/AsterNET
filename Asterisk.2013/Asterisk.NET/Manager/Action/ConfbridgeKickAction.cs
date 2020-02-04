namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     Removes a specified user from a specified conference.
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_ConfbridgeKick">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_ConfbridgeKick</see>
    /// </summary>
    public class ConfbridgeKickAction : ManagerAction
    {
        /// <summary>
        ///     Creates a new empty <see cref="ConfbridgeKickAction"/>.
        /// </summary>
        public ConfbridgeKickAction()
        {
        }

        /// <summary>
        ///     Creates a new <see cref="ConfbridgeKickAction"/>.
        /// </summary>
        /// <param name="conference"></param>
        /// <param name="channel"></param>
        public ConfbridgeKickAction(string conference, string channel)
        {
            Conference = conference;
            Channel = channel;
        }

        /// <summary>
        ///     Gets or sets the conference.
        /// </summary>
        public string Conference { get; set; }

        /// <summary>
        ///     Gets or sets the channel.
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        ///     Get the name of this action, i.e. "ConfbridgeKick".
        /// </summary>
        public override string Action
        {
            get { return "ConfbridgeKick"; }
        }
    }
}