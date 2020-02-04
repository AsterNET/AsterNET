namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     List currently active channels.
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_CoreShowChannels">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_CoreShowChannels</see>
    /// </summary>
    public class CoreShowChannelsAction : ManagerAction
    {
        /// <summary>
        ///     Get the name of this action, i.e. "CoreShowChannels".
        /// </summary>
        public override string Action
        {
            get { return "CoreShowChannels"; }
        }
    }
}