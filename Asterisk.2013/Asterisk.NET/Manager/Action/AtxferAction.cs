namespace AsterNET.Manager.Action
{
    public class AtxferAction : ManagerAction
    {
        /// <summary>
        ///     Attended transfer.
        ///     
        ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_Atxfer">Asterisk Documentation</see>
        /// </summary>
        public AtxferAction()
        {
        }

        /// <summary>
        ///     Attended transfer.
        /// </summary>
        /// <param name="channel">Transferer's channel.</param>
        /// <param name="exten">Extension to transfer to.</param>
        /// <param name="context">Context to transfer to.</param>
        /// <param name="priority">Priority to transfer to.</param>
        public AtxferAction(string channel, string exten, string context, string priority)
        {
            Channel = channel;
            Exten = exten;
            Context = context;
            Priority = priority;
        }

        public override string Action
        {
            get { return "Atxfer"; }
        }

        /// <summary>
        ///     Transferer's channel.
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        ///     Extension to transfer to.
        /// </summary>
        public string Exten { get; set; }

        /// <summary>
        ///     Context to transfer to.
        /// </summary>
        public string Context { get; set; }

        /// <summary>
        ///     Priority to transfer to.
        /// </summary>
        public string Priority { get; set; }
    }
}