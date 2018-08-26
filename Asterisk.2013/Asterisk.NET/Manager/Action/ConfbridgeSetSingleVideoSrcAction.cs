namespace AsterNET.Manager.Action
{
    public class ConfbridgeSetSingleVideoSrcAction : ManagerAction
    {
        /// <summary>
        ///     Stops recording a specified conference.
        ///     
        ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_ConfbridgeSetSingleVideoSrc">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_ConfbridgeSetSingleVideoSrc</see>
        /// </summary>
        public ConfbridgeSetSingleVideoSrcAction()
        {
        }

        /// <summary>
        ///     Stops recording a specified conference.
        /// </summary>
        /// <param name="conference"></param>
        public ConfbridgeSetSingleVideoSrcAction(string conference, string channel)
        {
            Conference = conference;
            Channel = channel;
        }

        public string Conference { get; set; }
        public string Channel { get; set; }

        public override string Action
        {
            get { return "ConfbridgeSetSingleVideoSrc"; }
        }
    }
}