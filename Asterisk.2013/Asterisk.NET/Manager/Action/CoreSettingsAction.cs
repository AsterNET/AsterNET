namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     Show PBX core settings (version etc).
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_CoreSettings">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_CoreSettings</see>
    /// </summary>
    public class CoreSettingsAction : ManagerAction
    {
        /// <summary>
        ///     Get the name of this action, i.e. "CoreSettings".
        /// </summary>
        public override string Action
        {
            get { return "CoreSettings"; }
        }
    }
}