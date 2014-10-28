using System;
using System.IO;
using System.Threading;
using System.Collections;
using AsterNET.Manager.Action;
using AsterNET.Manager.Event;
using AsterNET.Manager.Response;
using System.Text.RegularExpressions;
using System.Text;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Reflection;
using AsterNET.IO;
using AsterNET.Util;

namespace AsterNET.Manager
{
	#region Event delegate

	public delegate void ManagerEventHandler(object sender, ManagerEvent e);
	public delegate void AgentCallbackLoginEventHandler(object sender, Event.AgentCallbackLoginEvent e);
	public delegate void AgentCallbackLogoffEventHandler(object sender, Event.AgentCallbackLogoffEvent e);
	public delegate void AgentCalledEventHandler(object sender, Event.AgentCalledEvent e);
	public delegate void AgentCompleteEventHandler(object sender, Event.AgentCompleteEvent e);
	public delegate void AgentConnectEventHandler(object sender, Event.AgentConnectEvent e);
	public delegate void AgentDumpEventHandler(object sender, Event.AgentDumpEvent e);
	public delegate void AgentLoginEventHandler(object sender, Event.AgentLoginEvent e);
	public delegate void AgentLogoffEventHandler(object sender, Event.AgentLogoffEvent e);
	public delegate void AgentsCompleteEventHandler(object sender, Event.AgentsCompleteEvent e);
	public delegate void AgentsEventHandler(object sender, Event.AgentsEvent e);
	public delegate void AlarmClearEventHandler(object sender, Event.AlarmClearEvent e);
	public delegate void AlarmEventHandler(object sender, Event.AlarmEvent e);
	public delegate void BridgeEventHandler(object sender, Event.BridgeEvent e);
	public delegate void CdrEventHandler(object sender, Event.CdrEvent e);
	public delegate void DBGetResponseEventHandler(object sender, Event.DBGetResponseEvent e);
	public delegate void DialEventHandler(object sender, Event.DialEvent e);
	public delegate void DTMFEventHandler(object sender, Event.DTMFEvent e);
	public delegate void DNDStateEventHandler(object sender, Event.DNDStateEvent e);
	public delegate void ExtensionStatusEventHandler(object sender, Event.ExtensionStatusEvent e);
	public delegate void HangupEventHandler(object sender, Event.HangupEvent e);
	public delegate void HoldedCallEventHandler(object sender, Event.HoldedCallEvent e);
	public delegate void HoldEventHandler(object sender, Event.HoldEvent e);
	public delegate void JoinEventHandler(object sender, Event.JoinEvent e);
	public delegate void LeaveEventHandler(object sender, Event.LeaveEvent e);
	public delegate void LinkEventHandler(object sender, Event.LinkEvent e);
	public delegate void LogChannelEventHandler(object sender, Event.LogChannelEvent e);
	public delegate void MeetMeJoinEventHandler(object sender, Event.MeetmeJoinEvent e);
	public delegate void MeetMeLeaveEventHandler(object sender, Event.MeetmeLeaveEvent e);
	public delegate void MeetMeTalkingEventHandler(object sender, Event.MeetmeTalkingEvent e);
	public delegate void MessageWaitingEventHandler(object sender, Event.MessageWaitingEvent e);
	public delegate void NewCallerIdEventHandler(object sender, Event.NewCallerIdEvent e);
	public delegate void NewChannelEventHandler(object sender, Event.NewChannelEvent e);
	public delegate void NewExtenEventHandler(object sender, Event.NewExtenEvent e);
	public delegate void NewStateEventHandler(object sender, Event.NewStateEvent e);
	public delegate void OriginateResponseEventHandler(object sender, Event.OriginateResponseEvent e);
	public delegate void ParkedCallEventHandler(object sender, Event.ParkedCallEvent e);
	public delegate void ParkedCallGiveUpEventHandler(object sender, Event.ParkedCallGiveUpEvent e);
	public delegate void ParkedCallsCompleteEventHandler(object sender, Event.ParkedCallsCompleteEvent e);
	public delegate void ParkedCallTimeOutEventHandler(object sender, Event.ParkedCallTimeOutEvent e);
	public delegate void PeerEntryEventHandler(object sender, Event.PeerEntryEvent e);
	public delegate void PeerlistCompleteEventHandler(object sender, Event.PeerlistCompleteEvent e);
	public delegate void PeerStatusEventHandler(object sender, Event.PeerStatusEvent e);
	public delegate void QueueEntryEventHandler(object sender, Event.QueueEntryEvent e);
	public delegate void QueueMemberAddedEventHandler(object sender, Event.QueueMemberAddedEvent e);
	public delegate void QueueMemberEventHandler(object sender, Event.QueueMemberEvent e);
	public delegate void QueueMemberPausedEventHandler(object sender, Event.QueueMemberPausedEvent e);
	public delegate void QueueMemberRemovedEventHandler(object sender, Event.QueueMemberRemovedEvent e);
	public delegate void QueueMemberStatusEventHandler(object sender, Event.QueueMemberStatusEvent e);
	public delegate void QueueParamsEventHandler(object sender, Event.QueueParamsEvent e);
	public delegate void QueueStatusCompleteEventHandler(object sender, Event.QueueStatusCompleteEvent e);
	public delegate void RegistryEventHandler(object sender, Event.RegistryEvent e);
	public delegate void RenameEventHandler(object sender, Event.RenameEvent e);
	public delegate void TransferEventHandler(object sender, Event.TransferEvent e);
	public delegate void StatusCompleteEventHandler(object sender, Event.StatusCompleteEvent e);
	public delegate void StatusEventHandler(object sender, Event.StatusEvent e);
	public delegate void UnholdEventHandler(object sender, Event.UnholdEvent e);
	public delegate void UnlinkEventHandler(object sender, Event.UnlinkEvent e);
	public delegate void UnparkedCallEventHandler(object sender, Event.UnparkedCallEvent e);
	public delegate void UserEventHandler(object sender, Event.UserEvent e);
	public delegate void QueueCallerAbandonEventHandler(object sender, Event.QueueCallerAbandonEvent e);
	public delegate void ZapShowChannelsCompleteEventHandler(object sender, Event.ZapShowChannelsCompleteEvent e);
	public delegate void ZapShowChannelsEventHandler(object sender, Event.ZapShowChannelsEvent e);
	public delegate void ConnectionStateEventHandler(object sender, Event.ConnectionStateEvent e);
	public delegate void VarSetEventHandler(object sender, Event.VarSetEvent e);
	public delegate void AGIExecHandler(object sender, Event.AGIExecEvent e);
	public delegate void ConfbridgeStartEventHandler(object sender, Event.ConfbridgeStartEvent e);
	public delegate void ConfbridgeJoinEventHandler(object sender, Event.ConfbridgeJoinEvent e);
	public delegate void ConfbridgeLeaveEventHandler(object sender, Event.ConfbridgeLeaveEvent e);
	public delegate void ConfbridgeEndEventHandler(object sender, Event.ConfbridgeEndEvent e);
	public delegate void ConfbridgeTalkingEventHandler(object sender, Event.ConfbridgeTalkingEvent e);
    public delegate void FailedACLEventHandler(object sender, Event.FailedACLEvent e);

	#endregion

	/// <summary>
	/// Default implemention of the ManagerConnection interface.
	/// </summary>
	public class ManagerConnection
	{
		#region Variables

#if LOGGER
		private Logger logger = Logger.Instance();
#endif
		private long actionIdCount = 0;
		private string hostname;
		private int port;
		private string username;
		private string password;

		private SocketConnection mrSocket;
		private Thread mrReaderThread;
		private ManagerReader mrReader;

		private int defaultResponseTimeout = 2000;
		private int defaultEventTimeout = 5000;
		private int sleepTime = 50;
		private bool keepAlive = true;
		private bool keepAliveAfterAuthenticationFailure = false;
		private string protocolIdentifier;
		private AsteriskVersion asteriskVersion;
		private Dictionary<int, IResponseHandler> responseHandlers;
		private Dictionary<int, IResponseHandler> pingHandlers;
		private Dictionary<int, IResponseHandler> responseEventHandlers;
		private int pingInterval = 10000;

		private object lockSocket = new object();
		private object lockHandlers = new object();

		private bool enableEvents = true;
		private string version = string.Empty;
		private Encoding socketEncoding = Encoding.ASCII;
		private bool reconnected = false;
		private bool reconnectEnable = false;
		private int reconnectCount;

		private Dictionary<int, ConstructorInfo> registeredEventClasses;
		private Dictionary<int, int> registeredEventHandlers;
		private event ManagerEventHandler internalEvent;
		private bool fireAllEvents = false;
		private Thread callerThread;

		/// <summary> Default Fast Reconnect retry counter.</summary>
		private int reconnectRetryFast = 5;
		/// <summary> Default Maximum Reconnect retry counter.</summary>
		private int reconnectRetryMax = 10;
		/// <summary> Default Fast Reconnect interval in milliseconds.</summary>
		private int reconnectIntervalFast = 5000;
		/// <summary> Default Slow Reconnect interval in milliseconds.</summary>
		private int reconnectIntervalMax = 10000;

		#endregion

        /// <summary>
        /// Allows you to specifiy how events are fired. If false (default) then
        /// events will be fired in order. Otherwise events will be fired as they arrive and 
        /// control logic in your application will need to handle synchronization.
        /// </summary>
	    public bool UseASyncEvents = false;

		#region Events

