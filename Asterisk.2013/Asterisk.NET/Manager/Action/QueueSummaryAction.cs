using AsterNET.Manager.Event;
using System;

namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     Show queue summary
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_QueueSummary">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_QueueSummary</see>
    /// </summary>
    /// <seealso cref="Manager.Action.QueueStatusAction" />
    public class QueueSummaryAction : ManagerActionEvent
    {
        #region Action

        /// <summary>
        ///     Get the name of this action, i.e. "QueueSummary".
        /// </summary>
        public override string Action
        {
            get { return "QueueSummary"; }
        }

        #endregion

        #region MyRegion

        /// <summary>
        ///     Name of queue
        /// </summary>
        public string Queue { get; set; }

        #endregion

        #region QueueSummaryAction(string queue)

        /// <summary>
        ///     Creates a new empty <see cref="QueueSummaryAction"/> using the given queue.
        /// </summary>
        /// <param name="queue"></param>
        public QueueSummaryAction(string queue)
        {
            Queue = queue;
        }

        #endregion

        #region ActionCompleteEventClass()

        public override Type ActionCompleteEventClass()
        {
            return typeof(QueueSummaryEvent);
        }

        #endregion
    }
}
