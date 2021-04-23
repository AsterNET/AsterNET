using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     Raised when a queue member is notified of a caller in the queue and fails to answer.<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_AgentRingNoAnswer">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_AgentRingNoAnswer</see>
    /// </summary>
    public class AgentRingNoAnswerEvent : AbstractAgentVariables
    {
        /// <summary>
        ///     Creates a new <see cref="AgentRingNoAnswerEvent"/> using the given <see cref="ManagerConnection"/>.
        /// </summary>
        /// <param name="source"></param>
        public AgentRingNoAnswerEvent(ManagerConnection source)
            : base(source)
        {
        }


        /// <summary>
        ///     Gets or sets the queue.
        /// </summary>
        public string Queue { get; set; }

        /// <summary>
        ///     Gets or sets the name of the agent.
        /// </summary>
        public string AgentName { get; set; }

        /// <summary>
        ///     Gets or sets the agent called.
        /// </summary>
        public string AgentCalled { get; set; }

        /// <summary>
        ///     Gets or sets the channel calling.
        /// </summary>
        public string ChannelCalling { get; set; }

        /// <summary>
        ///     Gets or sets the destination channel.
        /// </summary>
        public string DestinationChannel { get; set; }

        /// <summary>
        ///     Gets or sets the Caller*ID of the calling channel.
        /// </summary>
        public string CallerId { get; set; }

        /// <summary>
        ///     Get/Set the Caller*ID number of the calling channel.
        /// </summary>
        public string CallerIdNum { get; set; }

        /// <summary>
        ///     Get/Set the Caller*ID name of the calling channel.
        /// </summary>
        public string CallerIdName { get; set; }

        /// <summary>
        ///     Gets or sets the context.
        /// </summary>
        public string Context { get; set; }

        /// <summary>
        ///     Gets or sets the extension.
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        ///     Gets or sets the priority.
        /// </summary>
        public string Priority { get; set; }

        /// <summary>
        ///     Get/Set the amount of time the caller was on ring.
        /// </summary>
        public long RingTime { get; set; }

    }
}
