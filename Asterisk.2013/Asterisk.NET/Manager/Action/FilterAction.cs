namespace AsterNET.Manager.Action
{
    /// <summary>
    /// Dynamically add filters for the current manager session
    /// The filters added are only used for the current session. Once the connection is closed the filters are removed.
    /// This comand requires the system permission because this command can be used to create filters that may bypass filters defined in manager.conf
    /// </summary>
    public class FilterAction : ManagerAction
    {
        #region Action

        /// <summary>
        /// Get the name of this action, i.e. "Filter".
        /// </summary>
        public override string Action
        {
            get { return "Filter"; }
        }

        #endregion

        #region Operation

        /// <summary>
        /// Add - Add a filter
        /// </summary>
        public string Operation { get; set; }

        #endregion

        #region Filter

        /// <summary>
        /// Filters can be whitelist or blacklist
        /// Example whitelist filter: "Event: Newchannel"
        /// Example blacklist filter: "!Channel: DAHDI.*"
        /// </summary>
        public string Filter { get; set; }

        #endregion

        #region FilterAction(string filter)

        /// <summary>
        ///     Add - Add a filter
        /// </summary>
        /// <param name="filter">Add a filter</param>
        /// <param name="operation">Filters can be whitelist or blacklist</param>
        public FilterAction(string filter, string operation = "Add")
        {
            Filter = filter;
            Operation = operation;
        }

        #endregion
    }
}
