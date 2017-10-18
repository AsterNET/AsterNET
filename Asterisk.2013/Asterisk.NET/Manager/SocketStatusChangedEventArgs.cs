using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsterNET.Manager
{
    public class SocketStatusChangedEventArgs : EventArgs
    {
        public SocketStatusChangedEventArgs(bool status)
        {
            Status = status;
        }

        public bool Status { get; }
    }
}