		/// <summary>
		/// An UnhandledEvent is triggered on unknown event.
		/// </summary>
		public event ManagerEventHandler UnhandledEvent;
		/// <summary>
		/// An AgentCallbackLogin is triggered when an agent is successfully logged in.
		/// </summary>
		public event AgentCallbackLoginEventHandler AgentCallbackLogin;
		/// <summary>
		/// An AgentCallbackLogoff is triggered when an agent that previously logged in is logged of.<br/>
		/// </summary>
		public event AgentCallbackLogoffEventHandler AgentCallbackLogoff;
		/// <summary>
		/// An AgentCalled is triggered when an agent is ring.<br/>
		/// To enable AgentCalled you have to set <code>eventwhencalled = yes</code> in <code>queues.conf</code>.<br/>
		/// </summary>
		public event AgentCalledEventHandler AgentCalled;
		/// <summary>
		/// An AgentCompleteEvent is triggered when at the end of a call if the caller was connected to an agent.
		/// </summary>
		public event AgentCompleteEventHandler AgentComplete;
		/// <summary>
		/// An AgentConnectEvent is triggered when a caller is connected to an agent.
		/// </summary>
		public event AgentConnectEventHandler AgentConnect;
		/// <summary>
		/// An AgentDumpEvent is triggered when an agent dumps the caller while listening to the queue announcement.
		/// </summary>
		public event AgentDumpEventHandler AgentDump;
		/// <summary>
		/// An AgentLoginEvent is triggered when an agent is successfully logged in using AgentLogin.
		/// </summary>
		public event AgentLoginEventHandler AgentLogin;
		/// <summary>
		/// An AgentCallbackLogoffEvent is triggered when an agent that previously logged in using AgentLogin is logged of.
		/// </summary>
		public event AgentLogoffEventHandler AgentLogoff;
		/// <summary>
		/// An AgentsCompleteEvent is triggered after the state of all agents has been reported in response to an AgentsAction.
		/// </summary>
		public event AgentsCompleteEventHandler AgentsComplete;
		/// <summary>
		/// An AgentsEvent is triggered for each agent in response to an AgentsAction.
		/// </summary>
		public event AgentsEventHandler Agents;
		/// <summary>
		/// An AlarmEvent is triggered when a Zap channel leaves alarm state.
		/// </summary>
		public event AlarmClearEventHandler AlarmClear;
		/// <summary>
		/// 
		/// </summary>
		public event BridgeEventHandler Bridge;
		/// <summary>
		/// An AlarmEvent is triggered when a Zap channel enters or changes alarm state.
		/// </summary>
		public event AlarmEventHandler Alarm;
		/// <summary>
		/// A CdrEvent is triggered when a call detail record is generated, usually at the end of a call.
		/// </summary>
		public event CdrEventHandler Cdr;
		public event DBGetResponseEventHandler DBGetResponse;
		/// <summary>
		/// A Dial is triggered whenever a phone attempts to dial someone.<br/>
		/// </summary>
		public event DialEventHandler Dial;
		public event DTMFEventHandler DTMF;
		/// <summary>
		/// A DNDStateEvent is triggered by the Zap channel driver when a channel enters or leaves DND (do not disturb) state.
		/// </summary>
		public event DNDStateEventHandler DNDState;
		/// <summary>
		/// An ExtensionStatus is triggered when the state of an extension changes.<br/>
		/// </summary>
		public event ExtensionStatusEventHandler ExtensionStatus;
		/// <summary>
		/// A Hangup is triggered when a channel is hung up.<br/>
		/// </summary>
		public event HangupEventHandler Hangup;
		/// <summary>
		/// A HoldedCall is triggered when a channel is put on hold.<br/>
		/// </summary>
		public event HoldedCallEventHandler HoldedCall;
		/// <summary>
		/// A Hold is triggered by the SIP channel driver when a channel is put on hold.<br/>
		/// </summary>
		public event HoldEventHandler Hold;
		/// <summary>
		/// A Join is triggered when a channel joines a queue.<br/>
		/// </summary>
		public event JoinEventHandler Join;
		/// <summary>
		/// A Leave is triggered when a channel leaves a queue.<br/>
		/// </summary>
		public event LeaveEventHandler Leave;
		/// <summary>
		/// A Link is triggered when two voice channels are linked together and voice data exchange commences.<br/>
		/// Several Link events may be seen for a single call. This can occur when Asterisk fails to setup a
		/// native bridge for the call.This is when Asterisk must sit between two telephones and perform
		/// CODEC conversion on their behalf.
		/// </summary>
		public event LinkEventHandler Link;
		/// <summary>
		/// A LogChannel is triggered when logging is turned on or off.<br/>
		/// </summary>
		public event LogChannelEventHandler LogChannel;
		/// <summary>
		/// A MeetMeJoin is triggered if a channel joins a meet me conference.<br/>
		/// </summary>
		public event MeetMeJoinEventHandler MeetMeJoin;
		/// <summary>
		/// A MeetMeLeave is triggered if a channel leaves a meet me conference.<br/>
		/// </summary>
		public event MeetMeLeaveEventHandler MeetMeLeave;
		// public event MeetMeStopTalkingEventHandler MeetMeStopTalking;
		/// <summary>
		/// A MeetMeTalkingEvent is triggered when a user starts talking in a meet me conference.<br/>
		/// To enable talker detection you must pass the option 'T' to the MeetMe application.
		/// </summary>
		public event MeetMeTalkingEventHandler MeetMeTalking;
		/// <summary>
		/// A MessageWaiting is triggered when someone leaves voicemail.<br/>
		/// </summary>
		public event MessageWaitingEventHandler MessageWaiting;
		/// <summary>
		/// A NewCallerId is triggered when the caller id of a channel changes.<br/>
		/// </summary>
		public event NewCallerIdEventHandler NewCallerId;
		/// <summary>
		/// A NewChannel is triggered when a new channel is created.<br/>
		/// </summary>
		public event NewChannelEventHandler NewChannel;
		/// <summary>
		/// A NewExten is triggered when a channel is connected to a new extension.<br/>
		/// </summary>
		public event NewExtenEventHandler NewExten;
		/// <summary>
		/// A NewState is triggered when the state of a channel has changed.<br/>
		/// </summary>
		public event NewStateEventHandler NewState;
		// public event OriginateEventHandler Originate;
		/// <summary>
		/// An OriginateFailure is triggered when the execution of an OriginateAction failed.
		/// </summary>
		// public event OriginateFailureEventHandler OriginateFailure;
		/// <summary>
		/// An OriginateSuccess is triggered when the execution of an OriginateAction succeeded.
		/// </summary>
		// public event OriginateSuccessEventHandler OriginateSuccess;
		/// <summary>
		/// An OriginateResponse is triggered when the execution of an Originate.
		/// </summary>
		public event OriginateResponseEventHandler OriginateResponse;
		/// <summary>
		/// A ParkedCall is triggered when a channel is parked (in this case no
		/// action id is set) and in response to a ParkedCallsAction.<br/>
		/// </summary>
		public event ParkedCallEventHandler ParkedCall;
		/// <summary>
		/// A ParkedCallGiveUp is triggered when a channel that has been parked is hung up.<br/>
		/// </summary>
		public event ParkedCallGiveUpEventHandler ParkedCallGiveUp;
		/// <summary>
		/// A ParkedCallsComplete is triggered after all parked calls have been reported in response to a ParkedCallsAction.
		/// </summary>
		public event ParkedCallsCompleteEventHandler ParkedCallsComplete;
		/// <summary>
		/// A ParkedCallTimeOut is triggered when call parking times out for a given channel.<br/>
		/// </summary>
		public event ParkedCallTimeOutEventHandler ParkedCallTimeOut;
		/// <summary>
		/// A PeerEntry is triggered in response to a SIPPeersAction or SIPShowPeerAction and contains information about a peer.<br/>
		/// </summary>
		public event PeerEntryEventHandler PeerEntry;
		/// <summary>
		/// A PeerlistComplete is triggered after the details of all peers has been reported in response to an SIPPeersAction or SIPShowPeerAction.<br/>
		/// </summary>
		public event PeerlistCompleteEventHandler PeerlistComplete;
		/// <summary>
		/// A PeerStatus is triggered when a SIP or IAX client attempts to registrer at this asterisk server.<br/>
		/// </summary>
		public event PeerStatusEventHandler PeerStatus;
		/// <summary>
		/// A QueueEntryEvent is triggered in response to a QueueStatusAction and contains information about an entry in a queue.
		/// </summary>
		public event QueueCallerAbandonEventHandler QueueCallerAbandon;
		/// <summary>
		/// A QueueEntryEvent is triggered in response to a QueueStatusAction and contains information about an entry in a queue.
		/// </summary>
		public event QueueEntryEventHandler QueueEntry;
		/// <summary>
		/// A QueueMemberAddedEvent is triggered when a queue member is added to a queue.
		/// </summary>
		public event QueueMemberAddedEventHandler QueueMemberAdded;
		/// <summary>
		/// A QueueMemberEvent is triggered in response to a QueueStatusAction and contains information about a member of a queue.
		/// </summary>
		public event QueueMemberEventHandler QueueMember;
		/// <summary>
		/// A QueueMemberPausedEvent is triggered when a queue member is paused or unpaused.
		/// </summary>
		public event QueueMemberPausedEventHandler QueueMemberPaused;
		/// <summary>
		/// A QueueMemberRemovedEvent is triggered when a queue member is removed from a queue.
		/// </summary>
		public event QueueMemberRemovedEventHandler QueueMemberRemoved;
		/// <summary>
		/// A QueueMemberStatusEvent shows the status of a QueueMemberEvent.
		/// </summary>
		public event QueueMemberStatusEventHandler QueueMemberStatus;
		/// <summary>
		/// A QueueParamsEvent is triggered in response to a QueueStatusAction and contains the parameters of a queue.
		/// </summary>
		public event QueueParamsEventHandler QueueParams;
		/// <summary>
		/// A QueueStatusCompleteEvent is triggered after the state of all queues has been reported in response to a QueueStatusAction.
		/// </summary>
		public event QueueStatusCompleteEventHandler QueueStatusComplete;
		/// <summary>
		/// A Registry is triggered when this asterisk server attempts to register
		/// as a client at another SIP or IAX server.<br/>
		/// </summary>
		public event RegistryEventHandler Registry;
		/// <summary>
		/// A RenameEvent is triggered when the name of a channel is changed.
		/// </summary>
		public event RenameEventHandler Rename;
		/// <summary>
		/// A StatusCompleteEvent is triggered after the state of all channels has been reported in response to a StatusAction.
		/// </summary>
		public event StatusCompleteEventHandler StatusComplete;
		/// <summary>
		/// A StatusEvent is triggered for each active channel in response to a StatusAction.
		/// </summary>
		public event StatusEventHandler Status;
		/// <summary>
		/// 
		/// </summary>
		public event TransferEventHandler Transfer;
		/// <summary>
		/// An UnholdEvent is triggered by the SIP channel driver when a channel is no longer put on hold.
		/// </summary>
		public event UnholdEventHandler Unhold;
		/// <summary>
		/// An UnlinkEvent is triggered when a link between two voice channels is discontinued, for example, just before call completion.
		/// </summary>
		public event UnlinkEventHandler Unlink;
		/// <summary>
		/// A UnparkedCallEvent is triggered when a channel that has been parked is resumed.
		/// </summary>
		public event UnparkedCallEventHandler UnparkedCall;
		/// <summary>
		/// A ZapShowChannelsEvent is triggered on UserEvent in dialplan.
		/// </summary>
		public event UserEventHandler UserEvents;
		/// <summary>
		/// A ZapShowChannelsCompleteEvent is triggered after the state of all zap channels has been reported in response to a ZapShowChannelsAction.
		/// </summary>
		public event ZapShowChannelsCompleteEventHandler ZapShowChannelsComplete;
		/// <summary>
		/// A ZapShowChannelsEvent is triggered in response to a ZapShowChannelsAction and shows the state of a zap channel.
		/// </summary>
		public event ZapShowChannelsEventHandler ZapShowChannels;
		/// <summary>
		/// A ConnectionState is triggered after Connect/Disconnect/Reload/Shutdown events.
		/// </summary>
		public event ConnectionStateEventHandler ConnectionState;

