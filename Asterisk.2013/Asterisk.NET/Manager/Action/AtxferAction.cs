namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     Attended transfer.
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_Atxfer">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_Atxfer</see>
    /// </summary>
    public class AtxferAction : ManagerAction
    {
        /// <summary>
        ///     Creates a new empty <see cref="AtxferAction"/>.
        /// </summary>
        public AtxferAction()
        {
        }

        /// <summary>
        ///     Creates a new <see cref="AtxferAction"/>.
        /// </summary>
        /// <param name="channel">Transferrer's channel.</param>
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

        /// <summary>
        ///     Get the name of this action, i.e. "Atxfer".
        /// </summary>
        public override string Action
        {
            get { return "Atxfer"; }
        }

        /// <summary>
        ///     Transferrer's channel.
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