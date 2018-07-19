using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspNetCore.AsterNET.Manager
{
    interface IActionVariable
    {
        Dictionary<string, string> GetVariables();
        void SetVariables(Dictionary<string, string> vars);
    }
}
