using AspNetCore.AsterNET.Manager.Action;
using AspNetCore.AsterNET.Manager.Response;

namespace AspNetCore.AsterNET.Manager
{
    /// <summary>
    ///     An Interface to handle responses received from an asterisk server.
    /// </summary>
    /// <seealso cref="ManagerResponse" />
    public interface IResponseHandler
    {
        ManagerAction Action { get; }

        int Hash { get; set; }

        /// <summary>
        ///     This method is called when a response is received.
        /// </summary>
        /// <param name="response">the response received</param>
        void HandleResponse(ManagerResponse response);

        void Free();
    }
}