		/// <summary>
		/// When a variable is set
		/// </summary>
		public event VarSetEventHandler VarSet;

		/// <summary>
		/// AgiExec is execute
		/// </summary>
		public event AGIExecHandler AGIExec;

		/// <summary>
		/// This event is sent when the first user requests a conference and it is instantiated
		/// </summary>
		public event ConfbridgeStartEventHandler ConfbridgeStart;

		/// <summary>
		/// This event is sent when a user joins a conference - either one already in progress or as the first user to join a newly instantiated bridge.
		/// </summary>
		public event ConfbridgeJoinEventHandler ConfbridgeJoin;

		/// <summary>
		/// This event is sent when a user leaves a conference.
		/// </summary>
		public event ConfbridgeLeaveEventHandler ConfbridgeLeave;

		/// <summary>
		/// This event is sent when the last user leaves a conference and it is torn down.
		/// </summary>
		public event ConfbridgeEndEventHandler ConfbridgeEnd;

		/// <summary>
		/// This event is sent when the conference detects that a user has either begin or stopped talking.
		/// </summary>
		public event ConfbridgeTalkingEventHandler ConfbridgeTalking;

        /// <summary>
        /// 
        /// </summary>
        public event FailedACLEventHandler FailedACL;

		#endregion

		#region Constructor - ManagerConnection()
		/// <summary> Creates a new instance.</summary>
		public ManagerConnection()
		{
			callerThread = Thread.CurrentThread;

			socketEncoding = Encoding.ASCII;

			responseHandlers = new Dictionary<int, IResponseHandler>();
			pingHandlers = new Dictionary<int, IResponseHandler>();
			responseEventHandlers = new Dictionary<int, IResponseHandler>();
			registeredEventClasses = new Dictionary<int, ConstructorInfo>();

			Helper.RegisterBuiltinEventClasses(registeredEventClasses);

			registeredEventHandlers = new Dictionary<int, int>();

			#region Event mapping table
			Helper.RegisterEventHandler(registeredEventHandlers, 0, typeof(AgentCallbackLoginEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 1, typeof(AgentCallbackLogoffEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 2, typeof(AgentCalledEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 3, typeof(AgentCompleteEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 4, typeof(AgentConnectEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 5, typeof(AgentDumpEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 6, typeof(AgentLoginEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 7, typeof(AgentLogoffEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 8, typeof(AgentsCompleteEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 9, typeof(AgentsEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 10, typeof(AlarmClearEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 11, typeof(AlarmEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 12, typeof(CdrEvent));

			Helper.RegisterEventHandler(registeredEventHandlers, 14, typeof(DBGetResponseEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 15, typeof(DialEvent));

			Helper.RegisterEventHandler(registeredEventHandlers, 17, typeof(DNDStateEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 18, typeof(ExtensionStatusEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 19, typeof(HangupEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 20, typeof(HoldedCallEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 21, typeof(HoldEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 22, typeof(JoinEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 23, typeof(LeaveEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 24, typeof(LinkEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 25, typeof(LogChannelEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 26, typeof(MeetmeJoinEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 27, typeof(MeetmeLeaveEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 28, typeof(MeetmeTalkingEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 29, typeof(MessageWaitingEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 30, typeof(NewCallerIdEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 31, typeof(NewChannelEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 32, typeof(NewExtenEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 33, typeof(NewStateEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 34, typeof(OriginateResponseEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 35, typeof(ParkedCallEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 36, typeof(ParkedCallGiveUpEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 37, typeof(ParkedCallsCompleteEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 38, typeof(ParkedCallTimeOutEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 39, typeof(PeerEntryEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 40, typeof(PeerlistCompleteEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 41, typeof(PeerStatusEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 42, typeof(QueueEntryEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 43, typeof(QueueMemberAddedEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 44, typeof(QueueMemberEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 45, typeof(QueueMemberPausedEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 46, typeof(QueueMemberRemovedEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 47, typeof(QueueMemberStatusEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 48, typeof(QueueParamsEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 49, typeof(QueueStatusCompleteEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 50, typeof(RegistryEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 51, typeof(QueueCallerAbandonEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 52, typeof(RenameEvent));

			Helper.RegisterEventHandler(registeredEventHandlers, 54, typeof(StatusCompleteEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 55, typeof(StatusEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 56, typeof(UnholdEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 57, typeof(UnlinkEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 58, typeof(UnparkedCallEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 59, typeof(UserEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 60, typeof(ZapShowChannelsCompleteEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 61, typeof(ZapShowChannelsEvent));

			Helper.RegisterEventHandler(registeredEventHandlers, 62, typeof(ConnectEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 62, typeof(DisconnectEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 62, typeof(ReloadEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 62, typeof(ShutdownEvent));

			Helper.RegisterEventHandler(registeredEventHandlers, 63, typeof(BridgeEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 64, typeof(TransferEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 65, typeof(DTMFEvent));

			Helper.RegisterEventHandler(registeredEventHandlers, 70, typeof(VarSetEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 80, typeof(AGIExecEvent));

			Helper.RegisterEventHandler(registeredEventHandlers, 81, typeof(ConfbridgeStartEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 82, typeof(ConfbridgeJoinEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 83, typeof(ConfbridgeLeaveEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 84, typeof(ConfbridgeEndEvent));
			Helper.RegisterEventHandler(registeredEventHandlers, 85, typeof(ConfbridgeTalkingEvent));

            Helper.RegisterEventHandler(registeredEventHandlers, 86, typeof(FailedACLEvent));


			#endregion

			this.internalEvent += new ManagerEventHandler(internalEventHandler);
		}
		#endregion

		#region Constructor - ManagerConnection(hostname, port, username, password)
		/// <summary>
		/// Creates a new instance with the given connection parameters.
		/// </summary>
		/// <param name="hostname">the hosname of the Asterisk server to connect to.</param>
		/// <param name="port">the port where Asterisk listens for incoming Manager API connections, usually 5038.</param>
		/// <param name="username">the username to use for login</param>
		/// <param name="password">the password to use for login</param>
		public ManagerConnection(string hostname, int port, string username, string password)
			: this()
		{
			this.hostname = hostname;
			this.port = port;
			this.username = username;
			this.password = password;
		}
		#endregion

		#region Constructor - ManagerConnection(hostname, port, username, password, Encoding socketEncoding)
		/// <summary>
		/// Creates a new instance with the given connection parameters.
		/// </summary>
		/// <param name="hostname">the hosname of the Asterisk server to connect to.</param>
		/// <param name="port">the port where Asterisk listens for incoming Manager API connections, usually 5038.</param>
		/// <param name="username">the username to use for login</param>
		/// <param name="password">the password to use for login</param>
		/// <param name="socketEncoding">text encoding to asterisk input/output stream</param>
		public ManagerConnection(string hostname, int port, string username, string password, Encoding encoding)
			: this()
		{
			this.hostname = hostname;
			this.port = port;
			this.username = username;
			this.password = password;
			this.socketEncoding = encoding;
		}
		#endregion

		/// <summary>
		/// Default Fast Reconnect retry counter.
		/// </summary>
		public int ReconnectRetryFast
		{
			get { return reconnectRetryFast; }
			set { reconnectRetryFast = value; }
		}
		/// <summary> Default Maximum Reconnect retry counter.</summary>
		public int ReconnectRetryMax
		{
			get { return reconnectRetryMax; }
			set { reconnectRetryMax = value; }
		}
		/// <summary> Default Fast Reconnect interval in milliseconds.</summary>
		public int ReconnectIntervalFast
		{
			get { return reconnectIntervalFast; }
			set { reconnectIntervalFast = value; }
		}
		/// <summary> Default Slow Reconnect interval in milliseconds.</summary>
		public int ReconnectIntervalMax
		{
			get { return reconnectIntervalMax; }
			set { reconnectIntervalMax = value; }
		}

		#region CallerThread
		internal Thread CallerThread
		{
			get { return callerThread; }
		}
		#endregion

		#region internalEventHandler(object sender, ManagerEvent e)
		private void internalEventHandler(object sender, ManagerEvent e)
		{
			int eventHash = e.GetType().Name.GetHashCode();
			if (registeredEventHandlers.ContainsKey(eventHash))
			{
				switch (registeredEventHandlers[eventHash])
				{
					#region A-C
					case 0:
						if (AgentCallbackLogin != null)
						{
							AgentCallbackLogin(this, (AgentCallbackLoginEvent)e);
							return;
						}
						break;
					case 1:
						if (AgentCallbackLogoff != null)
						{
							AgentCallbackLogoff(this, (AgentCallbackLogoffEvent)e);
							return;
						}
						break;
					case 2:
						if (AgentCalled != null)
						{
							AgentCalled(this, (Event.AgentCalledEvent)e);
							return;
						}
						break;
					case 3:
						if (AgentComplete != null)
						{
							AgentComplete(this, (Event.AgentCompleteEvent)e);
							return;
						}
						break;
					case 4:
						if (AgentConnect != null)
						{
							AgentConnect(this, (Event.AgentConnectEvent)e);
							return;
						}
						break;
					case 5:
						if (AgentDump != null)
						{
							AgentDump(this, (Event.AgentDumpEvent)e);
							return;
						}
						break;
					case 6:
						if (AgentLogin != null)
						{
							AgentLogin(this, (Event.AgentLoginEvent)e);
							return;
						}
						break;
					case 7:
						if (AgentLogoff != null)
						{
							AgentLogoff(this, (Event.AgentLogoffEvent)e);
							return;
						}
						break;
					case 8:
						if (AgentsComplete != null)
						{
							AgentsComplete(this, (AgentsCompleteEvent)e);
							return;
						}
						break;
					case 9:
						if (Agents != null)
						{
							Agents(this, (AgentsEvent)e);
							return;
						}
						break;
					case 10:
						if (AlarmClear != null)
						{
							AlarmClear(this, (AlarmClearEvent)e);
							return;
						}
						break;
					case 11:
						if (Alarm != null)
						{
							Alarm(this, (AlarmEvent)e);
							return;
						}
						break;
					case 12:
						if (Cdr != null)
						{
							Cdr(this, (CdrEvent)e);
							return;
						}
						break;
					#endregion
					#region D-L
					case 14:
						if (DBGetResponse != null)
						{
							DBGetResponse(this, (DBGetResponseEvent)e);
							return;
						}
						break;
					case 15:
						if (Dial != null)
						{
							Dial(this, (DialEvent)e);
							return;
						}
						break;
					case 17:
						if (DNDState != null)
						{
							DNDState(this, (DNDStateEvent)e);
							return;
						}
						break;
					case 18:
						if (ExtensionStatus != null)
						{
							ExtensionStatus(this, (ExtensionStatusEvent)e);
							return;
						}
						break;
					case 19:
						if (Hangup != null)
						{
							Hangup(this, (HangupEvent)e);
							return;
						}
						break;
					case 20:
						if (HoldedCall != null)
						{
							HoldedCall(this, (HoldedCallEvent)e);
							return;
						}
						break;
					case 21:
						if (Hold != null)
						{
							Hold(this, (HoldEvent)e);
							return;
						}
						break;
					case 22:
						if (Join != null)
						{
							Join(this, (JoinEvent)e);
							return;
						}
						break;
					case 23:
						if (Leave != null)
						{
							Leave(this, (LeaveEvent)e);
							return;
						}
						break;
					case 24:
						if (Link != null)
						{
							Link(this, (LinkEvent)e);
							return;
						}
						break;
					case 25:
						if (LogChannel != null)
						{
							LogChannel(this, (LogChannelEvent)e);
							return;
						}
						break;
					#endregion
					#region M-P
					case 26:
						if (MeetMeJoin != null)
						{
							MeetMeJoin(this, (MeetmeJoinEvent)e);
							return;
						}
						break;
					case 27:
						if (MeetMeLeave != null)
						{
							MeetMeLeave(this, (MeetmeLeaveEvent)e);
							return;
						}
						break;
					case 28:
						if (MeetMeTalking != null)
						{
							MeetMeTalking(this, (MeetmeTalkingEvent)e);
							return;
						}
						break;
					case 29:
						if (MessageWaiting != null)
						{
							MessageWaiting(this, (MessageWaitingEvent)e);
							return;
						}
						break;
					case 30:
						if (NewCallerId != null)
						{
							NewCallerId(this, (NewCallerIdEvent)e);
							return;
						}
						break;
					case 31:
						if (NewChannel != null)
						{
							NewChannel(this, (NewChannelEvent)e);
							return;
						}
						break;
					case 32:
						if (NewExten != null)
						{
							NewExten(this, (NewExtenEvent)e);
							return;
						}
						break;
					case 33:
						if (NewState != null)
						{
							NewState(this, (NewStateEvent)e);
							return;
						}
						break;
					case 34:
						if (OriginateResponse != null)
						{
							OriginateResponse(this, (OriginateResponseEvent)e);
							return;
						}
						break;
					case 35:
						if (ParkedCall != null)
						{
							ParkedCall(this, (ParkedCallEvent)e);
							return;
						}
						break;
					case 36:
						if (ParkedCallGiveUp != null)
						{
							ParkedCallGiveUp(this, (ParkedCallGiveUpEvent)e);
							return;
						}
						break;
					case 37:
						if (ParkedCallsComplete != null)
						{
							ParkedCallsComplete(this, (ParkedCallsCompleteEvent)e);
							return;
						}
						break;
					case 38:
						if (ParkedCallTimeOut != null)
						{
							ParkedCallTimeOut(this, (ParkedCallTimeOutEvent)e);
							return;
						}
						break;
					case 39:
						if (PeerEntry != null)
						{
							PeerEntry(this, (PeerEntryEvent)e);
							return;
						}
						break;
					case 40:
						if (PeerlistComplete != null)
						{
							PeerlistComplete(this, (PeerlistCompleteEvent)e);
							return;
						}
						break;
					case 41:
						if (PeerStatus != null)
						{
							PeerStatus(this, (PeerStatusEvent)e);
							return;
						}
						break;
					#endregion
					#region Q-Z
					case 42:
						if (QueueEntry != null)
						{
							QueueEntry(this, (QueueEntryEvent)e);
							return;
						}
						break;
					case 43:
						if (QueueMemberAdded != null)
						{
							QueueMemberAdded(this, (QueueMemberAddedEvent)e);
							return;
						}
						break;
					case 44:
						if (QueueMember != null)
						{
							QueueMember(this, (QueueMemberEvent)e);
							return;
						}
						break;
					case 45:
						if (QueueMemberPaused != null)
						{
							QueueMemberPaused(this, (QueueMemberPausedEvent)e);
							return;
						}
						break;
					case 46:
						if (QueueMemberRemoved != null)
						{
							QueueMemberRemoved(this, (QueueMemberRemovedEvent)e);
							return;
						}
						break;
					case 47:
						if (QueueMemberStatus != null)
						{
							QueueMemberStatus(this, (QueueMemberStatusEvent)e);
							return;
						}
						break;
					case 48:
						if (QueueParams != null)
						{
							QueueParams(this, (QueueParamsEvent)e);
							return;
						}
						break;
					case 49:
						if (QueueStatusComplete != null)
						{
							QueueStatusComplete(this, (QueueStatusCompleteEvent)e);
							return;
						}
						break;
					case 50:
						if (Registry != null)
						{
							Registry(this, (RegistryEvent)e);
							return;
						}
						break;
					case 51:
						if (QueueCallerAbandon != null)
						{
							QueueCallerAbandon(this, (QueueCallerAbandonEvent)e);
							return;
						}
						break;
					case 52:
						if (Rename != null)
						{
							Rename(this, (RenameEvent)e);
							return;
						}
						break;
					case 54:
						if (StatusComplete != null)
						{
							StatusComplete(this, (StatusCompleteEvent)e);
							return;
						}
						break;
					case 55:
						if (Status != null)
						{
							Status(this, (StatusEvent)e);
							return;
						}
						break;
					case 56:
						if (Unhold != null)
						{
							Unhold(this, (UnholdEvent)e);
							return;
						}
						break;
					case 57:
						if (Unlink != null)
						{
							Unlink(this, (UnlinkEvent)e);
							return;
						}
						break;
					case 58:
						if (UnparkedCall != null)
						{
							UnparkedCall(this, (UnparkedCallEvent)e);
							return;
						}
						break;
					case 59:
						if (UserEvents != null)
						{
							UserEvents(this, (UserEvent)e);
							return;
						}
						break;
					case 60:
						if (ZapShowChannelsComplete != null)
						{
							ZapShowChannelsComplete(this, (ZapShowChannelsCompleteEvent)e);
							return;
						}
						break;
					case 61:
						if (ZapShowChannels != null)
						{
							ZapShowChannels(this, (ZapShowChannelsEvent)e);
							return;
						}
						break;
					#endregion

					case 62:
						if (ConnectionState != null)
						{
							ConnectionState(this, (ConnectionStateEvent)e);
							return;
						}
						break;
					case 63:
						if (Bridge != null)
						{
							Bridge(this, (BridgeEvent)e);
						}
						break;
					case 64:
						if (Transfer != null)
						{
							Transfer(this, (TransferEvent)e);
						}
						break;
					case 65:
						if (DTMF != null)
						{
							DTMF(this, (DTMFEvent)e);
						}
						break;
					case 70:
						if (VarSet != null)
						{
							VarSet(this, (VarSetEvent)e);
						}
						break;
					case 80:
						if (AGIExec != null)
						{
							AGIExec(this, (AGIExecEvent)e);
						}
						break;
					case 81:
						if (ConfbridgeStart != null)
						{
							ConfbridgeStart(this, (ConfbridgeStartEvent)e);
						}
						break;
					case 82:
						if (ConfbridgeJoin != null)
						{
							ConfbridgeJoin(this, (ConfbridgeJoinEvent)e);
						}
						break;
					case 83:
						if (ConfbridgeLeave != null)
						{
							ConfbridgeLeave(this, (ConfbridgeLeaveEvent)e);
						}
						break;
					case 84:
						if (ConfbridgeEnd != null)
						{
							ConfbridgeEnd(this, (ConfbridgeEndEvent)e);
						}
						break;
					case 85:
						if (ConfbridgeTalking != null)
						{
							ConfbridgeTalking(this, (ConfbridgeTalkingEvent)e);
						}
						break;
                    case 86:
                        if (FailedACL != null)
                        {
                            FailedACL(this, (FailedACLEvent)e);
                        }
                        break;
					default:
						if (UnhandledEvent != null)
							UnhandledEvent(this, e);
						return;
				}
			}
			if (fireAllEvents && UnhandledEvent != null)
				UnhandledEvent(this, e);
		}
		#endregion

		#region FireAllEvents
		/// <summary>
		/// If this property set to <b>true</b> then ManagerConnection send all unassigned events to UnhandledEvent handler,<br/>
		/// if set to <b>false</b> then all unassgned events lost and send only UnhandledEvent.<br/>
		/// Default: <b>false</b>
		/// </summary>
		public bool FireAllEvents
		{
			get { return this.fireAllEvents; }
			set { this.fireAllEvents = value; }
		}
		#endregion

		#region PingInterval
		/// <summary>
		/// Timeout from Ping to Pong. If no Pong received send Disconnect event. Set to zero to disable.
		/// </summary>
		public int PingInterval
		{
			get { return pingInterval; }
			set { pingInterval = value; }
		}
		#endregion

		#region Hostname
		/// <summary> Sets the hostname of the asterisk server to connect to.<br/>
		/// Default is <code>localhost</code>.
		/// </summary>
		public string Hostname
		{
			get { return hostname; }
			set { hostname = value; }
		}
		#endregion

		#region Port
		/// <summary>
		/// Sets the port to use to connect to the asterisk server. This is the port
		/// specified in asterisk's <code>manager.conf</code> file.<br/>
		/// Default is 5038.
		/// </summary>
		public int Port
		{
			get { return port; }
			set { port = value; }
		}
		#endregion

		#region UserName
		/// <summary>
		/// Sets the username to use to connect to the asterisk server. This is the
		/// username specified in asterisk's <code>manager.conf</code> file.
		/// </summary>
		public string Username
		{
			get { return username; }
			set { username = value; }
		}
		#endregion

		#region Password
		/// <summary>
		/// Sets the password to use to connect to the asterisk server. This is the
		/// password specified in asterisk's <code>manager.conf</code> file.
		/// </summary>
		public string Password
		{
			get { return password; }
			set { password = value; }
		}
		#endregion

		#region DefaultResponseTimeout
		/// <summary> Sets the time in milliseconds the synchronous method
		/// will wait for a response before throwing a TimeoutException.<br/>
		/// Default is 2000.
		/// </summary>
		public int DefaultResponseTimeout
		{
			get { return defaultResponseTimeout; }
			set { defaultResponseTimeout = value; }
		}
		#endregion

		#region DefaultEventTimeout
		/// <summary> Sets the time in milliseconds the synchronous method
		/// will wait for a response and the last response event before throwing a TimeoutException.<br/>
		/// Default is 5000.
		/// </summary>
		public int DefaultEventTimeout
		{
			get { return defaultEventTimeout; }
			set { defaultEventTimeout = value; }
		}
		#endregion

		#region SleepTime
		/// <summary> Sets the time in milliseconds the synchronous methods
		/// SendAction(Action.ManagerAction) and
		/// SendAction(Action.ManagerAction, long) will sleep between two checks
		/// for the arrival of a response. This value should be rather small.<br/>
		/// The sleepTime attribute is also used when checking for the protocol
		/// identifer.<br/>
		/// Default is 50.
		/// </summary>
		/// <deprecated> this has been replaced by an interrupt based response checking approach.</deprecated>
		public int SleepTime
		{
			get { return sleepTime; }
			set { sleepTime = value; }
		}
		#endregion

		#region KeepAliveAfterAuthenticationFailure
		/// <summary> Set to <code>true</code> to try reconnecting to ther asterisk serve
		/// even if the reconnection attempt threw an AuthenticationFailedException.<br/>
		/// Default is <code>false</code>.
		/// </summary>
		public bool KeepAliveAfterAuthenticationFailure
		{
			set { keepAliveAfterAuthenticationFailure = value; }
			get { return keepAliveAfterAuthenticationFailure; }
		}
		#endregion

		#region KeepAlive
		/// <summary>
		/// Should we attempt to reconnect when the connection is lost?<br/>
		/// This is set to <code>true</code> after successful login and to <code>false</code> after logoff or after an authentication failure when keepAliveAfterAuthenticationFailure is <code>false</code>.
		/// </summary>
		public bool KeepAlive
		{
			get { return keepAlive; }
			set { keepAlive = value; }
		}
		#endregion

		#region SocketEncoding
		/// <summary>
		/// Socket Encoding - default ASCII
		/// </summary>
		public Encoding SocketEncoding
		{
			get { return socketEncoding; }
			set { socketEncoding = value; }
		}
		#endregion

		#region Version
		public string Version
		{
			get { return version; }
		}
		#endregion

		#region AsteriskVersion
		public AsteriskVersion AsteriskVersion
		{
			get { return asteriskVersion; }
		}
		#endregion

		#region login(timeout)
		/// <summary>
		/// Does the real login, following the steps outlined below.<br/>
		/// Connects to the asterisk server by calling connect() if not already connected<br/>
		/// Waits until the protocol identifier is received. This is checked every sleepTime ms but not longer than timeout ms in total.<br/>
		/// Sends a ChallengeAction requesting a challenge for authType MD5.<br/>
		/// When the ChallengeResponse is received a LoginAction is sent using the calculated key (MD5 hash of the password appended to the received challenge).<br/>
		/// </summary>
		/// <param name="timeout">the maximum time to wait for the protocol identifier (in ms)</param>
		/// <throws>
		/// AuthenticationFailedException if username or password are incorrect and the login action returns an error or if the MD5
		/// hash cannot be computed. The connection is closed in this case.
		/// </throws>
		/// <throws>
		/// TimeoutException if a timeout occurs either while waiting for the
		/// protocol identifier or when sending the challenge or login
		/// action. The connection is closed in this case.
		/// </throws>
		private void login(int timeout)
		{
			enableEvents = false;
			if (reconnected)
			{
#if LOGGER
				logger.Error("Login during reconnect state.");
#endif
				throw new AuthenticationFailedException("Unable login during reconnect state.");
			}

			reconnectEnable = false;
			DateTime start = DateTime.Now;
			do
			{
				if (connect())
				{
					// Increase delay after connection up to 500 ms
					Thread.Sleep(10 * sleepTime);	// 200 milliseconds delay
				}
				try
				{
					Thread.Sleep(4 * sleepTime);	// 200 milliseconds delay
				}
				catch
				{ }

				if (string.IsNullOrEmpty(protocolIdentifier) && timeout > 0 && Helper.GetMillisecondsFrom(start) > timeout)
				{
					disconnect(true);
					throw new TimeoutException("Timeout waiting for protocol identifier");
				}
			} while (string.IsNullOrEmpty(protocolIdentifier));

			ChallengeAction challengeAction = new ChallengeAction();
			Response.ManagerResponse response = SendAction(challengeAction, defaultResponseTimeout * 2);
			if (response is ChallengeResponse)
			{
				ChallengeResponse challengeResponse = (ChallengeResponse)response;
				string key, challenge = challengeResponse.Challenge;
				try
				{
					Util.MD5Support md = Util.MD5Support.GetInstance();
					if (challenge != null)
						md.Update(UTF8Encoding.UTF8.GetBytes(challenge));
					if (password != null)
						md.Update(UTF8Encoding.UTF8.GetBytes(password));
					key = Helper.ToHexString(md.DigestData);
				}
				catch (Exception ex)
				{
					disconnect(true);
#if LOGGER
					logger.Error("Unable to create login key using MD5 Message Digest.", ex);
#endif
					throw new AuthenticationFailedException("Unable to create login key using MD5 Message Digest.", ex);
				}

				Action.LoginAction loginAction = new Action.LoginAction(username, "MD5", key);
				Response.ManagerResponse loginResponse = SendAction(loginAction);
				if (loginResponse is Response.ManagerError)
				{
					disconnect(true);
					throw new AuthenticationFailedException(loginResponse.Message);
				}

				// successfully logged in so assure that we keep trying to reconnect when disconnected
				reconnectEnable = keepAlive;

#if LOGGER
				logger.Info("Successfully logged in");
#endif
				asteriskVersion = determineVersion();
#if LOGGER
				logger.Info("Determined Asterisk version: " + asteriskVersion);
#endif
				enableEvents = true;
				ConnectEvent ce = new ConnectEvent(this);
				ce.ProtocolIdentifier = this.protocolIdentifier;
				DispatchEvent(ce);
			}
			else if (response is ManagerError)
				throw new ManagerException("Unable login to Asterisk - " + response.Message);
			else
				throw new ManagerException("Unknown response during login to Asterisk - " + response.GetType().Name + " with message " + response.Message);

		}
		#endregion

		#region determineVersion()
		protected internal AsteriskVersion determineVersion()
		{
			Response.ManagerResponse response;
			response = SendAction(new Action.CommandAction("core show version"), defaultResponseTimeout * 2);
			if (response is Response.CommandResponse)
			{
				foreach (string line in ((Response.CommandResponse)response).Result)
				{
					foreach (Match m in Common.ASTERISK_VERSION.Matches(line))
					{
						if (m.Groups.Count >= 2)
						{
							version = m.Groups[1].Value;
							if (version.StartsWith("1.4."))
								return AsteriskVersion.ASTERISK_1_4;
							else if (version.StartsWith("1.6."))
								return Manager.AsteriskVersion.ASTERISK_1_6;
							else if (version.StartsWith("1.8."))
								return Manager.AsteriskVersion.ASTERISK_1_8;
							else if (version.StartsWith("10."))
								return Manager.AsteriskVersion.ASTERISK_10;
							else if (version.StartsWith("11."))
								return Manager.AsteriskVersion.ASTERISK_11;
							else if (version.StartsWith("12."))
								return Manager.AsteriskVersion.ASTERISK_12;
                            else if (version.StartsWith("13."))
                                return Manager.AsteriskVersion.ASTERISK_13;
							else
								throw new ManagerException("Unknown Asterisk version " + version);
						}
					}
				}
			}

			Response.ManagerResponse showVersionFilesResponse = SendAction(new Action.CommandAction("show version files"), defaultResponseTimeout * 2);
			if (showVersionFilesResponse is Response.CommandResponse)
			{
				IList showVersionFilesResult = ((Response.CommandResponse)showVersionFilesResponse).Result;
				if (showVersionFilesResult != null && showVersionFilesResult.Count > 0)
				{
					string line1;
					line1 = (string)showVersionFilesResult[0];
					if (line1 != null && line1.StartsWith("File"))
						return AsteriskVersion.ASTERISK_1_2;
				}
			}
			return AsteriskVersion.ASTERISK_1_0;
		}

		#endregion

		#region connect()
		protected internal bool connect()
		{
			bool result = false;
			bool startReader = false;

			lock (lockSocket)
			{
				if (mrSocket == null)
				{
#if LOGGER
					logger.Info("Connecting to {0}:{1}", hostname, port);
#endif
					try
					{
						mrSocket = new SocketConnection(hostname, port, socketEncoding);
						result = mrSocket.IsConnected;
					}
#if LOGGER
					catch (Exception ex)
					{
						logger.Info("Connect - Exception  : {0}", ex.Message);
#else
					catch
					{
#endif
						result = false;
					}
                    if (result)
                    {
                        if (mrReader == null)
                        {
                            mrReader = new ManagerReader(this);
                            mrReaderThread = new Thread(mrReader.Run) { IsBackground = true, Name = "ManagerReader-" + DateTime.Now.Second };
                            mrReader.Socket = mrSocket;
                            startReader = true;
                        }
                        else
                        {
                            mrReader.Socket = mrSocket;
                        }

                        mrReader.Reinitialize();
                    }
                    else
                    {
                        mrSocket = null;
                    }
				}
			}

            if (startReader)
            {
                mrReaderThread.Start();
            }

			return IsConnected();
		}
		#endregion

		#region disconnect()
		/// <summary> Closes the socket connection.</summary>
		private void disconnect(bool withDie)
		{
			lock (lockSocket)
			{
				if (withDie)
				{
					reconnectEnable = false;
					reconnected = false;
					enableEvents = true;
				}

				if (mrReader != null)
				{
					if (withDie)
					{
						mrReader.Die = true;
						mrReader = null;
					}
					else
						mrReader.Socket = null;
				}

				if (this.mrSocket != null)
				{
					mrSocket.Close();
					mrSocket = null;
				}

				responseEventHandlers.Clear();
				responseHandlers.Clear();
				pingHandlers.Clear();
			}
		}
		#endregion

		#region reconnect(bool init)
		/// <summary>
		/// Reconnects to the asterisk server when the connection is lost.<br/>
		/// While keepAlive is <code>true</code> we will try to reconnect.
		/// Reconnection attempts will be stopped when the logoff() method
		/// is called or when the login after a successful reconnect results in an
		/// AuthenticationFailedException suggesting that the manager
		/// credentials have changed and keepAliveAfterAuthenticationFailure is not set.<br/>
		/// This method is called when a DisconnectEvent is received from the reader.
		/// </summary>
		private void reconnect(bool init)
		{
#if LOGGER
			logger.Warning("reconnect (init: {0}), reconnectCount:{1}", init, reconnectCount);
#endif
			if (init)
				reconnectCount = 0;
			else if (reconnectCount++ > reconnectRetryMax)
				reconnectEnable = false;

			if (reconnectEnable)
			{
#if LOGGER
				logger.Warning("Try reconnect.");
#endif
				enableEvents = false;
				reconnected = true;
				disconnect(false);

				int retryCount = 0;
				while (reconnectEnable && !mrReader.Die)
				{
					if (retryCount >= reconnectRetryMax)
						reconnectEnable = false;
					else
					{
						try
						{
							if (retryCount < reconnectRetryFast)
							{
								// Try to reconnect quite fast for the first times
								// this succeeds if the server has just been restarted
#if LOGGER
								logger.Info("Reconnect delay : {0}, retry : {1}", reconnectIntervalFast, retryCount);
#endif
								Thread.Sleep(reconnectIntervalFast);
							}
							else
							{
								// slow down after unsuccessful attempts assuming a shutdown of the server
#if LOGGER
								logger.Info("Reconnect delay : {0}, retry : {1}", reconnectIntervalMax, retryCount);
#endif
								Thread.Sleep(reconnectIntervalMax);
							}
						}
						catch (ThreadInterruptedException)
						{
							continue;
						}
#if LOGGER
						catch (Exception ex)
						{
							logger.Info("Reconnect delay exception : ", ex.Message);
#else
						catch
						{
#endif
							continue;
						}

						try
						{
#if LOGGER
							logger.Info("Try connect.");
#endif
							if (connect())
								break;
						}
#if LOGGER
						catch(Exception ex)
						{
							logger.Info("Connect exception : ", ex.Message);
#else
						catch
						{
#endif
						}
						retryCount++;
					}
				}
			}

			if (!reconnectEnable)
			{
#if LOGGER
				logger.Info("Can't reconnect.");
#endif
				enableEvents = true;
				reconnected = false;
				disconnect(true);
				fireEvent(new DisconnectEvent(this));
			}
		}
		#endregion

		#region createInternalActionId()
		/// <summary>
		/// Creates a new unique internal action id based on the hash code of this connection and a sequence.
		/// </summary>
		private string createInternalActionId()
		{
			return this.GetHashCode() + "_" + (this.actionIdCount++);
		}
		#endregion

		#region Login()
		/// <summary>
		/// Logs in to the Asterisk manager using asterisk's MD5 based
		/// challenge/response protocol. The login is delayed until the protocol
		/// identifier has been received by the reader.
		/// </summary>
		/// <throws>  AuthenticationFailedException if the username and/or password are incorrect</throws>
		/// <throws>  TimeoutException if no response is received within the specified timeout period</throws>
		/// <seealso cref="Action.ChallengeAction"/>
		/// <seealso cref="Action.LoginAction"/>
		public void Login()
		{
			login(defaultResponseTimeout);
		}
		/// <summary>
		/// Log in to the Asterisk manager using asterisk's MD5 based
		/// challenge/response protocol. The login is delayed until the protocol
		/// identifier has been received by the reader.
		/// </summary>
		/// <param name="timeout">Timeout in milliseconds to login.</param>
		public void Login(int timeout)
		{
			login(timeout);
		}
		#endregion

		#region IsConnected()
		/// <summary> Returns <code>true</code> if there is a socket connection to the
		/// asterisk server, <code>false</code> otherwise.
		/// 
		/// </summary>
		/// <returns> <code>true</code> if there is a socket connection to the
		/// asterisk server, <code>false</code> otherwise.
		/// </returns>
		public bool IsConnected()
		{
			bool result = false;
			lock (lockSocket)
				result = mrSocket != null && mrSocket.IsConnected;
			return result;
		}
		#endregion

		#region Logoff()
		/// <summary>
		/// Sends a LogoffAction and disconnects from the server.
		/// </summary>
		public void Logoff()
		{
			lock (lockSocket)
			{
				// stop reconnecting when we got disconnected
				reconnectEnable = false;
				if (mrReader != null && mrSocket != null)
					try
					{
						mrReader.IsLogoff = true;
						SendAction(new Action.LogoffAction());
					}
					catch
					{ }
			}
			disconnect(true);
		}
		#endregion

		#region SendAction(action)
		/// <summary>
		/// Send Action with default timeout.
		/// </summary>
		/// <param name="action"></param>
		/// <returns></returns>
		public Response.ManagerResponse SendAction(Action.ManagerAction action)
		{
			return SendAction(action, defaultResponseTimeout);
		}
		#endregion

		#region SendAction(action, timeout)
		/// <summary>
		/// Send action ans with timeout (milliseconds)
		/// </summary>
		/// <param name="action">action to send</param>
		/// <param name="timeout">timeout in milliseconds</param>
		/// <returns></returns>
		public Response.ManagerResponse SendAction(ManagerAction action, int timeOut)
		{
			AutoResetEvent autoEvent = new AutoResetEvent(false);
			ResponseHandler handler = new ResponseHandler(action, autoEvent);

			int hash = SendAction(action, handler);
			bool result = autoEvent.WaitOne(timeOut <= 0 ? -1 : timeOut, true);

			RemoveResponseHandler(handler);

			if (result)
				return handler.Response;
			throw new TimeoutException("Timeout waiting for response to " + action.Action);
		}
		#endregion

		#region SendAction(action, responseHandler)
		public int SendAction(ManagerAction action, ResponseHandler responseHandler)
		{
			if (action == null)
				throw new ArgumentException("Unable to send action: action is null.");

			if (mrSocket == null)
				throw new SystemException("Unable to send " + action.Action + " action: not connected.");

			// if the responseHandler is null the user is obviously not interested in the response, thats fine.
			string internalActionId = string.Empty;
			if (responseHandler != null)
			{
				internalActionId = createInternalActionId();
				responseHandler.Hash = internalActionId.GetHashCode();
				AddResponseHandler(responseHandler);
			}

			SendToAsterisk(action, internalActionId);

			return responseHandler != null ? responseHandler.Hash : 0;
		}
		#endregion

		#region SendEventGeneratingAction(action)
		public ResponseEvents SendEventGeneratingAction(ManagerActionEvent action)
		{
			return SendEventGeneratingAction(action, defaultEventTimeout);
		}
		#endregion

		#region SendEventGeneratingAction(action, timeout)
		/// <summary>
		/// 
		/// </summary>
		/// <param name="action"></param>
		/// <param name="timeout">wait timeout in milliseconds</param>
		/// <returns></returns>
		public ResponseEvents SendEventGeneratingAction(ManagerActionEvent action, int timeout)
		{
			if (action == null)
				throw new ArgumentException("Unable to send action: action is null.");
			else if (action.ActionCompleteEventClass() == null)
				throw new ArgumentException("Unable to send action: ActionCompleteEventClass is null.");
			else if (!typeof(ResponseEvent).IsAssignableFrom(action.ActionCompleteEventClass()))
				throw new ArgumentException("Unable to send action: ActionCompleteEventClass is not a ResponseEvent.");

			if (mrSocket == null)
				throw new SystemException("Unable to send " + action.Action + " action: not connected.");

			AutoResetEvent autoEvent = new AutoResetEvent(false);
			ResponseEventHandler handler = new ResponseEventHandler(this, action, autoEvent);

			string internalActionId = createInternalActionId();
			handler.Hash = internalActionId.GetHashCode();
			AddResponseHandler(handler);
			AddResponseEventHandler(handler);

			SendToAsterisk(action, internalActionId);

			bool result = autoEvent.WaitOne(timeout <= 0 ? -1 : timeout, true);

			RemoveResponseHandler(handler);
			RemoveResponseEventHandler(handler);

			if (result)
				return handler.ResponseEvents;

			throw new EventTimeoutException("Timeout waiting for response or response events to " + action.Action, handler.ResponseEvents);
		}
		#endregion

		#region Response Handler helpers
		private void AddResponseHandler(IResponseHandler handler)
		{
			lock (lockHandlers)
			{
				if (handler.Action is PingAction)
					pingHandlers[handler.Hash] = handler;
				else
					responseHandlers[handler.Hash] = handler;
			}
		}

		private void AddResponseEventHandler(IResponseHandler handler)
		{
			lock (lockHandlers)
				responseEventHandlers[handler.Hash] = handler;
		}

		internal void RemoveResponseHandler(IResponseHandler handler)
		{
			int hash = handler.Hash;
			if (hash != 0)
				lock (lockHandlers)
					if (responseHandlers.ContainsKey(hash))
						responseHandlers.Remove(hash);
		}

		internal void RemoveResponseEventHandler(IResponseHandler handler)
		{
			int hash = handler.Hash;
			if (hash != 0)
				lock (lockHandlers)
					if (responseEventHandlers.ContainsKey(hash))
						responseEventHandlers.Remove(hash);
		}

		private IResponseHandler GetRemoveResponseHandler(int hash)
		{
			IResponseHandler handler = null;
			if (hash != 0)
				lock (lockHandlers)
					if (responseHandlers.ContainsKey(hash))
					{
						handler = responseHandlers[hash];
						responseHandlers.Remove(hash);
					}
			return handler;
		}

		private IResponseHandler GetRemoveResponseEventHandler(int hash)
		{
			IResponseHandler handler = null;
			if (hash != 0)
				lock (lockHandlers)
					if (responseEventHandlers.ContainsKey(hash))
					{
						handler = responseEventHandlers[hash];
						responseEventHandlers.Remove(hash);
					}
			return handler;
		}

		private IResponseHandler GetResponseHandler(int hash)
		{
			IResponseHandler handler = null;
			if (hash != 0)
				lock (lockHandlers)
					if (responseHandlers.ContainsKey(hash))
						handler = responseHandlers[hash];
			return handler;
		}

		private IResponseHandler GetResponseEventHandler(int hash)
		{
			IResponseHandler handler = null;
			if (hash != 0)
				lock (lockHandlers)
					if (responseEventHandlers.ContainsKey(hash))
						handler = responseEventHandlers[hash];
			return handler;
		}
		#endregion

		#region SendToAsterisk(ManagerAction action, string internalActionId)

		internal void SendToAsterisk(ManagerAction action, string internalActionId)
		{
			if (mrSocket == null)
				throw new SystemException("Unable to send action: socket is null");

			string buffer = BuildAction(action, internalActionId);
#if LOGGER
			logger.Debug("Sent action : '{0}' : {1}", internalActionId, action);
#endif
			if (sa == null)
				sa = new SendToAsteriskDelegate(sendToAsterisk);
			sa.Invoke(buffer);
		}

		private delegate void SendToAsteriskDelegate(string buffer);
		private SendToAsteriskDelegate sa = null;

		private void sendToAsterisk(string buffer)
		{
			mrSocket.Write(buffer);
		}

		#endregion

		#region BuildAction(action)
		public string BuildAction(Action.ManagerAction action)
		{
			return BuildAction(action, null);
		}
		#endregion

		#region BuildAction(action, internalActionId)
		public string BuildAction(ManagerAction action, string internalActionId)
		{
			MethodInfo getter;
			object value;
			StringBuilder sb = new StringBuilder();
			string valueAsString = string.Empty;

			if (typeof(Action.ProxyAction).IsAssignableFrom(action.GetType()))
				sb.Append(string.Concat("ProxyAction: ", action.Action, Common.LINE_SEPARATOR));
			else
				sb.Append(string.Concat("Action: ", action.Action, Common.LINE_SEPARATOR));

			if (string.IsNullOrEmpty(internalActionId))
				valueAsString = action.ActionId;
			else
				valueAsString = string.Concat(internalActionId, Common.INTERNAL_ACTION_ID_DELIMITER, action.ActionId);

			if (!string.IsNullOrEmpty(valueAsString))
				sb.Append(string.Concat("ActionID: ", valueAsString, Common.LINE_SEPARATOR));

			Dictionary<string, MethodInfo> getters = Helper.GetGetters(action.GetType());

			foreach (string name in getters.Keys)
			{
				string nameLower = name.ToLower(Helper.CultureInfo);
				if (nameLower == "class" || nameLower == "action" || nameLower == "actionid")
					continue;

				getter = getters[name];
				Type propType = getter.ReturnType;
				if (!(propType == typeof(string)
					|| propType == typeof(bool)
					|| propType == typeof(double)
					|| propType == typeof(DateTime)
					|| propType == typeof(int)
					|| propType == typeof(long)
					|| propType == typeof(Dictionary<string, string>)
					)
					)
					continue;

				try
				{
					value = getter.Invoke(action, new object[] { });
				}
				catch (UnauthorizedAccessException ex)
				{
#if LOGGER
					logger.Error("Unable to retrieve property '" + name + "' of " + action.GetType(), ex);
					continue;
#else
					throw new ManagerException("Unable to retrieve property '" + name + "' of " + action.GetType(), ex);
#endif
				}
				catch (TargetInvocationException ex)
				{
#if LOGGER
					logger.Error("Unable to retrieve property '" + name + "' of " + action.GetType(), ex);
					continue;
#else
					throw new ManagerException("Unable to retrieve property '" + name + "' of " + action.GetType(), ex);
#endif
				}

				if (value == null)
					continue;
				if (value is string)
				{
					valueAsString = (string)value;
					if (valueAsString.Length == 0)
						continue;
				}
				else if (value is bool)
					valueAsString = ((bool)value ? "true" : "false");
				else if (value is DateTime)
					valueAsString = value.ToString();
				else if (value is IDictionary)
				{
					valueAsString = Helper.JoinVariables((IDictionary)value, Common.LINE_SEPARATOR, ": ");
					if (valueAsString.Length == 0)
						continue;
					sb.Append(valueAsString);
					sb.Append(Common.LINE_SEPARATOR);
					continue;
				}
				else
					valueAsString = value.ToString();

				sb.Append(string.Concat(name, ": ", valueAsString, Common.LINE_SEPARATOR));
			}

			sb.Append(Common.LINE_SEPARATOR);
			return sb.ToString();
		}
		#endregion

		#region GetProtocolIdentifier()
		public string GetProtocolIdentifier()
		{
			return this.protocolIdentifier;
		}
		#endregion

		#region RegisterUserEventClass(class)
		/// <summary>
		/// Register User Event Class
		/// </summary>
		/// <param name="userEventClass"></param>
		public void RegisterUserEventClass(Type userEventClass)
		{
			Helper.RegisterEventClass(registeredEventClasses, userEventClass);
		}
		#endregion

		#region DispatchResponse(response)
		/// <summary>
		/// This method is called by the reader whenever a ManagerResponse is
		/// received. The response is dispatched to the associated <see cref="IManagerResponseHandler"/>ManagerResponseHandler.
		/// </summary>
		/// <param name="response">the response received by the reader</param>
		/// <seealso cref="ManagerReader" />
		internal void DispatchResponse(Dictionary<string, string> buffer)
		{
#if LOGGER
			logger.Debug("Dispatch response packet : {0}", Helper.JoinVariables(buffer, ", ", ": "));
#endif
			DispatchResponse(buffer, null);
		}

		internal void DispatchResponse(ManagerResponse response)
		{
#if LOGGER
			logger.Debug("Dispatch response : {0}", response);
#endif
			DispatchResponse(null, response);
		}

		internal void DispatchResponse(Dictionary<string, string> buffer, ManagerResponse response)
		{
			string responseActionId = string.Empty;
			string actionId = string.Empty;
			IResponseHandler responseHandler = null;

			if (buffer != null)
			{
				if (buffer["response"].ToLower(Helper.CultureInfo) == "error")
					response = new ManagerError(buffer);
				else if (buffer.ContainsKey("actionid"))
					actionId = buffer["actionid"];
			}

			if (response != null)
				actionId = response.ActionId;

			if (!string.IsNullOrEmpty(actionId))
			{
				int hash = Helper.GetInternalActionId(actionId).GetHashCode();
				responseActionId = Helper.StripInternalActionId(actionId);
				responseHandler = GetRemoveResponseHandler(hash);

				if (response != null)
					response.ActionId = responseActionId;
				if (responseHandler != null)
				{
					if (response == null)
					{
						ManagerActionResponse action = responseHandler.Action as ManagerActionResponse;
						if (action == null || (response = action.ActionCompleteResponseClass() as ManagerResponse) == null)
							response = Helper.BuildResponse(buffer);
						else
							Helper.SetAttributes(response, buffer);
						response.ActionId = responseActionId;
					}

					try
					{
						responseHandler.HandleResponse(response);
					}
					catch (Exception ex)
					{
#if LOGGER
						logger.Error("Unexpected exception in responseHandler {0}\n{1}", response, ex);
#else
						throw new ManagerException("Unexpected exception in responseHandler " + responseHandler.GetType().FullName, ex);
#endif
					}
				}
			}
			
			if (response == null && buffer.ContainsKey("ping") && buffer["ping"] == "Pong")
			{
				response = Helper.BuildResponse(buffer);
				foreach (ResponseHandler pingHandler in pingHandlers.Values)
					pingHandler.HandleResponse(response);
				pingHandlers.Clear();
			}

			if (!reconnected)
				return;

			if (response == null)
			{
				response = Helper.BuildResponse(buffer);
				response.ActionId = responseActionId;
			}
#if LOGGER
			logger.Info("Reconnected - DispatchEvent : " + response);
#endif
			#region Support background reconnect
			if (response is ChallengeResponse)
			{
				string key = null;
				if (response.IsSuccess())
				{
					ChallengeResponse challengeResponse = (ChallengeResponse)response;
					string challenge = challengeResponse.Challenge;
					try
					{
						Util.MD5Support md = Util.MD5Support.GetInstance();
						if (challenge != null)
							md.Update(UTF8Encoding.UTF8.GetBytes(challenge));
						if (password != null)
							md.Update(UTF8Encoding.UTF8.GetBytes(password));
						key = Helper.ToHexString(md.DigestData);
					}
#if LOGGER
					catch (Exception ex)
					{
						logger.Error("Unable to create login key using MD5 Message Digest", ex);
#else
					catch
					{
#endif
						key = null;
					}
				}
				bool fail = true;
				if (!string.IsNullOrEmpty(key))
					try
					{
						Action.LoginAction loginAction = new Action.LoginAction(username, "MD5", key);
						SendAction(loginAction, null);
						fail = false;
					}
					catch { }
				if (fail)
					if (keepAliveAfterAuthenticationFailure)
						reconnect(true);
					else
						disconnect(true);
			}
			else if (response is ManagerError)
			{
				if (keepAliveAfterAuthenticationFailure)
					reconnect(true);
				else
					disconnect(true);
			}
			else if (response is ManagerResponse)
			{
				if (response.IsSuccess())
				{
					reconnected = false;
					enableEvents = true;
					reconnectEnable = keepAlive;
					ConnectEvent ce = new ConnectEvent(this);
					ce.Reconnect = true;
					ce.ProtocolIdentifier = protocolIdentifier;
					fireEvent(ce);
				}
				else if (keepAliveAfterAuthenticationFailure)
					reconnect(true);
				else
					disconnect(true);
			}
			#endregion
		}
		#endregion

		#region DispatchEvent(...)
		/// <summary>
		/// This method is called by the reader whenever a ManagerEvent is received.
		/// The event is dispatched to all registered ManagerEventHandlers.
		/// </summary>
		/// <param name="e">the event received by the reader</param>
		/// <seealso cref="ManagerReader"/>
		internal void DispatchEvent(Dictionary<string, string> buffer)
		{
			ManagerEvent e = Helper.BuildEvent(registeredEventClasses, this, buffer);
			DispatchEvent(e);
		}

		internal void DispatchEvent(ManagerEvent e)
		{
#if LOGGER
			logger.Debug("Dispatching event: {0}", e);
#endif

			if (e is ResponseEvent)
			{
				ResponseEvent responseEvent = (ResponseEvent)e;
				if (!string.IsNullOrEmpty(responseEvent.ActionId) && !string.IsNullOrEmpty(responseEvent.InternalActionId))
				{
					ResponseEventHandler eventHandler = (ResponseEventHandler)GetResponseEventHandler(responseEvent.InternalActionId.GetHashCode());
					if (eventHandler != null)
						try
						{
							eventHandler.HandleEvent(e);
						}
						catch (SystemException ex)
						{
#if LOGGER
						logger.Error("Unexpected exception", ex);
#else
							throw ex;
#endif
						}
				}
			}

			#region ConnectEvent
			if (e is ConnectEvent)
			{
				string protocol = ((ConnectEvent)e).ProtocolIdentifier;
#if LOGGER
				logger.Info("Connected via {0}", protocol);
#endif
				if (!string.IsNullOrEmpty(protocol) && protocol.StartsWith("Asterisk Call Manager"))
				{
					this.protocolIdentifier = protocol;
				}
				else
				{
					this.protocolIdentifier = (string.IsNullOrEmpty(protocol) ? "Empty" : protocol);
#if LOGGER
					logger.Warning("Unsupported protocol version '{0}'. Use at your own risk.", protocol);
#endif
				}
				if (reconnected)
				{
#if LOGGER
					logger.Info("Send Challenge action.");
#endif
					ChallengeAction challengeAction = new ChallengeAction();
					try
					{
						SendAction(challengeAction, null);
					}
#if LOGGER
					catch(Exception ex)
					{
						logger.Info("Send Challenge fail : ", ex.Message);
#else
					catch
					{
#endif
						disconnect(true);
					}
					return;
				}
			}
			#endregion

			if (reconnected && e is DisconnectEvent)
			{
				((DisconnectEvent)e).Reconnect = true;
				fireEvent(e);
				reconnect(false);
			}
			else if (!reconnected && reconnectEnable && (e is DisconnectEvent || e is ReloadEvent || e is ShutdownEvent))
			{
				((ConnectionStateEvent)e).Reconnect = true;
				fireEvent(e);
				reconnect(true);
			}
			else
				fireEvent(e);
		}

		private void eventComplete(IAsyncResult result)
		{
		}

		private void fireEvent(ManagerEvent e)
		{
			if (enableEvents && internalEvent != null)
                if(UseASyncEvents)
				    internalEvent.BeginInvoke(this, e, new AsyncCallback(eventComplete), null);
                else
                    internalEvent.Invoke(this, e);
		}
		#endregion
	}
}