namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     Mutes a specified user in a specified conference.
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_ConfbridgeMute">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_ConfbridgeMute</see>
    /// </summary>
    public class ConfbridgeMuteAction : ManagerAction
    {
        /// <summary>
        ///     Creates a new empty <see cref="ConfbridgeMuteAction"/>.
        /// </summary>
        public ConfbridgeMuteAction()
        {
        }

        /// <summary>
        ///     Creates a new <see cref="ConfbridgeMuteAction"/>.
        /// </summary>
        /// <param name="conference"></param>
        /// <param name="channel"></param>
        public ConfbridgeMuteAction(string conference, string channel)
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
        ///     Get the name of this action, i.e. "ConfbridgeMute".
        /// </summary>
        public override string Action
        {
            get { return "ConfbridgeMute"; }
        }
    }
}