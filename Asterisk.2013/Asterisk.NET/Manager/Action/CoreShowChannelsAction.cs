using AsterNET.Manager.Event;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace AsterNET.Manager.Action
{
    public class CoreShowChannelsAction : ManagerActionEvent
    {
        /// <summary>
        ///     Get the name of this action "CoreShowChannels".
        /// </summary>
        public override string Action
        {
            get { return "CoreShowChannels"; }
        }

        public override Type ActionCompleteEventClass()
        {
            return typeof(CoreShowChannelsCompleteEvent);
        }
    }
}