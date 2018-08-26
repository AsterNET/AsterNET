namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     Stops recording a specified conference.
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_ConfbridgeSetSingleVideoSrc">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_ConfbridgeSetSingleVideoSrc</see>
    /// </summary>
    public class ConfbridgeSetSingleVideoSrcAction : ManagerAction
    {
        /// <summary>
        ///     Creates a new empty <see cref="ConfbridgeSetSingleVideoSrcAction"/>.
        /// </summary>
        public ConfbridgeSetSingleVideoSrcAction()
        {
        }

        /// <summary>
        ///     Creates a new <see cref="ConfbridgeSetSingleVideoSrcAction"/>.
        /// </summary>
        /// <param name="conference"></param>
        /// <param name="channel"></param>
        public ConfbridgeSetSingleVideoSrcAction(string conference, string channel)
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
        ///     Get the name of this action, i.e. "ConfbridgeSetSingleVideoSrc".
        /// </summary>
        public override string Action
        {
            get { return "ConfbridgeSetSingleVideoSrc"; }
        }
    }
}