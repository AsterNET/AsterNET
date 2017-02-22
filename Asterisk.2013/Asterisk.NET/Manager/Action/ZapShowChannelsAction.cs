using System;
using AsterNET.Manager.Event;

namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     The ZapShowChannelsAction requests the state of all zap channels.<br />
    ///     For each zap channel a ZapShowChannelsEvent is generated. After all zap
    ///     channels have been listed a ZapShowChannelsCompleteEvent is generated.
    /// </summary>
    /// <seealso cref="Manager.Event.ZapShowChannelsEvent" />
    /// <seealso cref="Manager.Event.ZapShowChannelsCompleteEvent" />
    public class ZapShowChannelsAction : ManagerActionEvent
    {
        /// <summary>
        ///     Get the name of this action, i.e. "ZapShowChannels".
        /// </summary>
        public override string Action
        {
            get { return "ZapShowChannels"; }
        }

        public override Type ActionCompleteEventClass()
        {
            return typeof (ZapShowChannelsCompleteEvent);
        }
    }
}