using System;
using System.Threading;
using System.Collections;
using AsterNET.Manager.Action;
using AsterNET.Manager.Event;
using AsterNET.Manager.Response;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using AsterNET.IO;
using System.Threading.Tasks;

namespace AsterNET.Manager
{
    /// <summary>
    /// Default implementation of the ManagerConnection interface.
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
        private object lockSocketWrite = new object();
        private object lockHandlers = new object();

        private bool enableEvents = true;
        private string version = string.Empty;
        private Encoding socketEncoding = Encoding.ASCII;
        private bool reconnected = false;
        private bool reconnectEnable = false;
        private int reconnectCount;

        private Dictionary<int, ConstructorInfo> registeredEventClasses;
        private Dictionary<int, Func<ManagerEvent, bool>> registeredEventHandlers;
        private event EventHandler<ManagerEvent> internalEvent;
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

		public char[] VAR_DELIMITER = { '|' };

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
        public event EventHandler<ManagerEvent> UnhandledEvent;
        /// <summary>
        /// An AgentCallbackLogin is triggered when an agent is successfully logged in.
        /// </summary>
        public event EventHandler<AgentCallbackLoginEvent> AgentCallbackLogin;
        /// <summary>
        /// An AgentCallbackLogoff is triggered when an agent that previously logged in is logged of.<br/>
        /// </summary>
        public event EventHandler<AgentCallbackLogoffEvent> AgentCallbackLogoff;
        /// <summary>
        /// An AgentCalled is triggered when an agent is ring.<br/>
        /// To enable AgentCalled you have to set eventwhencalled = yes in queues.conf.<br/>
        /// </summary>
        public event EventHandler<AgentCalledEvent> AgentCalled;
        /// <summary>
        /// An AgentCompleteEvent is triggered when at the end of a call if the caller was connected to an agent.
        /// </summary>
        public event EventHandler<AgentCompleteEvent> AgentComplete;
        /// <summary>
        /// An AgentConnectEvent is triggered when a caller is connected to an agent.
        /// </summary>
        public event EventHandler<AgentConnectEvent> AgentConnect;
        /// <summary>
        /// An AgentDumpEvent is triggered when an agent dumps the caller while listening to the queue announcement.
        /// </summary>
        public event EventHandler<AgentDumpEvent> AgentDump;
        /// <summary>
        /// An AgentLoginEvent is triggered when an agent is successfully logged in using AgentLogin.
        /// </summary>
        public event EventHandler<AgentLoginEvent> AgentLogin;
        /// <summary>
        /// An AgentCallbackLogoffEvent is triggered when an agent that previously logged in using AgentLogin is logged of.
        /// </summary>
        public event EventHandler<AgentLogoffEvent> AgentLogoff;
        /// <summary>
        /// An AgentRingNoAnswer is triggered when an agent was rang and did not answer.<br/>
        /// To enable AgentRingNoAnswer you have to set eventwhencalled = yes in queues.conf.
        /// </summary>
        public event EventHandler<AgentRingNoAnswerEvent> AgentRingNoAnswer;
        /// <summary>
        /// An AgentsCompleteEvent is triggered after the state of all agents has been reported in response to an AgentsAction.
        /// </summary>
        public event EventHandler<AgentsCompleteEvent> AgentsComplete;
        /// <summary>
        /// An AgentsEvent is triggered for each agent in response to an AgentsAction.
        /// </summary>
        public event EventHandler<AgentsEvent> Agents;
        /// <summary>
        /// An AlarmEvent is triggered when a Zap channel leaves alarm state.
        /// </summary>
        public event EventHandler<AlarmClearEvent> AlarmClear;
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<BridgeEvent> Bridge;
        /// <summary>
        /// An AlarmEvent is triggered when a Zap channel enters or changes alarm state.
        /// </summary>
        public event EventHandler<AlarmEvent> Alarm;
        /// <summary>
        /// A CdrEvent is triggered when a call detail record is generated, usually at the end of a call.
        /// </summary>
        public event EventHandler<CdrEvent> Cdr;
        public event EventHandler<DBGetResponseEvent> DBGetResponse;
        /// <summary>
        /// A Dial is triggered whenever a phone attempts to dial someone.<br/>
        /// </summary>
        public event EventHandler<DialEvent> Dial;
        public event EventHandler<DTMFEvent> DTMF;
        /// <summary>
        /// An DTMFBeginEvent is triggered when a DTMF digit has started on a channel.
        /// </summary>
        public event EventHandler<DTMFBeginEvent> DTMFBegin;
        /// <summary>
        /// An DTMFEndEvent is triggered when a DTMF digit has ended on a channel.
        /// </summary>
        public event EventHandler<DTMFEndEvent> DTMFEnd;
        /// <summary>
        /// A DNDStateEvent is triggered by the Zap channel driver when a channel enters or leaves DND (do not disturb) state.
        /// </summary>
        public event EventHandler<DNDStateEvent> DNDState;
        /// <summary>
        /// An ExtensionStatus is triggered when the state of an extension changes.<br/>
        /// </summary>
        public event EventHandler<ExtensionStatusEvent> ExtensionStatus;
        /// <summary>
        /// A Hangup is triggered when a channel is hung up.<br/>
        /// </summary>
        public event EventHandler<HangupEvent> Hangup;
        /// <summary>
        /// A HangupRequestEvent is raised when a channel is hang up.<br/>
        /// </summary>
        public event EventHandler<HangupRequestEvent> HangupRequest;
        /// <summary>
        /// A HoldedCall is triggered when a channel is put on hold.<br/>
        /// </summary>
        public event EventHandler<HoldedCallEvent> HoldedCall;
        /// <summary>
        /// A Hold is triggered by the SIP channel driver when a channel is put on hold.<br/>
        /// </summary>
        public event EventHandler<HoldEvent> Hold;
        /// <summary>
        /// A Join is triggered when a channel joines a queue.<br/>
        /// </summary>
        public event EventHandler<JoinEvent> Join;
        /// <summary>
        /// A Leave is triggered when a channel leaves a queue.<br/>
        /// </summary>
        public event EventHandler<LeaveEvent> Leave;
        /// <summary>
        /// A Link is triggered when two voice channels are linked together and voice data exchange commences.<br/>
        /// Several Link events may be seen for a single call. This can occur when Asterisk fails to setup a
        /// native bridge for the call.This is when Asterisk must sit between two telephones and perform
        /// CODEC conversion on their behalf.
        /// </summary>
        public event EventHandler<LinkEvent> Link;
        /// <summary>
        /// A LogChannel is triggered when logging is turned on or off.<br/>
        /// </summary>
        public event EventHandler<LogChannelEvent> LogChannel;
        /// <summary>
        /// A MeetMeJoin is triggered if a channel joins a meet me conference.<br/>
        /// </summary>
        public event EventHandler<MeetmeJoinEvent> MeetMeJoin;
        /// <summary>
        /// A MeetMeLeave is triggered if a channel leaves a meet me conference.<br/>
        /// </summary>
        public event EventHandler<MeetmeLeaveEvent> MeetMeLeave;
        // public event EventHandler<MeetMeStopTalkingEvent> MeetMeStopTalking;
        /// <summary>
        /// A MeetMeTalkingEvent is triggered when a user starts talking in a meet me conference.<br/>
        /// To enable talker detection you must pass the option 'T' to the MeetMe application.
        /// </summary>
        public event EventHandler<MeetmeTalkingEvent> MeetMeTalking;
        /// <summary>
        /// A MessageWaiting is triggered when someone leaves voicemail.<br/>
        /// </summary>
        public event EventHandler<MessageWaitingEvent> MessageWaiting;
        /// <summary>
        /// A NewCallerId is triggered when the caller id of a channel changes.<br/>
        /// </summary>
        public event EventHandler<NewCallerIdEvent> NewCallerId;
        /// <summary>
        /// A NewChannel is triggered when a new channel is created.<br/>
        /// </summary>
        public event EventHandler<NewChannelEvent> NewChannel;
        /// <summary>
        /// A NewExten is triggered when a channel is connected to a new extension.<br/>
        /// </summary>
        public event EventHandler<NewExtenEvent> NewExten;
        /// <summary>
        /// A NewState is triggered when the state of a channel has changed.<br/>
        /// </summary>
        public event EventHandler<NewStateEvent> NewState;
        // public event EventHandler<OriginateEvent> Originate;
        /// <summary>
        /// An OriginateFailure is triggered when the execution of an OriginateAction failed.
        /// </summary>
        // public event EventHandler<OriginateFailureEvent> OriginateFailure;
        /// <summary>
        /// An OriginateSuccess is triggered when the execution of an OriginateAction succeeded.
        /// </summary>
        // public event EventHandler<OriginateSuccessEvent> OriginateSuccess;
        /// <summary>
        /// An OriginateResponse is triggered when the execution of an Originate.
        /// </summary>
        public event EventHandler<OriginateResponseEvent> OriginateResponse;
        /// <summary>
        /// A ParkedCall is triggered when a channel is parked (in this case no
        /// action id is set) and in response to a ParkedCallsAction.<br/>
        /// </summary>
        public event EventHandler<ParkedCallEvent> ParkedCall;
        /// <summary>
        /// A ParkedCallGiveUp is triggered when a channel that has been parked is hung up.<br/>
        /// </summary>
        public event EventHandler<ParkedCallGiveUpEvent> ParkedCallGiveUp;
        /// <summary>
        /// A ParkedCallsComplete is triggered after all parked calls have been reported in response to a ParkedCallsAction.
        /// </summary>
        public event EventHandler<ParkedCallsCompleteEvent> ParkedCallsComplete;
        /// <summary>
        /// A ParkedCallTimeOut is triggered when call parking times out for a given channel.<br/>
        /// </summary>
        public event EventHandler<ParkedCallTimeOutEvent> ParkedCallTimeOut;
        /// <summary>
        /// A PeerEntry is triggered in response to a SIPPeersAction or SIPShowPeerAction and contains information about a peer.<br/>
        /// </summary>
        public event EventHandler<PeerEntryEvent> PeerEntry;
        /// <summary>
        /// A PeerlistComplete is triggered after the details of all peers has been reported in response to an SIPPeersAction or SIPShowPeerAction.<br/>
        /// </summary>
        public event EventHandler<PeerlistCompleteEvent> PeerlistComplete;
        /// <summary>
        /// A PeerStatus is triggered when a SIP or IAX client attempts to registrer at this asterisk server.<br/>
        /// </summary>
        public event EventHandler<PeerStatusEvent> PeerStatus;
        /// <summary>
        /// A QueueEntryEvent is triggered in response to a QueueStatusAction and contains information about an entry in a queue.
        /// </summary>
        public event EventHandler<QueueCallerAbandonEvent> QueueCallerAbandon;
        /// <summary>
        /// A QueueEntryEvent is triggered in response to a QueueStatusAction and contains information about an entry in a queue.
        /// </summary>
        public event EventHandler<QueueEntryEvent> QueueEntry;
        /// <summary>
        /// A QueueMemberAddedEvent is triggered when a queue member is added to a queue.
        /// </summary>
        public event EventHandler<QueueMemberAddedEvent> QueueMemberAdded;
        /// <summary>
        /// A QueueMemberEvent is triggered in response to a QueueStatusAction and contains information about a member of a queue.
        /// </summary>
        public event EventHandler<QueueMemberEvent> QueueMember;
        /// <summary>
        /// A QueueMemberPausedEvent is triggered when a queue member is paused or unpaused.
        /// <b>Replaced by : </b> <see cref="QueueMemberPauseEvent"/> since <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+12+Documentation" target="_blank" alt="Asterisk 12 wiki docs">Asterisk 12</see>.<br/>
        /// <b>Removed since : </b> <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+13+Documentation" target="_blank" alt="Asterisk 13 wiki docs">Asterisk 13</see>.<br/>
        /// </summary>
        public event EventHandler<QueueMemberPausedEvent> QueueMemberPaused;
        /// <summary>
        /// A QueueMemberRemovedEvent is triggered when a queue member is removed from a queue.
        /// </summary>
        public event EventHandler<QueueMemberRemovedEvent> QueueMemberRemoved;
        /// <summary>
        /// A QueueMemberStatusEvent shows the status of a QueueMemberEvent.
        /// </summary>
        public event EventHandler<QueueMemberStatusEvent> QueueMemberStatus;
        /// <summary>
        /// A QueueParamsEvent is triggered in response to a QueueStatusAction and contains the parameters of a queue.
        /// </summary>
        public event EventHandler<QueueParamsEvent> QueueParams;
        /// <summary>
        /// A QueueStatusCompleteEvent is triggered after the state of all queues has been reported in response to a QueueStatusAction.
        /// </summary>
        public event EventHandler<QueueStatusCompleteEvent> QueueStatusComplete;
        /// <summary>
        /// A Registry is triggered when this asterisk server attempts to register
        /// as a client at another SIP or IAX server.<br/>
        /// </summary>
        public event EventHandler<RegistryEvent> Registry;
        /// <summary>
        /// A RenameEvent is triggered when the name of a channel is changed.
        /// </summary>
        public event EventHandler<RenameEvent> Rename;
        /// <summary>
        /// A StatusCompleteEvent is triggered after the state of all channels has been reported in response to a StatusAction.
        /// </summary>
        public event EventHandler<StatusCompleteEvent> StatusComplete;
        /// <summary>
        /// A StatusEvent is triggered for each active channel in response to a StatusAction.
        /// </summary>
        public event EventHandler<StatusEvent> Status;
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<TransferEvent> Transfer;
        /// <summary>
        /// An UnholdEvent is triggered by the SIP channel driver when a channel is no longer put on hold.
        /// </summary>
        public event EventHandler<UnholdEvent> Unhold;
        /// <summary>
        /// An UnlinkEvent is triggered when a link between two voice channels is discontinued, for example, just before call completion.
        /// </summary>
        public event EventHandler<UnlinkEvent> Unlink;
        /// <summary>
        /// A UnparkedCallEvent is triggered when a channel that has been parked is resumed.
        /// </summary>
        public event EventHandler<UnparkedCallEvent> UnparkedCall;
        /// <summary>
        /// A ZapShowChannelsEvent is triggered on UserEvent in dialplan.
        /// </summary>
        public event EventHandler<UserEvent> UserEvents;
        /// <summary>
        /// A ZapShowChannelsCompleteEvent is triggered after the state of all zap channels has been reported in response to a ZapShowChannelsAction.
        /// </summary>
        public event EventHandler<ZapShowChannelsCompleteEvent> ZapShowChannelsComplete;
        /// <summary>
        /// A ZapShowChannelsEvent is triggered in response to a ZapShowChannelsAction and shows the state of a zap channel.
        /// </summary>
        public event EventHandler<ZapShowChannelsEvent> ZapShowChannels;
        /// <summary>
        /// A ConnectionState is triggered after Connect/Disconnect/Shutdown events.
        /// </summary>
        public event EventHandler<ConnectionStateEvent> ConnectionState;

