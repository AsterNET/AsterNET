namespace AspNetCore.AsterNET.Manager.Action
{
    /// <summary>
    ///     The ZapTransferAction transfers a zap channel.
    /// </summary>
    public class ZapTransferAction : ManagerAction
    {
        /// <summary>
        ///     Get the name of this action, i.e. "ZapTransfer".
        /// </summary>
        public override string Action
        {
            get { return "ZapTransfer"; }
        }

        /// <summary>
        ///     Get/Set the number of the zap channel to transfer.<br />
        ///     This property is mandatory.
        /// </summary>
        public int ZapChannel { get; set; }
    }
}