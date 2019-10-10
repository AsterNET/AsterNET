using System.Collections.Generic;
using AsterNET.Manager.Response;

namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     The UpdateConfigAction sends an UpdateConfig command to the asterisk server.
    ///     Please take note that unlike the manager documentation, this command does not
    ///     dump back the config file upon success -- it only tells you it succeeded. You
    ///     should use the handy addCommand method this class provides for specifying
    ///     what actions you would like to take on the configuration file. It will
    ///     generate appropriate sequence numbers for the command. You may use the static
    ///     ACTION_* fields provided by this action to specify what action you would like
    ///     to take, while avoiding handling the strings required. Plain fields:<br />
    ///     SrcFilename: Configuration filename to read(e.g. foo.conf)<br />
    ///     DstFilename: Configuration filename to write(e.g. foo.conf)<br />
    ///     Reload: Whether or not a reload should take place (or name of specific module)<br />
    ///     Repeatable fields:<br />
    ///     Action-XXXXXX: Action to Take (NewCat,RenameCat,DelCat,Update,Delete,Append)<br />
    ///     Cat-XXXXXX: Category to operate on<br />
    ///     Var-XXXXXX: Variable to work on<br />
    ///     Value-XXXXXX: Value to work on<br />
    ///     Match-XXXXXX: Extra match required to match line
    /// </summary>
    public class UpdateConfigAction : ManagerActionResponse
    {
        public const string ACTION_NEWCAT = "newcat";
        public const string ACTION_RENAMECAT = "renamecat";
        public const string ACTION_DELCAT = "delcat";
        public const string ACTION_UPDATE = "update";
        public const string ACTION_DELETE = "delete";
        public const string ACTION_APPEND = "append";

        private readonly Dictionary<string, string> actions;
        private int actionCounter;

        /// <summary>
        ///     Creates a new UpdateConfigAction.
        /// </summary>
        public UpdateConfigAction()
        {
            actionCounter = 0;
            actions = new Dictionary<string, string>();
        }

        /// <summary>
        ///     Creates a new UpdateConfigAction.
        /// </summary>
        public UpdateConfigAction(string srcFilename, string dstFilename, string reload)
            : this()
        {
            SrcFileName = srcFilename;
            DstFileName = dstFilename;
            this.Reload = reload;
        }

        /// <summary>
        ///     Creates a new UpdateConfigAction.
        /// </summary>
        public UpdateConfigAction(string srcFilename, string dstFilename, bool reload)
            : this()
        {
            SrcFileName = srcFilename;
            DstFileName = dstFilename;
            this.Reload = (reload ? "true" : "");
        }

        /// <summary>
        ///     Creates a new UpdateConfigAction.
        /// </summary>
        public UpdateConfigAction(string srcFilename, string dstFilename)
            : this()
        {
            SrcFileName = srcFilename;
            DstFileName = dstFilename;
            Reload = "";
        }

        /// <summary>
        ///     Get/Set the destination filename.
        /// </summary>
        public string DstFileName { get; set; }

        /// <summary>
        ///     Get/Set the source filename.
        /// </summary>
        public string SrcFileName { get; set; }

        /// <summary>
        ///     Get/Set the reload behavior of this action (yes), or sets a specific module (name) to be reloaded.<br />
        ///     Set to empty string to update without reload.
        /// </summary>
        public string Reload { get; set; }

        /// <summary>
        ///     Get the name of this action.
        /// </summary>
        public override string Action
        {
            get { return "UpdateConfig"; }
        }

        #region AddCommand(...) 

        /// <summary>
        ///     Adds a command to update a config file while sparing you the details of
        ///     the Manager's required syntax. If you want to omit one of the command's
        ///     sections, provide a null value to this method. The command index will be
        ///     incremented even if you supply a null for all parameters, though the action
        ///     will be unaffected.
        /// </summary>
        /// <param name="action">Action to Take (NewCat,RenameCat,DelCat,Update,Delete,Append)</param>
        /// <param name="category">Category to operate on</param>
        /// <param name="variable">Variable to work on</param>
        /// <param name="value">Value to work on</param>
        /// <param name="match">Extra match required to match line</param>
        /// <param name="options">Extra match required to match line</param>
        public void AddCommand(string action, string category, string variable, string value, string match, string options)
        {
            var i = actionCounter++;
            var index = i.ToString().PadLeft(6, '0');

            if (!string.IsNullOrEmpty(action))
                actions.Add("Action-" + index, action);

            if (!string.IsNullOrEmpty(category))
                actions.Add("Cat-" + index, category);

            if (!string.IsNullOrEmpty(variable))
                actions.Add("Var-" + index, variable);

            if (!string.IsNullOrEmpty(value))
                actions.Add("Value-" + index, value);

            if (!string.IsNullOrEmpty(match))
                actions.Add("Match-" + index, match);

            if (!string.IsNullOrEmpty(options))
                Actions.Add("Options-" + index, options);
        }

        public void AddCommand(string action, string category, string variable, string value, string match)
        {
            AddCommand(action, category, variable, value, match, null);
        }

        public void AddCommand(string action, string category, string variable, string value)
        {
            AddCommand(action, category, variable, value, null, null);
        }

        public void AddCommand(string action, string category, string variable)
        {
            AddCommand(action, category, variable, null, null, null);
        }

        public void AddCommand(string action, string category)
        {
            AddCommand(action, category, null, null, null, null);
        }

        public void AddCommand(string action)
        {
            AddCommand(action, null, null, null, null, null);
        }

        public void AddCommand()
        {
            AddCommand(null, null, null, null, null, null);
        }

        #endregion

        #region Actions 

        /// <summary>
        ///     Dictionary of the action's desired operations where Map keys contain:<br />
        ///     action,cat,var,value,match pairs followed by -XXXXXX, and the values contain the values for those keys.
        ///     This method will typically only be used by the ActionBuilder to generate the actual strings to be sent to the
        ///     manager interface.
        /// </summary>
        public Dictionary<string, string> Actions
        {
            get { return actions; }
        }

        #endregion

        public override object ActionCompleteResponseClass()
        {
            return new ManagerResponse();
        }
    }
}