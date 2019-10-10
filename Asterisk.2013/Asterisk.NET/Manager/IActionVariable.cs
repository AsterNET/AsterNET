using System.Collections.Generic;

namespace AsterNET.Manager
{
    /// <summary>
    ///     IActionVariable
    /// </summary>
    interface IActionVariable
    {
        Dictionary<string, string> GetVariables();
        void SetVariables(Dictionary<string, string> vars);
    }
}
