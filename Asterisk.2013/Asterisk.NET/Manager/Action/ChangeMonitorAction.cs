namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     The ChangeMonitorAction changes the monitoring filename of a channel.
    ///     It has no effect if the channel is not monitored.<br />
    ///     It is implemented in res/res_monitor.c
    /// </summary>
    public class ChangeMonitorAction : ManagerAction
    {
        #region Action

        /// <summary>
        ///     Get the name of this action, i.e. "ChangeMonitor".
        /// </summary>
        public override string Action
        {
            get { return "ChangeMonitor"; }
        }

        #endregion

        #region Channel

        /// <summary>
        ///     Get/Set the name of the monitored channel.<br />
        ///     This property is mandatory.
        /// </summary>
        public string Channel { get; set; }

        #endregion

        #region File

        /// <summary>
        ///     Get/Set the name of the file to which the voice data is written.<br />
        ///     This property is mandatory.
        /// </summary>
        public string File { get; set; }

        #endregion

        #region ChangeMonitorAction()

        /// <summary>
        ///     Creates a new empty ChangeMonitorAction.
        /// </summary>
        public ChangeMonitorAction()
        {
        }

        #endregion

        #region ChangeMonitorAction(string channel, string file)

        /// <summary>
        ///     Creates a new ChangeMonitorAction that causes monitoring data for the
        ///     given channel to be written to the given file(s).
        /// </summary>
        /// <param name="channel">the name of the channel that is monitored</param>
        /// <param name="file">the (base) name of the file(s) to which the voice data is written</param>
        public ChangeMonitorAction(string channel, string file)
        {
            Channel = channel;
            File = file;
        }

        #endregion
    }
}