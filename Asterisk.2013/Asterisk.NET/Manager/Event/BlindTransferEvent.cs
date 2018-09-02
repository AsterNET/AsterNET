using System;
using System.Collections.Generic;
using System.Text;

namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     Raised when a blind transfer is complete.<br/>
    ///     The following results are used:<br/>
    ///     <ul>
    ///         <li>Fail - An internal error occurred.</li>
    ///         <li>Invalid - Invalid configuration for transfer(e.g.Not bridged)</li>
    ///         <li>Not Permitted - Bridge does not permit transfers</li>
    ///         <li>Success - Transfer completed successfully</li>
    ///     </ul>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_BlindTransfer">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_BlindTransfer</see>
    /// </summary>
    public class BlindTransferEvent : ManagerEvent
	{
        /// <summary>
        ///     Gets or sets a URL encoded result string from the executed AGI command.
        /// </summary>
        public bool Result { get; set; }

        /// <summary>
        ///     Gets or sets the transferrer channel.
        /// </summary>
        public string TransfererChannel { get; set; }

        /// <summary>
        ///     Gets or sets the state of the transferrer channel.
        /// </summary>
        public string TransfererChannelState { get; set; }

        /// <summary>
        ///     Gets or sets the transferrer channel state description.<br/>
        ///     The following states are used:<br/>
        ///     <ul>
        ///         <li>Down</li>
        ///         <li>Rsrvd</li>
        ///         <li>OffHook</li>
        ///         <li>Dialing</li>
        ///         <li>Ring</li>
        ///         <li>Ringing</li>
        ///         <li>Up</li>
        ///         <li>Busy</li>
        ///         <li>Dialing Offhook</li>
        ///         <li>Pre-ring</li>
        ///         <li>Unknown</li>
        ///     </ul>
        /// </summary>
        public string TransfererChannelStatedesc { get; set; }

        /// <summary>
        ///     Gets or sets the transferrer caller identifier number.
        /// </summary>
        public string TransfererCallerIdNum { get; set; }

        /// <summary>
        ///     Gets or sets the name of the transferrer caller identifier.
        /// </summary>
        public string TransfererCallerIdName { get; set; }

        /// <summary>
        ///     Gets or sets the transferrer connected line number.
        /// </summary>
        public string TransfererConnectedLineNum { get; set; }

        /// <summary>
        ///     Gets or sets the name of the transferrer connected line.
        /// </summary>
        public string TransfererConnectedLineName { get; set; }

        /// <summary>
        ///     Gets or sets the transferrer language.
        /// </summary>
        public string TransfererLanguage { get; set; }

        /// <summary>
        ///     Gets or sets the transferrer account code.
        /// </summary>
        public string TransfererAccountCode { get; set; }

        /// <summary>
        ///     Gets or sets the transferrer context.
        /// </summary>
        public string TransfererContext { get; set; }

        /// <summary>
        ///     Gets or sets the transferrer priority.
        /// </summary>
        public string TransfererPriority { get; set; }

        /// <summary>
        ///     Gets or sets the transferrer unique identifier.
        /// </summary>
        public string TransfererUniqueId { get; set; }

        /// <summary>
        ///     Gets or sets the transferee channel.
        /// </summary>
        public string TransfereeChannel { get; set; }

        /// <summary>
        ///     Gets or sets the state of the transferee channel.
        /// </summary>
        public string TransfereeChannelState { get; set; }

        /// <summary>
        ///     Gets or sets the transferee channel state description.<br/>
        ///     The following states are used:<br/>
        ///     <ul>
        ///         <li>Down</li>
        ///         <li>Rsrvd</li>
        ///         <li>OffHook</li>
        ///         <li>Dialing</li>
        ///         <li>Ring</li>
        ///         <li>Ringing</li>
        ///         <li>Up</li>
        ///         <li>Busy</li>
        ///         <li>Dialing Offhook</li>
        ///         <li>Pre-ring</li>
        ///         <li>Unknown</li>
        ///     </ul>
        /// </summary>
        public string TransfereeChannelStateDesc { get; set; }

        /// <summary>
        ///     Gets or sets the transferee caller identifier number.
        /// </summary>
        public string TransfereeCallerIdNum { get; set; }

        /// <summary>
        ///     Gets or sets the name of the transferee caller identifier.
        /// </summary>
        public string TransfereeCallerIdName { get; set; }

        /// <summary>
        ///     Gets or sets the transferee connected line number.
        /// </summary>
        public string TransfereeConnectedLineNum { get; set; }

        /// <summary>
        ///     Gets or sets the name of the transferee connected line.
        /// </summary>
        public string TransfereeConnectedLineName { get; set; }

        /// <summary>
        ///     Gets or sets the transferee language.
        /// </summary>
        public string TransfereeLanguage { get; set; }

        /// <summary>
        ///     Gets or sets the transferee account code.
        /// </summary>
        public string TransfereeAccountCode { get; set; }

        /// <summary>
        ///     Gets or sets the transferee context.
        /// </summary>
        public string TransfereeContext { get; set; }

        /// <summary>
        ///     Gets or sets the transferee extension.
        /// </summary>
        public string TransfereeExten { get; set; }

        /// <summary>
        ///     Gets or sets the transferee priority.
        /// </summary>
        public string TransfereePriority { get; set; }

        /// <summary>
        ///     Gets or sets the transferee unique identifier.
        /// </summary>
        public string TransfereeUniqueId { get; set; }

        /// <summary>
        ///     Gets or sets the bridge unique identifier.
        /// </summary>
        public string BridgeUniqueId { get; set; }

        /// <summary>
        ///     Gets or sets the type of the bridge.
        /// </summary>
        public string BridgeType { get; set; }

        /// <summary>
        ///     Gets or sets the bridge technology.
        /// </summary>
        public string BridgeTechnology { get; set; }

        /// <summary>
        ///     Gets or sets the bridge creator.
        /// </summary>
        public string BridgeCreator { get; set; }

        /// <summary>
        ///     Gets or sets the name of the bridge.
        /// </summary>
        public string BridgeName { get; set; }

        /// <summary>
        ///     Gets or sets the bridge number channels.
        /// </summary>
        public string BridgeNumChannels { get; set; }

        /// <summary>
        ///     Gets or sets the is external.
        /// </summary>
        public string IsExternal { get; set; }

        /// <summary>
        ///     Gets or sets the context.
        /// </summary>
        public string Context { get; set; }

        /// <summary>
        ///     Gets or sets the extension.
        /// </summary>
        public string Extension { get; set; }

        #region Constructor - BlindTransferEvent(ManagerConnection source)        
        /// <summary>
        ///     Creates a new <see cref="BlindTransferEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public BlindTransferEvent(ManagerConnection source) : base(source)
		{
		}
		#endregion
	}
}