        /// <summary>
        /// A Reload is triggered after Reload events.
        /// </summary>
        public event EventHandler<ReloadEvent> Reload;

        /// <summary>
        /// When a variable is set
        /// </summary>
        public event EventHandler<VarSetEvent> VarSet;

        /// <summary>
        /// AgiExec is execute
        /// </summary>
        public event EventHandler<AGIExecEvent> AGIExec;

        /// <summary>
        /// This event is sent when the first user requests a conference and it is instantiated
        /// </summary>
        public event EventHandler<ConfbridgeStartEvent> ConfbridgeStart;

        /// <summary>
        /// This event is sent when a user joins a conference - either one already in progress or as the first user to join a newly instantiated bridge.
        /// </summary>
        public event EventHandler<ConfbridgeJoinEvent> ConfbridgeJoin;

        /// <summary>
        /// This event is sent when a user leaves a conference.
        /// </summary>
        public event EventHandler<ConfbridgeLeaveEvent> ConfbridgeLeave;

        /// <summary>
        /// This event is sent when the last user leaves a conference and it is torn down.
        /// </summary>
        public event EventHandler<ConfbridgeEndEvent> ConfbridgeEnd;

        /// <summary>
        /// This event is sent when the conference detects that a user has either begin or stopped talking.
        /// </summary>
        public event EventHandler<ConfbridgeTalkingEvent> ConfbridgeTalking;

