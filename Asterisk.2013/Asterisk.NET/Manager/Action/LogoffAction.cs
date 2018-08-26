namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     The LogoffAction causes the server to close the connection.
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_Logoff">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_Logoff</see>
    /// </summary>
    public class LogoffAction : ManagerAction
    {
        /// <summary>
        ///     Get the name of this action, i.e. "Logoff".
        /// </summary>
        public override string Action
        {
            get { return "Logoff"; }
        }
    }
}