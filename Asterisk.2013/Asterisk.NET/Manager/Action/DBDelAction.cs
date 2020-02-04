namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     Creates a new DBDelAction that deletes the value of the database entry
    ///     with the given key in the given family.
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_DBDel">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_DBDel</see>
    /// </summary>
    public class DBDelAction : ManagerAction
    {
        /// <summary>
        ///     Creates a new empty <see cref="DBDelAction"/>.
        /// </summary>
        public DBDelAction()
        {
        }

        /// <summary>
        ///     Creates a new <see cref="DBDelAction"/>.
        /// </summary>
        /// <param name="family">the family of the key</param>
        /// <param name="key">the key of the entry to retrieve</param>
        public DBDelAction(string family, string key)
        {
            Family = family;
            Key = key;
        }

        /// <summary>
        ///     Get the name of this action, i.e. "DBDel".
        /// </summary>
        public override string Action
        {
            get { return "DBDel"; }
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