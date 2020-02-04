namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     The HangupAction causes the PBX to hang up a given channel.
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_Hangup">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_Hangup</see>
    /// </summary>
    public class HangupAction : ManagerAction
    {
        /// <summary>
        ///     Creates a new empty <see cref="HangupAction"/>.
        /// </summary>
        public HangupAction()
        {
        }

        /// <summary>
        ///     Creates a new <see cref="HangupAction"/> that hangs up the given channel.
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