namespace AspNetCore.AsterNET.Manager.Action
{
    public class ConfbridgeSetSingleVideoSrcAction : ManagerAction
    {
        /// <summary>
        ///     Stops recording a specified conference.
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