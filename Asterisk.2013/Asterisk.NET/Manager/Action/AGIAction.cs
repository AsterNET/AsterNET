namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     This action lets you execute any AGI command through the Manager interface
    ///     For example, check the AsterNET.Test project
    /// </summary>
    public class AgiAction : ManagerAction
    {
        /// <summary>
        ///     Creates a new empty AgiAction.
        /// </summary>
        public AgiAction(string channel, string command)
        {
            Channel = channel;
            Command = command;
        }

        public string Channel { get; set; }
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