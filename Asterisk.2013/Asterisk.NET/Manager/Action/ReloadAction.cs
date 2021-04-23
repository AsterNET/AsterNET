namespace AsterNET.Manager.Action
{
    /// <inheritdoc />
    /// <summary>
    ///     The ReloadAction reloads Asterisk modules.
    /// </summary>
    public class ReloadAction : ManagerAction
    {
        /// <summary>
        ///     Creates ReloadAction for given module.
        /// </summary>
        //// <param name="module">module to reload.</param>
        public ReloadAction(string module)
        {
            Module = module;
        }

        /// <inheritdoc />
        public override string Action => "Reload";

        /// <summary>
        ///     Get the name of the module.
        /// </summary>
        public string Module { get; }
    }
}