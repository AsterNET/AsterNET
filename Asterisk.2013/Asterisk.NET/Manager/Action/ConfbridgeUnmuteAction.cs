namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     Unmutes a specified user in a specified conference.
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_ConfbridgeUnmute">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_ConfbridgeUnmute</see>
    /// </summary>
    public class ConfbridgeUnmuteAction : ManagerAction
    {
        /// <summary>
        ///     Creates a new empty <see cref="ConfbridgeUnmuteAction"/>.
        /// </summary>
        public ConfbridgeUnmuteAction()
        {
        }

        /// <summary>
        ///     Creates a new <see cref="ConfbridgeUnmuteAction"/> using the given conference.
        /// </summary>
        /// <param name="conference"></param>
        /// <param name="channel"></param>
        public ConfbridgeUnmuteAction(string conference, string channel)
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
        ///     Get the name of this action, i.e. "ConfbridgeUnmute".
        /// </summary>
        public override string Action
        {
            get { return "ConfbridgeUnmute"; }
        }
    }
}