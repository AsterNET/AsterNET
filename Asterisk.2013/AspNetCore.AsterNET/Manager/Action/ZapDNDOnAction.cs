namespace AspNetCore.AsterNET.Manager.Action
{
    /// <summary>
    ///     The ZapDNDOnAction switches a zap channel "Do Not Disturb" status on.
    /// </summary>
    public class ZapDNDOnAction : ManagerAction
    {
        /// <summary>
        ///     Creates a new empty ZapDNDOnAction.
        /// </summary>
        public ZapDNDOnAction()
        {
        }

        /// <summary>
        ///     Creates a new ZapDNDOnAction that enables "Do Not Disturb" status for the given zap channel.
        /// </summary>
        public ZapDNDOnAction(int zapChannel)
        {
            this.ZapChannel = zapChannel;
        }

        /// <summary>
        ///     Get the name of this action, i.e. "ZapDNDOn".
        /// </summary>
        public override string Action
        {
            get { return "ZapDNDOn"; }
        }

        /// <summary>
        ///     Get/Set the number of the zap channel to switch to dnd on.<br />
        ///     This property is mandatory.
        /// </summary>
        public int ZapChannel { get; set; }
    }
}