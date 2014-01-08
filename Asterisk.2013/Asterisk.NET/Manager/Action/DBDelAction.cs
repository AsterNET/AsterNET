using System;
namespace AsterNET.Manager.Action
{

    /// <summary>
    /// 
    /// </summary>
    public class DBDelAction : ManagerAction
    {
        private string family;
        private string key;

        public override string Action
        {
            get { return "DBDel"; }
        }
        
        /// <summary>
        /// Get/Set the the Family of the entry to delete.
        /// </summary>
        public string Family
        {
            get { return family; }
            set { this.family = value; }
        }
        /// <summary>
        /// Get/Set the the key of the entry to delete.
        /// </summary>
        public string Key
        {
            get { return key; }
            set { this.key = value; }
        }
        
        /// <summary>
        /// Creates a new empty DBDelAction.
        /// </summary>
        public DBDelAction()
        {
        }

        /// <summary>
        /// Creates a new DBDelAction that deletes the value of the database entry
        /// with the given key in the given family.
        /// </summary>
        /// <param name="family">the family of the key</param>
        /// <param name="key">the key of the entry to retrieve</param>
        public DBDelAction(string family, string key)
        {
            this.family = family;
            this.key = key;
        }
    }
}