        /// <summary>
        /// This event is sent when a Confbridge participant mutes.
        /// </summary>
        public event EventHandler<ConfbridgeMuteEvent> ConfbridgeMute;

        /// <summary>
        /// This event is sent when a Confbridge participant unmutes.
        /// </summary>
        public event EventHandler<ConfbridgeUnmuteEvent> ConfbridgeUnmute;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<FailedACLEvent> FailedACL;

        public event EventHandler<AttendedTransferEvent> AttendedTransfer;
        public event EventHandler<BlindTransferEvent> BlindTransfer;

        public event EventHandler<BridgeCreateEvent> BridgeCreate;
        public event EventHandler<BridgeDestroyEvent> BridgeDestroy;
        public event EventHandler<BridgeEnterEvent> BridgeEnter;
        public event EventHandler<BridgeLeaveEvent> BridgeLeave;

        /// <summary>
        /// Raised when a dial action has started.<br/>
        /// </summary>
        public event EventHandler<DialBeginEvent> DialBegin;

        /// <summary>
        /// Raised when a dial action has completed.<br/>
        /// </summary>
        public event EventHandler<DialEndEvent> DialEnd;

        /// <summary>
        /// Raised when a caller joins a Queue.<br/>
        /// </summary>
        public event EventHandler<QueueCallerJoinEvent> QueueCallerJoin;

