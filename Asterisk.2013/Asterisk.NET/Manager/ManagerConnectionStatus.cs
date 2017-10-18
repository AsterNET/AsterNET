using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsterNET.Manager
{
    public enum ManagerConnectionStatus
    {
        SOCKETCONNECTING = 1,
        SOCKETCONNECTED = 2,
        CHALENGING = 3,
        CHALENGED = 4,
        AUTHENTICATING = 5,
        AUTHENTICATED = 6,
        CONNECTING = 7,
        CONNECTED = 8,
        READY = 10,
        IDLE = 0,
        BROKEN = -1,
        SOCKETDISCONNECTED = -2,
        DISCONNECTED,
        SOCKETPROBLEM = -3,
        STREAMPROBLEM = -4,
        UNAUTHENTICATED = -5
    }
}
