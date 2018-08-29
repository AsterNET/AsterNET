namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     The SetCDRUserFieldAction causes the user field of the call detail record for the given channel to be changed.
    ///     <br />
    ///     Depending on the value of the append property the value is appended or overwritten.<br />
    ///     The SetCDRUserFieldAction is implemented in apps/app_setcdruserfield.c
    /// </summary>
    public class SetCDRUserFieldAction : ManagerAction
    {
        /// <summary>
        ///     Creates a new empty SetCDRUserFieldAction.
        /// </summary>
        public SetCDRUserFieldAction()
        {
        }

        /// <summary>
        ///     Creates a new SetCDRUserFieldAction that sets the user field of the call detail record for the given channel to the
        ///     given value.
        /// </summary>
        /// <param name="channel">the name of the channel</param>
        /// <param name="userField">the new value of the userfield</param>
        public SetCDRUserFieldAction(string channel, string userField)
        {
            this.Channel = channel;
            this.UserField = userField;
        }

        /// <summary>
        ///     Creates a new SetCDRUserFieldAction that sets the user field of the call detail record for the given channel to the
        ///     given value.
        /// </summary>
        /// <param name="channel">the name of the channel</param>
        /// <param name="userField">the new value of the userfield</param>
        /// <param name="append">true to append the value to the cdr user field or false to overwrite</param>
        public SetCDRUserFieldAction(string channel, string userField, bool append)
        {
            this.Channel = channel;
            this.UserField = userField;
            this.Append = append;
        }

        /// <summary>
        ///     Get the name of the action, i.e. "SetCDRUserField".
        /// </summary>
        public override string Action
        {
            get { return "SetCDRUserField"; }
        }

        /// <summary>
        ///     Get/Set the name of the channel to set the cdr user field on.<br />
        ///     This property is mandatory.
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        ///     Get/Set the value of the cdr user field to set or append.<br />
        ///     This property is mandatory.
        /// </summary>
        public string UserField { get; set; }

        /// <summary>
        ///     Get/Set if the value of the cdr user field is appended or overwritten.<br />
        ///     true to append the value to the cdr user field or false to overwrite.
        /// </summary>
        public bool Append { get; set; }
    }
}