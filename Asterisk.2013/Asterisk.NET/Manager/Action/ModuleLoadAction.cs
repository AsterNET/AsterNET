namespace AsterNET.Manager.Action
{
    /// <inheritdoc />
    /// <summary>
    ///     The ModuleLoadAction loads/unloads Asterisk modules.
    /// </summary>
    public class ModuleLoadAction : ManagerAction
    {
        /// <summary>
        ///     Creates ModuleLoadAction for given module.
        /// </summary>
        //// <param name="module">module to load/unload.</param>
        //// <param name="loadType">loadType parameter can have the following values: load/unload</param>
        public ModuleLoadAction(string module, string loadType)
        {
            Module = module;
            LoadType = loadType;
        }

        /// <inheritdoc />
        public override string Action => "ModuleLoad";

        /// <summary>
        ///     Get the name of the module.
        /// </summary>
        public string Module { get; }

        /// <summary>
        ///     Get the type of action (load/unload).
        /// </summary>
        public string LoadType { get; }
    }
}