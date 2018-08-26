namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     The SetVar action sets the value of a channel variable for a given channel.
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_Setvar">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_Setvar</see>
    /// </summary>
    public class SetVarAction : ManagerAction
    {
        /// <summary> The channel on which to set the variable.</summary>
        public string channel;

        /// <summary> The name of the variable to set.</summary>
        public string varName;

        /// <summary> The value to store.</summary>
        public string varValue;

        /// <summary>
        ///     Creates a new empty <see cref="SetVarAction"/>.
        /// </summary>
        public SetVarAction()
        {
        }

        /// <summary>
        ///     Creates a new <see cref="SetVarAction"/> that sets the given global variable to a new value.
        /// </summary>
        /// <param name="variable">the name of the global variable to set</param>
        /// <param name="value">the new value</param>
        public SetVarAction(string variable, string value)
        {
            varName = variable;
            varValue = value;
        }

        /// <summary>
        ///     Creates a new <see cref="SetVarAction"/> that sets the given channel variable of the
        ///     given channel to a new value.
        /// </summary>
        /// <param name="channel">the name of the channel to set the variable on</param>
        /// <param name="variable">the name of the channel variable</param>
        /// <param name="value">the new value</param>
        public SetVarAction(string channel, string variable, string value)
        {
            this.channel = channel;
            varName = variable;
            varValue = value;
        }

        /// <summary>
        ///     Get the name of this action, i.e. "SetVar".
        /// </summary>
        public override string Action
        {
            get { return "SetVar"; }
        }

        /// <summary>
        ///     Get/Set the name of the channel.
        /// </summary>
        public string Channel
        {
            get { return channel; }
            set { channel = value; }
        }

        /// <summary>
        ///     Get/Set the name of the variable to set.
        /// </summary>
        public string Variable
        {
            get { return varName; }
            set { varName = value; }
        }

        /// <summary>
        ///     Get/Set the value to store.
        /// </summary>
        public string Value
        {
            get { return varValue; }
            set { varValue = value; }
        }
    }
}