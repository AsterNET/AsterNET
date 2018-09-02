namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     An AgentCalledEvent is triggered when an agent is rung.<br />
    ///     To enable AgentCalledEvents you have to set eventwhencalled = yes in queues.conf.<br />
    ///     This event is implemented in apps/app_queue.c<br/>
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_AgentCalled">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerEvent_AgentCalled</see>
    /// </summary>
    public class AgentCalledEvent : AbstractAgentVariables
    {
        /// <summary>
        ///     Creates a new <see cref="AgentCalledEvent"/>.
        /// </summary>
        /// <param name="source"><see cref="ManagerConnection"/></param>
        public AgentCalledEvent(ManagerConnection source)
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
    }
}