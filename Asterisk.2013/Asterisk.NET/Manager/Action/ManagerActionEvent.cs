using System;

namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     The ManagerActionEvent is implemented by ManagerActions that
    ///     return their result not in a ManagerResponse but by sending a series of events.<br />
    ///     The event type that indicates that Asterisk is finished is returned by the
    ///     ActionCompleteEventClass property.
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+AMI+Actions">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+AMI+Actions</see>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+AMI+Events">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+AMI+Events</see>
    /// </summary>
    /// <seealso cref="AsterNET.Manager.Event.ResponseEvent" />
    public abstract class ManagerActionEvent : ManagerAction
    {
        /// <summary>
        ///     Returns the event type that indicates that Asterisk is finished sending response events for this action.
        /// </summary>
        /// <seealso cref="AsterNET.Manager.Event.ResponseEvent" />
        public abstract Type ActionCompleteEventClass();
    }
}