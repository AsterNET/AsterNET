namespace AspNetCore.AsterNET.Manager.Action
{
    /// <summary>
    ///     The PingAction will ellicit a 'Pong' response, it is used to keep the manager
    ///     connection open and performs no operation.
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