using System.Collections;
namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// An AgentCalledEvent is triggered when an agent is rung.<br/>
	/// To enable AgentCalledEvents you have to set <code>eventwhencalled = yes</code> in <code>queues.conf</code>.<br/>
	/// This event is implemented in <code>apps/app_queue.c</code>
	/// </summary>
	public class AgentCalledEvent : AbstractAgentVariables
	{
		private string agentCalled;
		private string agentName;
		private string callerId;
		private string callerIdName;
		private string callerIdNum;
		private string channelCalling;
		private string context;
		private string destinationChannel;
		private string extension;
		private string priority;
		private string queue;

		public string Queue
		{
			get { return this.queue; }
			set { this.queue = value; }
		}
		public string AgentName
		{
			get { return agentName; }
			set { this.agentName = value; }
		}
		public string AgentCalled
		{
			get { return agentCalled; }
			set { this.agentCalled = value; }
		}
		public string ChannelCalling
		{
			get { return channelCalling; }
			set { this.channelCalling = value; }
		}
		public string DestinationChannel
		{
			get { return this.destinationChannel; }
			set { this.destinationChannel = value; }
		}
		public string CallerId
		{
			get { return callerId; }
			set { this.callerId = value; }
		}
		/// <summary>
		/// Get/Set the Caller*ID number of the calling channel.
		/// </summary>
		public string CallerIdNum
		{
			get { return callerIdNum; }
			set { this.callerIdNum = value; }
		}
		/// <summary>
		/// Get/Set the Caller*ID name of the calling channel.
		/// </summary>
		public string CallerIdName
		{
			get { return callerIdName; }
			set { this.callerIdName = value; }
		}
		public string Context
		{
			get { return context; }
			set { this.context = value; }
		}
		public string Extension
		{
			get { return extension; }
			set { this.extension = value; }
		}
		public string Priority
		{
			get { return priority; }
			set { this.priority = value; }
		}
		
		public AgentCalledEvent(ManagerConnection source)
			: base(source)
		{ }
	}
}