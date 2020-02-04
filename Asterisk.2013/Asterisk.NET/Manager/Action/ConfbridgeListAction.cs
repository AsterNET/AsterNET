using System;
using AsterNET.Manager.Event;

namespace AsterNET.Manager.Action
{
    /*
        https://wiki.asterisk.org/wiki/display/AST/ConfBridge+10#ConfBridge10-ConfBridgeAsteriskManagerInterface%28AMI%29Events
        Action: ConfbridgeList
        Conference: 1111
    */

    /// <summary>
    ///     Lists all users in a particular ConfBridge conference. ConfbridgeList will follow as separate events,
    ///     followed by a final event called ConfbridgeListComplete
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_ConfbridgeList">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_ConfbridgeList</see>
    /// </summary>
    public class ConfbridgeListAction : ManagerActionEvent
    {
        /// <summary>
        ///     Creates a new <see cref="ConfbridgeListAction"/>.
        /// </summary>
        /// <param name="conference">The conference.</param>
        public ConfbridgeListAction(string conference)
        {
            Conference = conference;
        }

        /// <summary>
        ///     Gets or sets the conference.
        /// </summary>
        public string Conference { get; set; }

        /// <summary>
        ///     Get the name of this action, i.e. "ConfbridgeList".
        /// </summary>
        public override string Action
        {
            get { return "ConfbridgeList"; }
        }

        public override Type ActionCompleteEventClass()
        {
            return typeof (ConfbridgeListCompleteEvent);
        }
    }
}