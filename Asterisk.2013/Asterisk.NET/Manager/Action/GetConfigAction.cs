using AsterNET.Manager.Response;

namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     The GetConfigAction sends a GetConfig command to the asterisk server.
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_GetConfig">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_GetConfig</see>
    /// </summary>
    public class GetConfigAction : ManagerActionResponse
    {
        /// <summary>
        ///     Creates a new empty <see cref="GetConfigAction"/>.
        /// </summary>
        public GetConfigAction()
        {
        }

        /// <summary>
        ///     Creates a new <see cref="GetConfigAction"/> using the given filename.
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