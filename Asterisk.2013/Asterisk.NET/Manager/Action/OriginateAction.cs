using System;
using System.Collections.Generic;
using AsterNET.Manager.Event;

namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     The OriginateAction generates an outgoing call to the extension in the given
    ///     context with the given priority or to a given application with optional
    ///     parameters.<br />
    ///     If you want to connect to an extension use the properties context, exten and
    ///     priority. If you want to connect to an application use the properties
    ///     application and data if needed. Note that no call detail record will be
    ///     written when directly connecting to an application, so it may be better to
    ///     connect to an extension that starts the application you wish to connect to.<br />
    ///     The response to this action is sent when the channel has been answered and
    ///     asterisk starts connecting it to the given extension. So be careful not to
    ///     choose a too short timeout when waiting for the response.<br />
    ///     If you set async to true Asterisk reports an OriginateSuccess-
    ///     and OriginateFailureEvents. The action id of these events equals the action
    ///     id of this OriginateAction.
    /// </summary>
    /// <seealso cref="AsterNET.Manager.Event.OriginateSuccessEvent" />
    /// <seealso cref="AsterNET.Manager.Event.OriginateFailureEvent" />
    public class OriginateAction : ManagerActionEvent, IActionVariable
    {
        private Dictionary<string, string> variables;

        #region Action 

        /// <summary>
        ///     Get the name of this action, i.e. "Originate".
        /// </summary>
        public override string Action
        {
            get { return "Originate"; }
        }

        #endregion

        #region Account 

        /// <summary>
        ///     Get/Set the account code to use for the originated call.
        ///     The account code is included in the call detail record generated for this call and will be used for billing.
        /// </summary>
        public string Account { get; set; }

        #endregion

        #region CallerId 

        /// <summary>
        ///     Get/Set the caller id to set on the outgoing channel.
        /// </summary>
        public string CallerId { get; set; }

        #endregion

        #region Channel 

        /// <summary>
        ///     Get/Set Channel on which to originate the call (The same as you specify in the Dial application command)<br />
        ///     This property is required.
        /// </summary>
        public string Channel { get; set; }

        #endregion

        #region ChannelId

        /// <summary>
        ///     Get/Set originated channel id
        /// </summary>
        public string ChannelId { get; set; }

        #endregion

        #region Context 

        /// <summary>
        ///     Get/Set the name of the context of the extension to connect to.
        ///     If you set the context you also have to set the exten and priority properties.
        /// </summary>
        public string Context { get; set; }

        #endregion

        #region Exten 

        /// <summary>
        ///     Get/Ser the extension to connect to.
        ///     If you set the extension you also have to set the context and priority properties.
        /// </summary>
        public string Exten { get; set; }

        #endregion

        #region Priority 

        /// <summary>
        ///     Get /Set the priority of the extension to connect to.
        ///     If you set the priority you also have to set the context and exten properties.
        /// </summary>
        public string Priority { get; set; }

        #endregion

        #region Application 

        /// <summary>
        ///     Get/Set Application to use on connect (use Data for parameters)
        /// </summary>
        public string Application { get; set; }

        #endregion

        #region Data 

        /// <summary>
        ///     Get/Set the parameters to pass to the application.
        ///     Data if Application parameter is user
        /// </summary>
        /// <summary> Sets the parameters to pass to the application.</summary>
        public string Data { get; set; }

        #endregion

        #region Async 

        /// <summary>
        ///     Get/Set true if this is a fast origination.<br />
        ///     For the origination to be asynchronous (allows multiple calls to be generated without waiting for a response).
        ///     <br />
        ///     Will send OriginateSuccess- and OriginateFailureEvents.
        /// </summary>
        public bool Async { get; set; }

        #endregion

        #region ActionCompleteEventClass 

        public override Type ActionCompleteEventClass()
        {
            return typeof (OriginateResponseEvent);
        }

        #endregion

        #region Timeout 

        /// <summary>
        ///     Get/Set the timeout for the origination in milliseconds.<br />
        ///     The channel must be answered within this time, otherwise the origination
        ///     is considered to have failed and an OriginateFailureEvent is generated.<br />
        ///     If not set, Asterisk assumes a default value of 30000 meaning 30 seconds.
        /// </summary>
        public int Timeout { get; set; }

        #endregion

        #region Variable 

        /// <summary>
        ///     Get/Set the variables to set on the originated call.<br />
        ///     Variable assignments are of the form "VARNAME=VALUE". You can specify
        ///     multiple variable assignments separated by the '|' character.<br />
        ///     Example: "VAR1=abc|VAR2=def" sets the channel variables VAR1 to "abc" and VAR2 to "def".
        /// </summary>
        
        [Obsolete("Use GetVariables and SetVariables instead.", true)]
        public string Variable
        {
            get { return null; /* return Helper.JoinVariables(variables, Common.GET_VAR_DELIMITER(this.Server), "="); */ }
            set { /* variables = Helper.ParseVariables(variables, value, Common.GET_VAR_DELIMITER(this.Server)); */ }
        }

        #endregion

        #region GetVariables() 

        /// <summary>
        ///     Get the variables dictionary to set on the originated call.
        /// </summary>
        public Dictionary<string, string> GetVariables()
        {
            return variables;
        }

        #endregion

        #region SetVariables(IDictionary vars) 

        /// <summary>
        ///     Set the variables dictionary to set on the originated call.
        /// </summary>
        public void SetVariables(Dictionary<string, string> vars)
        {
            variables = vars;
        }

        #endregion

        #region GetVariable(string name, string val) 

        /// <summary>
        ///     Gets a variable on the originated call. Replaces any existing variable with the same name.
        /// </summary>
        public string GetVariable(string key)
        {
            if (variables == null)
                return string.Empty;
            return variables[key];
        }

        #endregion

        #region SetVariable(string name, string val) 

        /// <summary>
        ///     Sets a variable dictionary on the originated call. Replaces any existing variable with the same name.
        /// </summary>
        public void SetVariable(string key, string value)
        {
            if (variables == null)
                variables = new Dictionary<string, string>();
            if (variables.ContainsKey(key))
                variables[key] = value;
            else
                variables.Add(key, value);
        }

        #endregion
    }
}
