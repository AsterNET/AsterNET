namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     The ExtensionStateAction queries the state of an extension in a given context.
    /// </summary>
    public class ExtensionStateAction : ManagerAction
    {
        #region Action

        /// <summary>
        ///     Get the name of this action, i.e. "ExtensionState".
        /// </summary>
        public override string Action
        {
            get { return "ExtensionState"; }
        }

        #endregion

        #region Exten

        /// <summary>
        ///     Get/Set the extension to query.
        /// </summary>
        public string Exten { get; set; }

        #endregion

        #region Context

        /// <summary>
        ///     Get/Set the name of the context that contains the extension to query.
        /// </summary>
        public string Context { get; set; }

        #endregion
    }
}