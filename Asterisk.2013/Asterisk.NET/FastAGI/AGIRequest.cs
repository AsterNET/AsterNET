using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;

namespace AsterNET.FastAGI
{
    /// <summary>
    ///     Default implementation of the AGIRequest interface.
    /// </summary>
    public class AGIRequest
    {
        #region Variables

#if LOGGER
        private Logger logger = Logger.Instance();
#endif
        private string rawCallerId;
        private readonly Dictionary<string, string> request;

        /// <summary> A map assigning the values of a parameter (an array of Strings) to the name of the parameter.</summary>
        private Dictionary<string, List<string>> parameterMap;

        private string parameters;
        private string script;
        private bool callerIdCreated;

        #endregion

        #region Constructor - AGIRequest(ICollection environment)

        /// <summary>
        ///     Creates a new AGIRequest.
        /// </summary>
        /// <param name="environment">the first lines as received from Asterisk containing the environment.</param>
        public AGIRequest(List<string> environment)
        {
            if (environment == null)
                throw new ArgumentException("Environment must not be null.");
            request = buildMap(environment);
        }

        #endregion

        #region Request

        public IDictionary Request
        {
            get { return request; }
        }

        #endregion

        #region RequestURL 

        /// <summary>
        ///     Returns the full URL of the request in the form agi://host[:port][/script].
        /// </summary>
        public string RequestURL
        {
            get { return request["request"]; }
        }

        #endregion

        #region Channel 

        /// <summary>
        ///     Returns the name of the channel.
        /// </summary>
        /// <returns>the name of the channel.</returns>
        public string Channel
        {
            get { return request["channel"]; }
        }

        #endregion

        #region UniqueId 

        /// <summary>
        ///     Returns the unqiue id of the channel.
        /// </summary>
        /// <returns>the unqiue id of the channel.</returns>
        public string UniqueId
        {
            get { return request["uniqueid"]; }
        }

        #endregion

        #region Type 

        /// <summary>
        ///     Returns the type of the channel, for example "SIP".
        /// </summary>
        /// <returns>the type of the channel, for example "SIP".</returns>
        public string Type
        {
            get { return request["type"]; }
        }

        #endregion

        #region Language 

        /// <summary>
        ///     Returns the language, for example "en".
        /// </summary>
        public string Language
        {
            get { return request["language"]; }
        }

        #endregion

        #region CallerId 

        public string CallerId
        {
            get
            {
                string callerIdName = request["calleridname"];
                string callerId = request["callerid"];
                if (callerIdName != null)
                {
                    if (callerId == null || callerId.ToLower(Helper.CultureInfo) == "unknown")
                        return null;
                    return callerId;
                }
                return callerId10();
            }
        }

        #endregion

        #region CallerIdName 

        public string CallerIdName
        {
            get
            {
                string callerIdName = request["calleridname"];
                if (callerIdName != null)
                {
                    // Asterisk 1.2
                    if (callerIdName.ToLower(Helper.CultureInfo) == "unknown")
                        return null;
                    return callerIdName;
                }
                return callerIdName10();
            }
        }

        #endregion

        #region Asterisk 1.0 CallerID and CallerIdName 

        private string callerId10()
        {
            int lbPosition;
            int rbPosition;

            if (!callerIdCreated)
            {
                rawCallerId = request["callerid"];
                callerIdCreated = true;
            }

            if (rawCallerId == null)
            {
                return null;
            }

            lbPosition = rawCallerId.IndexOf('<');
            rbPosition = rawCallerId.IndexOf('>');

            if (lbPosition < 0 || rbPosition < 0)
            {
                return rawCallerId;
            }

            return rawCallerId.Substring(lbPosition + 1, (rbPosition) - (lbPosition + 1));
        }

        private string callerIdName10()
        {
            int lbPosition;
            string callerIdName;

            if (!callerIdCreated)
            {
                rawCallerId = request["callerid"];
                callerIdCreated = true;
            }

            if (rawCallerId == null)
                return null;

            lbPosition = rawCallerId.IndexOf('<');

            if (lbPosition < 0)
                return null;

            callerIdName = rawCallerId.Substring(0, (lbPosition) - (0)).Trim();
            if (callerIdName.StartsWith("\"") && callerIdName.EndsWith("\""))
                callerIdName = callerIdName.Substring(1, (callerIdName.Length - 1) - (1));

            if (callerIdName.Length == 0)
                return null;
            return callerIdName;
        }

        #endregion

        #region Dnid 

        public string Dnid
        {
            get
            {
                string dnid = request["dnid"];
                if (dnid == null || dnid.ToLower(Helper.CultureInfo) == "unknown")
                    return null;
                return dnid;
            }
        }

        #endregion

        #region Rdnis 

        public string Rdnis
        {
            get
            {
                string rdnis = request["rdnis"];
                if (rdnis == null || rdnis.ToLower(Helper.CultureInfo) == "unknown")
                    return null;
                return rdnis;
            }
        }

        #endregion

        #region Context

        /// <summary>
        ///     Returns the context in the dial plan from which the AGI script was called.
        /// </summary>
        public string Context
        {
            get { return request["context"]; }
        }

        #endregion

        #region Extension

        /// <summary>
        ///     Returns the extension in the dial plan from which the AGI script was called.
        /// </summary>
        public string Extension
        {
            get { return request["extension"]; }
        }

        #endregion

        #region Priority

        /// <summary>
        ///     Returns the priority in the dial plan from which the AGI script was called.
        /// </summary>
        public string Priority
        {
            get
            {
                if (request["priority"] != null)
                {
                    return request["priority"];
                }
                return "";
            }
        }

