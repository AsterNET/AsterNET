namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     This action lets you execute any AGI command through the Manager interface
    ///     For example, check the AsterNET.Test project
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_AGI">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_AGI</see>
    /// </summary>
    public class AgiAction : ManagerAction
    {
        /// <summary>
        ///     Creates a new empty <see cref="AgiAction"/>.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <param name="command">The command.</param>
        public AgiAction(string channel, string command)
        {
            Channel = channel;
            Command = command;
        }

        /// <summary>
        /// Gets or sets the channel.
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        /// Gets or sets the command.
        /// </summary>
        public string Command { get; set; }

        /// <summary>
        ///     Get the name of this action, i.e. "AGI".
        /// </summary>
        public override string Action
        {
            get { return "AGI"; }
        }
    }
}