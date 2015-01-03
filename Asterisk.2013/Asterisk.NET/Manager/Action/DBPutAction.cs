namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     Adds or updates an entry in the Asterisk database for a given family, key, and value.<br />
    ///     Available since Asterisk 1.2
    /// </summary>
    public class DBPutAction : ManagerAction
    {
        /// <summary>
        ///     Creates a new empty DBPutAction.
        /// </summary>
        public DBPutAction()
        {
        }

        /// <summary>
        ///     Creates a new DBPutAction that sets the value of the database entry with the given key in the given family.
        /// </summary>
        /// <param name="family">the family of the key</param>
        /// <param name="key">the key of the entry to set</param>
        /// <param name="val">the value to set</param>
        public DBPutAction(string family, string key, string val)
        {
            Family = family;
            Key = key;
            Val = val;
        }

        public override string Action
        {
            get { return "DBPut"; }
        }

        /// <summary>
        ///     Get/Set the family of the key to set.
        /// </summary>
        public string Family { get; set; }

        /// <summary>
        ///     Get/Set the the key to set.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        ///     Get/Set the value to set.
        /// </summary>
        public string Val { get; set; }
    }
}