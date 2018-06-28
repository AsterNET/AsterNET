namespace AspNetCore.AsterNET.Manager.Action
{
    /// <summary>
    /// </summary>
    public class DBDelTreeAction : ManagerAction
    {
        /// <summary>
        ///     Creates a new empty DBDelTreeAction.
        /// </summary>
        public DBDelTreeAction()
        {
        }

        /// <summary>
        ///     Creates a new DBDelTreeAction that deletes the database true
        ///     with the given key in the given family.
        /// </summary>
        /// <param name="family">the family of the key</param>
        /// <param name="key">the key of the entry to retrieve</param>
        public DBDelTreeAction(string family, string key)
        {
            Family = family;
            Key = key;
        }

        public override string Action
        {
            get { return "DBDelTree"; }
        }

        /// <summary>
        ///     Get/Set the the Family of the entry to delete.
        /// </summary>
        public string Family { get; set; }

        /// <summary>
        ///     Get/Set the the key of the entry to delete.
        /// </summary>
        public string Key { get; set; }
    }
}