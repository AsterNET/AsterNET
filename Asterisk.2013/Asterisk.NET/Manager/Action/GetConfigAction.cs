using AsterNET.Manager.Response;

namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     The GetConfigAction sends a GetConfig command to the asterisk server.
    /// </summary>
    public class GetConfigAction : ManagerActionResponse
    {
        /// <summary>
        ///     Creates a new GetConfigAction.
        /// </summary>
        public GetConfigAction()
        {
        }

        /// <summary>
        ///     Get the name of this action.
        /// </summary>
        /// <param name="filename">the configuration filename.</param>
        public GetConfigAction(string filename)
        {
            Filename = filename;
        }

        /// <summary>
        ///     Get the name of this action.
        /// </summary>
        public override string Action
        {
            get { return "GetConfig"; }
        }

        /// <summary>
        ///     Get/Set the configuration filename.
        /// </summary>
        public string Filename { get; set; }

        public override object ActionCompleteResponseClass()
        {
            return new GetConfigResponse();
        }
    }
}