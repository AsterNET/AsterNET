using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsterNET.Manager
{
    interface IActionVariable
    {
        Dictionary<string, string> GetVariables();
        void SetVariables(Dictionary<string, string> vars);
    }
}