        #endregion

        #region Enhanced 

        /// <summary>
        ///     Returns wheather this agi is passed audio (EAGI - Enhanced AGI).<br />
        ///     Enhanced AGI is currently not supported on FastAGI.<br />
        ///     true if this agi is passed audio, false otherwise.
        /// </summary>
        public bool Enhanced
        {
            get
            {
                if (request["enhanced"] != null && request["enhanced"] == "1.0")
                    return true;
                return false;
            }
        }

        #endregion

        #region AccountCode 

        /// <summary>
        ///     Returns the account code set for the call.
        /// </summary>
        public string AccountCode
        {
            get { return request["accountCode"]; }
        }

        #endregion

        #region LocalAddress

        public IPAddress LocalAddress { get; set; }

        #endregion

        #region LocalPort

        public int LocalPort { get; set; }

        #endregion

        #region RemoteAddress

        public IPAddress RemoteAddress { get; set; }

        #endregion

        #region RemotePort

        public int RemotePort { get; set; }

        #endregion

        #region Script()

        /// <summary>
        ///     Returns the name of the script to execute.
        /// </summary>
        public string Script
        {
            get
            {
                if (script != null)
                    return script;

                script = request["network_script"];
                if (script != null)
                {
                    Match scriptMatcher = Common.AGI_SCRIPT_PATTERN.Match(script);
                    if (scriptMatcher.Success)
                    {
                        script = scriptMatcher.Groups[1].Value;
                        parameters = scriptMatcher.Groups[2].Value;
                    }
                }
                return script;
            }
        }

        #endregion

        #region CallingAni2

        public int CallingAni2
        {
            get
            {
                if (request["callingani2"] == null)
                    return -1;
                try
                {
                    return Int32.Parse(request["callingani2"]);
                }
                catch
                {
                }
                return -1;
            }
        }

        #endregion

        #region CallingPres 

        public int CallingPres
        {
            get
            {
                if (request["callingpres"] == null)
                    return -1;
                try
                {
                    return Int32.Parse(request["callingpres"]);
                }
                catch
                {
                }
                return -1;
            }
        }

        #endregion

        #region CallingTns 

        public int CallingTns
        {
            get
            {
                if (request["callingtns"] == null)
                    return -1;
                try
                {
                    return Int32.Parse(request["callingtns"]);
                }
                catch
                {
                }
                return -1;
            }
        }

        #endregion

        #region CallingTon 

        public int CallingTon
        {
            get
            {
                if (request["callington"] == null)
                    return -1;
                try
                {
                    return Int32.Parse(request["callington"]);
                }
                catch
                {
                }
                return -1;
            }
        }

        #endregion

        #region Parameter(string name) 

        public string Parameter(string name)
        {
            List<string> values;
            values = ParameterValues(name);
            if (values == null || values.Count == 0)
                return null;
            return values[0];
        }

        #endregion

        #region ParameterValues(string name) 

        public List<string> ParameterValues(string name)
        {
            if (ParameterMap().Count == 0)
                return null;

            return parameterMap[name];
        }

        #endregion

        #region ParameterMap() 

        public Dictionary<string, List<string>> ParameterMap()
        {
            if (parameterMap == null)
                parameterMap = parseParameters(parameters);
            return parameterMap;
        }

        #endregion

        #region ToString() 

        public override string ToString()
        {
            return Helper.ToString(this);
        }

        #endregion

        #region buildMap(ICollection lines) 

        /// <summary>
        ///     Builds a map containing variable names as key (with the "agi_" prefix stripped) and the corresponding values.<br />
        ///     Syntactically invalid and empty variables are skipped.
        /// </summary>
        /// <param name="lines">the environment to transform.</param>
        /// <returns> a map with the variables set corresponding to the given environment.</returns>
        private Dictionary<string, string> buildMap(List<string> lines)
        {
            int colonPosition;
            string key;
            string value;

            var map = new Dictionary<string, string>(lines.Count);
            foreach (var line in lines)
            {
                colonPosition = line.IndexOf(':');
                if (colonPosition < 0 || !line.StartsWith("agi_") || line.Length < colonPosition + 2)
                    continue;

                key = line.Substring(4, colonPosition - 4).ToLower(Helper.CultureInfo);
                value = line.Substring(colonPosition + 2);
                if (value.Length != 0)
                    map.Add(key, value);
            }
            return map;
        }

        #endregion

        #region parseParameters(string s)

        /// <summary>
        ///     Parses the given parameter string and caches the result.
        /// </summary>
        /// <param name="s">the parameter string to parse</param>
        /// <returns> a Map made up of parameter names their values</returns>
        private Dictionary<string, List<string>> parseParameters(string parameters)
        {
            var result = new Dictionary<string, List<string>>();
            string name;
            string val;

            if (string.IsNullOrEmpty(parameters))
                return result;

            string[] pars = parameters.Split('&');
            if (pars.Length == 0)
                return result;

            foreach (var parameter in pars)
            {
                val = string.Empty;
                int i = parameter.IndexOf('=');
                if (i > 0)
                {
                    name = WebUtility.UrlDecode(parameter.Substring(0, i));
                    if (parameter.Length > i + 1)
                        val = WebUtility.UrlDecode(parameter.Substring(i + 1));
                }
                else if (i < 0)
                    name = WebUtility.UrlDecode(parameter);
                else
                    continue;

                if (!result.ContainsKey(name))
                    result.Add(name, new List<string>());
                result[name].Add(val);
            }
            return result;
        }

        #endregion
    }
}