        /// <summary>
        /// Raised when a caller leaves a Queue.<br/>
        /// </summary>
        public event EventHandler<QueueCallerLeaveEvent> QueueCallerLeave;

        /// <summary>
        /// A QueueMemberPauseEvent is triggered when a queue member is paused or unpaused.<br />
        /// <b>Available since : </b> <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+12+Documentation" target="_blank" alt="Asterisk 12 wiki docs">Asterisk 12</see>.
        /// </summary>
        public event EventHandler<QueueMemberPauseEvent> QueueMemberPause;

        /// <summary>
        ///    Raised when music on hold has started/stopped on a channel.<br />
        ///    <b>Available since : </b> Asterisk 1.6.
        /// </summary>
        public event EventHandler<MusicOnHoldEvent> MusicOnHold;

        /// <summary>
        ///    Raised when music on hold has started on a channel.<br />
        ///    <b>Available since : </b> <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+12+Documentation" target="_blank" alt="Asterisk 12 wiki docs">Asterisk 12</see>.
        /// </summary>
        public event EventHandler<MusicOnHoldStartEvent> MusicOnHoldStart;

        /// <summary>
        ///    Raised when music on hold has stopped on a channel.<br />
        ///    <b>Available since : </b> <see href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+12+Documentation" target="_blank" alt="Asterisk 12 wiki docs">Asterisk 12</see>.
        /// </summary>
        public event EventHandler<MusicOnHoldStopEvent> MusicOnHoldStop;

