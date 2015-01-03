namespace AsterNET.Manager.Event
{
    /// <summary>
    ///     An AgentCalledEvent is triggered when an agent is rung.<br />
    ///     To enable AgentCalledEvents you have to set <code>eventwhencalled = yes</code> in <code>queues.conf</code>.<br />
    ///     This event is implemented in <code>apps/app_queue.c</code>
    /// </summary>
    public class AgentCalledEvent : AbstractAgentVariables
    {
        public AgentCalledEvent(ManagerConnection source)
            : base(source)
        {
        }

        public string Queue { get; set; }

        public string AgentName { get; set; }

        public string AgentCalled { get; set; }

        public string ChannelCalling { get; set; }

        public string DestinationChannel { get; set; }

        public string CallerId { get; set; }

        /// <summary>
        ///     Get/Set the Caller*ID number of the calling channel.
        /// </summary>
        public string CallerIdNum { get; set; }

        /// <summary>
        ///     Get/Set the Caller*ID name of the calling channel.
        /// </summary>
        public string CallerIdName { get; set; }

        public string Context { get; set; }

        public string Extension { get; set; }

        public string Priority { get; set; }
    }
}