using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     Raised as part of the ConfbridgeList action response list.<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_ConfbridgeList">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_ConfbridgeList</see>
    /// </summary>
    public class ConfbridgeListEvent : AbstractConfbridgeEvent
    {
        /// <summary>
        ///     Identifies this user as an admin user.
        /// </summary>
        public string Admin { get; set; }

        /// <summary>
        ///     Identifies this user as a marked user.
        /// </summary>
        public string MarkedUser { get; set; }

        /// <summary>
        ///     Must this user wait for a marked user to join?
        /// </summary>
        public string WaitMarked { get; set; }

        /// <summary>
        ///     Does this user get kicked after the last marked user leaves?
        /// </summary>
        public string EndMarked { get; set; }

        /// <summary>
        ///     Is this user waiting for a marked user to join?
        /// </summary>
        public string Waiting { get; set; }

        /// <summary>
        ///     The current mute status.
        /// </summary>
        public string Muted { get; set; }

        /// <summary>
        ///     Is this user talking?
        /// </summary>
        public string Talking { get; set; }

        /// <summary>
        ///     The number of seconds the channel has been up.
        /// </summary>
        public string AnsweredTime { get; set; }
        
        /// <summary>
        ///     A numeric code for the channel's current state, related to ChannelStateDesc
        /// </summary>
        public string ChannelState { get; set; }

        /// <summary>
        ///     The number of seconds the channel has been up.
        /// </summary>
        public string ChannelStateDesc { get; set; }
        
        /// <summary>
        ///     Gets or sets the Caller*ID number.
        /// </summary>
        public string CallerIDNum { get; set; }

        /// <summary>
        ///     Gets or sets the Caller*ID name.
        /// </summary>
        public string CallerIDName { get; set; }

        /// <summary>
        ///     Gets or sets the connected line number.
        /// </summary>
        public string ConnectedLineNum { get; set; }

        /// <summary>
        ///     Gets or sets the name of the connected line.
        /// </summary>
        public string ConnectedLineName { get; set; }

        /// <summary>
        ///     Gets or sets the language.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        ///     Gets or sets the account code.
        /// </summary>
        public string AccountCode { get; set; }

        /// <summary>
        ///     Gets or sets the context.
        /// </summary>
        public string Context { get; set; }

        /// <summary>
        ///     Gets or sets the exten.
        /// </summary>
        public string Exten { get; set; }

        /// <summary>
        ///     Gets or sets the priority.
        /// </summary>
        public string Priority { get; set; }

        /// <summary>
        ///     Gets or sets the Uniqueid.
        /// </summary>
        public string Uniqueid { get; set; }

        /// <summary>
        ///     Gets or sets the Linkedid.
        ///     Uniqueid of the oldest channel associated with this channel.
        /// </summary>
        public string Linkedid { get; set; }

        /// <summary>
        ///     Creates a new <see cref="ConfbridgeListEvent"/>.
        /// </summary>
        /// <param name="source"></param>
        public ConfbridgeListEvent(ManagerConnection source)
			: base(source)
		{
		}
    }
}
