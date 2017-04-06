using System.Threading.Tasks;
using AsterNET.Manager.Action;

namespace AsterNET.Manager.Response
{
    internal class TaskResponseHandler : IResponseHandler
    {
        public TaskResponseHandler(ManagerAction action)
        {
            TaskCompletionSource = new TaskCompletionSource<ManagerResponse>();
            Action = action;
        }

        public TaskCompletionSource<ManagerResponse> TaskCompletionSource { get; }

        public ManagerAction Action { get; }

        public int Hash { get; set; }

        public void HandleResponse(ManagerResponse response)
        {
            TaskCompletionSource.TrySetResult(response);
        }

        public void Free() { }
    }
}
