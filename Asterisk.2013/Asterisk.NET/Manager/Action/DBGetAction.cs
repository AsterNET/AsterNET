using System;
using AsterNET.Manager.Event;

namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     Retrieves an entry in the Asterisk database for a given family and key.<br />
    ///     If an entry is found a DBGetResponseEvent is sent by Asterisk containing the
    ///     value, otherwise a ManagerError indicates that no entry matches.
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_DBGet">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_DBGet</see>
    /// </summary>
    /// <seealso cref="AsterNET.Manager.Event.DBGetResponseEvent" />
    public class DBGetAction : ManagerActionEvent
    {
        /// <summary>
        ///     Creates a new empty <see cref="DBGetAction"/>.
        /// </summary>
        public DBGetAction()
        {
        }

        /// <summary>
        ///     Creates a new <see cref="DBGetAction"/> that retrieves the value of the database entry
        ///     with the given key in the given family.
        /// </summary>
        /// <param name="family">the family of the key</param>
        /// <param name="key">the key of the entry to retrieve</param>
        public DBGetAction(string family, string key)
        {
            Family = family;
            Key = key;
        }

        /// <summary>
        ///     Get the name of this action, i.e. "DBGet".
        /// </summary>
        public override string Action
        {
            get { return "DBGet"; }
        }

        /// <summary>
        ///     Returns the family of the key.
        /// </summary>
        /// <returns>
        ///     the family of the key.
        /// </returns>
        /// <param name="family">
        ///     the family of the key.
        /// </param>
        public string Family { get; set; }

        /// <summary>
        ///     Get/Set the key of the entry to retrieve.
        /// </summary>
        public string Key { get; set; }

        public override Type ActionCompleteEventClass()
        {
            return typeof (DBGetResponseEvent);
        }
    }
}