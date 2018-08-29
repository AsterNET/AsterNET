namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     Show PBX core status variables.
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_CoreStatus">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_CoreStatus</see>
    /// </summary>
    public class CoreStatusAction : ManagerAction
    {
        /// <summary>
        ///     Get the name of this action, i.e. "CoreStatus".
        /// </summary>
        public override string Action
        {
            get { return "CoreStatus"; }
        }
    }
}