        /// <summary>
        /// A ChallengeResponseFailed is triggered when a request's attempt to authenticate has been challenged, and the request failed the authentication challenge.
        /// </summary>
        public event EventHandler<ChallengeResponseFailedEvent> ChallengeResponseFailed;

        /// <summary>
        /// A InvalidAccountID is triggered when a request fails an authentication check due to an invalid account ID.
        /// </summary>
        public event EventHandler<InvalidAccountIDEvent> InvalidAccountID;

        /// <summary>
        /// A DeviceStateChanged is triggered when a device state changes.
        /// </summary>
        public event EventHandler<DeviceStateChangeEvent> DeviceStateChanged;

        /// <summary>
        /// A ChallengeSent is triggered when an Asterisk service sends an authentication challenge to a request..
        /// </summary>
        public event EventHandler<ChallengeSentEvent> ChallengeSent;

        /// <summary>
        /// A SuccessfulAuth is triggered when a request successfully authenticates with a service.
        /// </summary>
        public event EventHandler<SuccessfulAuthEvent> SuccessfulAuth;

        /// <summary>
        /// Raised when call queue summary
        /// </summary>
        public event EventHandler<QueueSummaryEvent> QueueSummary;

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

            registeredEventHandlers = new Dictionary<int, Func<ManagerEvent, bool>>();

