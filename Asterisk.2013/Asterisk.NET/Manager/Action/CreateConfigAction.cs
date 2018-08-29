namespace AsterNET.Manager.Action
{
    public class CreateConfigAction : ManagerAction
    {
        /// <summary>
        ///     Creates an empty file in the configuration directory.
        ///     This action will create an empty file in the configuration directory. This action is intended to be used before an
        ///     UpdateConfig action.
        /// </summary>
        public CreateConfigAction()
        {
        }

        /// <summary>
        ///     Creates an empty file in the configuration directory.
        ///     This action will create an empty file in the configuration directory. This action is intended to be used before an
        ///     UpdateConfig action.
        /// </summary>
        /// <param name="filename"></param>
        public CreateConfigAction(string filename)
        {
            Filename = filename;
        }

        public override string Action
        {
            get { return "CreateConfig"; }
        }

        public string Filename { get; set; }
    }
}