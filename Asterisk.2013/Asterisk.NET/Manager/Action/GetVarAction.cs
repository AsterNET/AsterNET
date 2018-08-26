namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     The GetVarAction queries for a channel variable.
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_Getvar">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_Getvar</see>
    /// </summary>
    public class GetVarAction : ManagerAction
    {
        /// <summary>
        ///     Creates a new empty <see cref="GetVarAction"/>.
        /// </summary>
        public GetVarAction()
        {
        }

        /// <summary>
        ///     Creates a new <see cref="GetVarAction"/> that queries for the given global variable.
        /// </summary>
        /// <param name="variable">the name of the global variable to query.</param>
        public GetVarAction(string variable)
        {
            Variable = variable;
        }

        /// <summary>
        ///     Creates a new <see cref="GetVarAction"/> that queries for the given local channel variable.
        /// </summary>
        /// <param name="channel">the name of the channel, for example "SIP/1234-9cd".</param>
        /// <param name="variable">the name of the variable to query.</param>
        public GetVarAction(string channel, string variable)
        {
            Channel = channel;
            Variable = variable;
        }

        /// <summary>
        ///     Get the name of this action, i.e. "GetVar".
        /// </summary>
        public override string Action
        {
            get { return "GetVar"; }
        }

        /// <summary>
        ///     Get/Set the name of the channel, if you query for a local channel variable.
        ///     Leave empty to query for a global variable.
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        ///     Get/Set the name of the variable to query.
        /// </summary>
        public string Variable { get; set; }
    }
}