            #region Event mapping table
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(AgentCallbackLoginEvent), arg => fireEvent(AgentCallbackLogin, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(AgentCallbackLogoffEvent), arg => fireEvent(AgentCallbackLogoff, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(AgentCalledEvent), arg => fireEvent(AgentCalled, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(AgentCompleteEvent), arg => fireEvent(AgentComplete, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(AgentConnectEvent), arg => fireEvent(AgentConnect, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(AgentDumpEvent), arg => fireEvent(AgentDump, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(AgentLoginEvent), arg => fireEvent(AgentLogin, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(AgentLogoffEvent), arg => fireEvent(AgentLogoff, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(AgentRingNoAnswerEvent), arg => fireEvent(AgentRingNoAnswer, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(AgentsCompleteEvent), arg => fireEvent(AgentsComplete, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(AgentsEvent), arg => fireEvent(Agents, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(AlarmClearEvent), arg => fireEvent(AlarmClear, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(AlarmEvent), arg => fireEvent(Alarm, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(CdrEvent), arg => fireEvent(Cdr, arg));

            Helper.RegisterEventHandler(registeredEventHandlers, typeof(DBGetResponseEvent), arg => fireEvent(DBGetResponse, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(DialEvent), arg => fireEvent(Dial, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(DNDStateEvent), arg => fireEvent(DNDState, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(ExtensionStatusEvent), arg => fireEvent(ExtensionStatus, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(HangupEvent), arg => fireEvent(Hangup, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(HangupRequestEvent), arg => fireEvent(HangupRequest, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(HoldedCallEvent), arg => fireEvent(HoldedCall, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(HoldEvent), arg => fireEvent(Hold, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(JoinEvent), arg => fireEvent(Join, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(LeaveEvent), arg => fireEvent(Leave, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(LinkEvent), arg => fireEvent(Link, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(LogChannelEvent), arg => fireEvent(LogChannel, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(MeetmeJoinEvent), arg => fireEvent(MeetMeJoin, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(MeetmeLeaveEvent), arg => fireEvent(MeetMeLeave, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(MeetmeTalkingEvent), arg => fireEvent(MeetMeTalking, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(MessageWaitingEvent), arg => fireEvent(MessageWaiting, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(NewCallerIdEvent), arg => fireEvent(NewCallerId, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(NewChannelEvent), arg => fireEvent(NewChannel, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(NewExtenEvent), arg => fireEvent(NewExten, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(NewStateEvent), arg => fireEvent(NewState, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(OriginateResponseEvent), arg => fireEvent(OriginateResponse, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(ParkedCallEvent), arg => fireEvent(ParkedCall, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(ParkedCallGiveUpEvent), arg => fireEvent(ParkedCallGiveUp, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(ParkedCallsCompleteEvent), arg => fireEvent(ParkedCallsComplete, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(ParkedCallTimeOutEvent), arg => fireEvent(ParkedCallTimeOut, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(PeerEntryEvent), arg => fireEvent(PeerEntry, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(PeerlistCompleteEvent), arg => fireEvent(PeerlistComplete, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(PeerStatusEvent), arg => fireEvent(PeerStatus, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(QueueEntryEvent), arg => fireEvent(QueueEntry, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(QueueMemberAddedEvent), arg => fireEvent(QueueMemberAdded, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(QueueMemberEvent), arg => fireEvent(QueueMember, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(QueueMemberPausedEvent), arg => fireEvent(QueueMemberPaused, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(QueueMemberRemovedEvent), arg => fireEvent(QueueMemberRemoved, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(QueueMemberStatusEvent), arg => fireEvent(QueueMemberStatus, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(QueueParamsEvent), arg => fireEvent(QueueParams, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(QueueStatusCompleteEvent), arg => fireEvent(QueueStatusComplete, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(RegistryEvent), arg => fireEvent(Registry, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(QueueCallerAbandonEvent), arg => fireEvent(QueueCallerAbandon, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(RenameEvent), arg => fireEvent(Rename, arg));

            Helper.RegisterEventHandler(registeredEventHandlers, typeof(StatusCompleteEvent), arg => fireEvent(StatusComplete, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(StatusEvent), arg => fireEvent(Status, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(UnholdEvent), arg => fireEvent(Unhold, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(UnlinkEvent), arg => fireEvent(Unlink, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(UnparkedCallEvent), arg => fireEvent(UnparkedCall, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(UserEvent), arg => fireEvent(UserEvents, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(ZapShowChannelsCompleteEvent), arg => fireEvent(ZapShowChannelsComplete, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(ZapShowChannelsEvent), arg => fireEvent(ZapShowChannels, arg));

            Helper.RegisterEventHandler(registeredEventHandlers, typeof(ConnectEvent), arg => fireEvent(ConnectionState, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(DisconnectEvent), arg => fireEvent(ConnectionState, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(ReloadEvent), arg => fireEvent(Reload, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(ShutdownEvent), arg => fireEvent(ConnectionState, arg));

            Helper.RegisterEventHandler(registeredEventHandlers, typeof(BridgeEvent), arg => fireEvent(Bridge, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(TransferEvent), arg => fireEvent(Transfer, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(DTMFEvent), arg => fireEvent(DTMF, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(DTMFBeginEvent), arg => fireEvent(DTMFBegin, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(DTMFEndEvent), arg => fireEvent(DTMFEnd, arg));

            Helper.RegisterEventHandler(registeredEventHandlers, typeof(VarSetEvent), arg => fireEvent(VarSet, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(AGIExecEvent), arg => fireEvent(AGIExec, arg));

            Helper.RegisterEventHandler(registeredEventHandlers, typeof(ConfbridgeStartEvent), arg => fireEvent(ConfbridgeStart, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(ConfbridgeJoinEvent), arg => fireEvent(ConfbridgeJoin, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(ConfbridgeLeaveEvent), arg => fireEvent(ConfbridgeLeave, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(ConfbridgeEndEvent), arg => fireEvent(ConfbridgeEnd, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(ConfbridgeTalkingEvent), arg => fireEvent(ConfbridgeTalking, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(ConfbridgeMuteEvent), arg => fireEvent(ConfbridgeMute, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(ConfbridgeUnmuteEvent), arg => fireEvent(ConfbridgeUnmute, arg));

            Helper.RegisterEventHandler(registeredEventHandlers, typeof(FailedACLEvent), arg => fireEvent(FailedACL, arg));

            Helper.RegisterEventHandler(registeredEventHandlers, typeof(AttendedTransferEvent), arg => fireEvent(AttendedTransfer, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(BridgeCreateEvent), arg => fireEvent(BridgeCreate, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(BridgeDestroyEvent), arg => fireEvent(BridgeDestroy, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(BridgeEnterEvent), arg => fireEvent(BridgeEnter, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(BridgeLeaveEvent), arg => fireEvent(BridgeLeave, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(BlindTransferEvent), arg => fireEvent(BlindTransfer, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(DialBeginEvent), arg => fireEvent(DialBegin, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(DialEndEvent), arg => fireEvent(DialEnd, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(QueueCallerJoinEvent), arg => fireEvent(QueueCallerJoin, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(QueueCallerLeaveEvent), arg => fireEvent(QueueCallerLeave, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(QueueMemberPauseEvent), arg => fireEvent(QueueMemberPause, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(MusicOnHoldEvent), arg => fireEvent(MusicOnHold, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(MusicOnHoldStartEvent), arg => fireEvent(MusicOnHoldStart, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(MusicOnHoldStopEvent), arg => fireEvent(MusicOnHoldStop, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(ChallengeResponseFailedEvent), arg => fireEvent(ChallengeResponseFailed, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(InvalidAccountIDEvent), arg => fireEvent(InvalidAccountID, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(DeviceStateChangeEvent), arg => fireEvent(DeviceStateChanged, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(ChallengeSentEvent), arg => fireEvent(ChallengeSent, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(SuccessfulAuthEvent), arg => fireEvent(SuccessfulAuth, arg));
            Helper.RegisterEventHandler(registeredEventHandlers, typeof(QueueSummaryEvent), arg => fireEvent(QueueSummary, arg));
            
            #endregion

            this.internalEvent += new EventHandler<ManagerEvent>(internalEventHandler);
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
        public ManagerConnection(string hostname, int port, string username, string password, Encoding socketEncoding)
            : this()
        {
            this.hostname = hostname;
            this.port = port;
            this.username = username;
            this.password = password;
            this.socketEncoding = socketEncoding;
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
                var currentEvent = registeredEventHandlers[eventHash];
                if (currentEvent(e))
                {
                    return;
                }
            }

            if (fireAllEvents)
            {
                fireEvent(UnhandledEvent, e);
            }
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
        /// Default is localhost.
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
        /// specified in asterisk's manager.conf file.<br/>
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
        /// username specified in asterisk's manager.conf file.
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
        /// password specified in asterisk's manager.conf file.
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
        /// <summary> Set to true to try reconnecting to ther asterisk serve
        /// even if the reconnection attempt threw an AuthenticationFailedException.<br/>
        /// Default is false.
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
        /// This is set to true after successful login and to false after logoff or after an authentication failure when keepAliveAfterAuthenticationFailure is false.
        /// </summary>
        public bool KeepAlive
        {
            get { return keepAlive; }
            set { keepAlive = value; }
        }
        #endregion

        #region Socket Settings

        /// <summary>
        /// Socket Encoding - default ASCII
        /// </summary>
        /// <remarks>
        /// Attention!
        /// <para>
        /// The value of this property must be set before establishing a connection with the Asterisk.
        /// Changing the property doesn't do anything while you are already connected.
        /// </para>
        /// </remarks>
        public Encoding SocketEncoding
        {
            get { return socketEncoding; }
            set { socketEncoding = value; }
        }

        /// <summary>
        /// Socket Receive Buffer Size
        /// </summary>
        /// <remarks>
        /// Attention!
        /// <para>
        /// The value of this property must be set before establishing a connection with the Asterisk.
        /// Changing the property doesn't do anything while you are already connected.
        /// </para>
        /// </remarks>
        public int SocketReceiveBufferSize { get; set;}

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
                    Thread.Sleep(10 * sleepTime);   // 200 milliseconds delay
                }
                try
                {
                    Thread.Sleep(4 * sleepTime);    // 200 milliseconds delay
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
							{
								VAR_DELIMITER = new char[] { '|' };
								return AsteriskVersion.ASTERISK_1_4;
							}
							else if (version.StartsWith("1.6."))
							{
								VAR_DELIMITER = new char[] { '|' };
								return Manager.AsteriskVersion.ASTERISK_1_6;
							}
							else if (version.StartsWith("1.8."))
							{
								VAR_DELIMITER = new char[] { '|' };
								return Manager.AsteriskVersion.ASTERISK_1_8;
							}
							else if (version.StartsWith("10."))
							{
								VAR_DELIMITER = new char[] { '|' };
								return Manager.AsteriskVersion.ASTERISK_10;
							}
							else if (version.StartsWith("11."))
							{
								VAR_DELIMITER = new char[] { ',' };
								return Manager.AsteriskVersion.ASTERISK_11;
							}
							else if (version.StartsWith("12."))
							{
								VAR_DELIMITER = new char[] { ',' };
								return Manager.AsteriskVersion.ASTERISK_12;
							}
							else if (version.StartsWith("13."))
							{
								VAR_DELIMITER = new char[] { ',' };
								return Manager.AsteriskVersion.ASTERISK_13;
							}
							else if (version.StartsWith("14."))
							{
								VAR_DELIMITER = new char[] { ',' };
								return Manager.AsteriskVersion.ASTERISK_14;
							}
							else if (version.StartsWith("15."))
							{
								VAR_DELIMITER = new char[] { ',' };
								return Manager.AsteriskVersion.ASTERISK_15;
							}
							else if (version.StartsWith("16."))
							{
								VAR_DELIMITER = new char[] { ',' };
								return Manager.AsteriskVersion.ASTERISK_16;
							}
							else if (version.StartsWith("17."))
							{
								VAR_DELIMITER = new char[] { ',' };
								return Manager.AsteriskVersion.ASTERISK_17;
							}
							else if (version.IndexOf('.') >= 2)
							{
								VAR_DELIMITER = new char[] { ',' };
								return Manager.AsteriskVersion.ASTERISK_Newer;
							}
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
					{
						VAR_DELIMITER = new char[] { '|' };
						return AsteriskVersion.ASTERISK_1_2;
					}
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
                        if (SocketReceiveBufferSize>0)
                            mrSocket = new SocketConnection(hostname, port, SocketReceiveBufferSize, socketEncoding);
                        else
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
        /// While keepAlive is true we will try to reconnect.
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
                        catch (Exception ex)
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
        /// <summary> Returns true if there is a socket connection to the
        /// asterisk server, false otherwise.
        /// 
        /// </summary>
        /// <returns> true if there is a socket connection to the
        /// asterisk server, false otherwise.
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
        public Response.ManagerResponse SendAction(ManagerAction action, int timeout)
        {
            AutoResetEvent autoEvent = new AutoResetEvent(false);
            ResponseHandler handler = new ResponseHandler(action, autoEvent);

            int hash = SendAction(action, handler);
            bool result = autoEvent.WaitOne(timeout <= 0 ? -1 : timeout, true);

            RemoveResponseHandler(handler);

            if (result)
                return handler.Response;
            throw new TimeoutException("Timeout waiting for response to " + action.Action);
        }
        #endregion

        #region SendAction(action, responseHandler)
        /// <summary>
        /// Send action ans with timeout (milliseconds)
        /// </summary>
        /// <param name="action">action to send</param>
        /// <param name="responseHandler">Response Handler</param>
        /// <returns></returns>
        public int SendAction(ManagerAction action, IResponseHandler responseHandler)
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



        #region SendActionAsync(action)
        /// <summary>
        /// Asynchronously send Action async with default timeout.
        /// </summary>
        /// <param name="action">action to send</param>
        public Task<ManagerResponse> SendActionAsync(ManagerAction action)
        {
          return SendActionAsync(action, null);
        }
        #endregion

        #region SendActionAsync(action, timeout)
        /// <summary>
        /// Asynchronously send Action async.
        /// </summary>
        /// <param name="action">action to send</param>
        /// <param name="cancellationToken">cancellation Token</param>
        public Task<ManagerResponse> SendActionAsync(ManagerAction action, CancellationTokenSource cancellationToken)
        {
          var handler = new TaskResponseHandler(action);
          var source = handler.TaskCompletionSource;

          SendAction(action, handler);

          if (cancellationToken != null)
            cancellationToken.Token.Register(() => { source.TrySetCanceled(); });

          return source.Task.ContinueWith(x =>
          {
            RemoveResponseHandler(handler);
            return x.Result;
          });
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

        /// <summary>
        /// Delete an instance of a class <see cref="IResponseHandler"/> from handlers list.
        /// </summary>
        /// <param name="handler">Class instance <see cref="IResponseHandler"/>.</param>
		public void RemoveResponseHandler(IResponseHandler handler)
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
            lock (lockSocketWrite)
            {
                mrSocket.Write(buffer);
            }
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

            IActionVariable actionVar = action as IActionVariable;
            if (actionVar != null)
            {
                var variables = actionVar.GetVariables();
                if (variables != null && variables.Count > 0)
                {
                    sb.Append(string.Concat("Variable: ", Helper.JoinVariables(actionVar.GetVariables(), VAR_DELIMITER, "="), Common.LINE_SEPARATOR));
                }
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
                    catch (Exception ex)
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
            else if (!reconnected && reconnectEnable && (e is DisconnectEvent || e is ShutdownEvent))
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
                if (UseASyncEvents)
                    Task.Run(() => internalEvent.Invoke(this, e)).ContinueWith(eventComplete);
                else
                    internalEvent.Invoke(this, e);
        }

        /// <summary>
        /// This method is called when send event to client if subscribed
        /// </summary>
        /// <typeparam name="T">EventHandler argument</typeparam>
        /// <param name="asterEvent">Event delegate</param>
        /// <param name="arg">ManagerEvent or inherited class. Argument of eventHandler.</param>
        private bool fireEvent<T>(EventHandler<T> asterEvent, ManagerEvent arg) where T : ManagerEvent
        {
            if (asterEvent != null)
            {
                asterEvent(this, (T)arg);
                return true;
            }

            return false;
        }
        #endregion
    }
}
