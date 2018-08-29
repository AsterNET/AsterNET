using System;
using AsterNET.Manager.Event;

namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     The QueueStatusAction requests the state of all defined queues their members (agents) and entries (callers).<br />
    ///     For each queue a QueueParamsEvent is generated, followed by a
    ///     QueueMemberEvent for each member of that queue and a QueueEntryEvent for each
    ///     entry in the queue.<br />
    ///     Since Asterisk 1.2 a QueueStatusCompleteEvent is sent to denote the end of the generated dump.<br />
    ///     This action is implemented in apps/app_queue.c
    /// </summary>
    /// <seealso cref="Manager.Event.QueueParamsEvent" />
    /// <seealso cref="Manager.Event.QueueMemberEvent" />
    /// <seealso cref="Manager.Event.QueueEntryEvent" />
    /// <seealso cref="Manager.Event.QueueStatusCompleteEvent" />
    public class QueueStatusAction : ManagerActionEvent
    {
        #region Action

        /// <summary>
        ///     Get the name of this action, i.e. "QueueStatus".
        /// </summary>
        public override string Action
        {
            get { return "QueueStatus"; }
        }

        #endregion

        #region Queue

        /// <summary>
        ///     Get/Set the queue filter.
        /// </summary>
        public string Queue { get; set; }

        #endregion

        #region Member

        /// <summary>
        ///     Get/Set the member filter.
        /// </summary>
        public string Member { get; set; }

        #endregion

        #region ActionCompleteEventClass 

        public override Type ActionCompleteEventClass()
        {
            return typeof (QueueStatusCompleteEvent);
        }

        #endregion

        #region QueueStatusAction()

        #endregion
    }
}