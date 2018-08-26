namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     Delete DB Tree.
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_DBDelTree">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_DBDelTree</see>
    /// </summary>
    public class DBDelTreeAction : ManagerAction
    {
        /// <summary>
        ///     Creates a new empty <see cref="DBDelTreeAction"/>.
        /// </summary>
        public DBDelTreeAction()
        {
        }

        /// <summary>
        ///     Creates a new <see cref="DBDelTreeAction"/> that deletes the database true
        ///     with the given key in the given family.
        /// </summary>
        /// <param name="family">the family of the key</param>
        /// <param name="key">the key of the entry to retrieve</param>
        public DBDelTreeAction(string family, string key)
        {
            Family = family;
            Key = key;
        }

        /// <summary>
        ///     Get the name of this action, i.e. "DBDelTree".
        /// </summary>
        public override string Action
        {
            get { return "DBDelTree"; }
        }

        /// <summary>
        ///     Get/Set the Family of the entry to delete.
        /// </summary>
        public string Family { get; set; }

        /// <summary>
        ///     Get/Set the key of the entry to delete.
        /// </summary>
        public string Key { get; set; }
    }
}