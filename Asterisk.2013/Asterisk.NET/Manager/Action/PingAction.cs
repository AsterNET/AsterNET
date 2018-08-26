namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     The PingAction will elicit a 'pong' response, it is used to keep the manager
    ///     connection open and performs no operation.
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_Ping">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_Ping</see>
    /// </summary>
    public class PingAction : ManagerAction
    {
        /// <summary>
        ///     Get the name of this action, i.e. "Ping".
        /// </summary>
        public override string Action
        {
            get { return "Ping"; }
        }
    }
}