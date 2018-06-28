namespace AspNetCore.AsterNET.Manager.Action
{
    /// <summary>
    ///     The HangupAction causes the pbx to hang up a given channel.
    /// </summary>
    public class HangupAction : ManagerAction
    {
        /// <summary>
        ///     Creates a new empty HangupAction.
        /// </summary>
        public HangupAction()
        {
        }

        /// <summary>
        ///     Creates a new HangupAction that hangs up the given channel.
        /// </summary>
        /// <param name="channel">the name of the channel to hangup.</param>
        public HangupAction(string channel)
        {
            Channel = channel;
        }

        /// <summary>
        ///     Get the name of this action, i.e. "Hangup".
        /// </summary>
        public override string Action
        {
            get { return "Hangup"; }
        }

        /// <summary>
        ///     Get/Set the name of the channel to hangup.
        /// </summary>
        public string Channel { get; set; }
    }
}