namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     Creates an empty file in the configuration directory.
    ///     This action will create an empty file in the configuration directory. This action is intended to be used before an
    ///     UpdateConfig action.
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_CreateConfig">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_CreateConfig</see>
    /// </summary>
    public class CreateConfigAction : ManagerAction
    {
        /// <summary>
        ///     Creates a new empty <see cref="CreateConfigAction"/>.
        /// </summary>
        public CreateConfigAction()
        {
        }

        /// <summary>
        ///     Creates a new <see cref="CreateConfigAction"/> using the given filename.
        /// </summary>
        /// <param name="filename"></param>
        public CreateConfigAction(string filename)
        {
            Filename = filename;
        }

        /// <summary>
        ///     Get the name of this action, i.e. "CreateConfig".
        /// </summary>
        public override string Action
        {
            get { return "CreateConfig"; }
        }

        /// <summary>
        /// Gets or sets the filename.
        /// </summary>
        public string Filename { get; set; }
    }
}