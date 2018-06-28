namespace AspNetCore.AsterNET.Manager.Action
{
    /// <summary>
    ///     The StopMonitorAction ends monitoring (recording) a channel.<br />
    ///     It is implemented in res/res_monitor.c
    /// </summary>
    public class StopMonitorAction : ManagerAction
    {
        #region Action

        /// <summary>
        ///     Get the name of this action, i.e. "StopMonitor".
        /// </summary>
        public override string Action
        {
            get { return "StopMonitor"; }
        }

        #endregion

        #region Channel

        /// <summary>
        ///     Get/Set the name of the channel to end monitoring.<br />
        ///     This property is mandatory.
        /// </summary>
        public string Channel { get; set; }

        #endregion

        #region StopMonitorAction()

        /// <summary>
        ///     Creates a new empty StopMonitorAction.
        /// </summary>
        public StopMonitorAction()
        {
        }

        #endregion

        #region StopMonitorAction(string channel)

        /// <summary>
        ///     Creates a new StopMonitorAction that ends monitoring of the given channel.
        /// </summary>
        public StopMonitorAction(string channel)
        {
            this.Channel = channel;
        }

        #endregion
    }
}