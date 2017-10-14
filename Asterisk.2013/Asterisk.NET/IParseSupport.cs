using System.Collections.Generic;

namespace AsterNET
{
    internal interface IParseSupport
    {
        IDictionary<string, string> Attributes { get; }
        bool Parse(string key, string value);
        IDictionary<string, string> ParseSpecial(IDictionary<string, string> attributes);
    }
}