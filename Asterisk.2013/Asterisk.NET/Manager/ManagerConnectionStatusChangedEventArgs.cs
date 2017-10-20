using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsterNET.Manager
{
    public class ManagerConnectionStatusChangedEventArgs : EventArgs
    {
        public ManagerConnectionStatusChangedEventArgs(ManagerConnectionStatus status, Exception ex)
        {
            this.Status = status;
            this.Exception = ex;
        }

        public ManagerConnectionStatus Status { get; }
        public Exception Exception { get; }
    }
}
