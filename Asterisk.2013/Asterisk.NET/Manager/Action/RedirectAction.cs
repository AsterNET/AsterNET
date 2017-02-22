namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     Redirects a given channel (and an optional additional channel) to a new extension.
    /// </summary>
    public class RedirectAction : ManagerAction
    {
        /// <summary>
        ///     Creates a new empty RedirectAction.
        /// </summary>
        public RedirectAction()
        {
        }

        /// <summary>
        ///     Creates a new RedirectAction that redirects the given channel to the given context, extension, priority triple.
        /// </summary>
        /// <param name="channel">the name of the channel to redirect</param>
        /// <param name="context">the destination context</param>
        /// <param name="exten">the destination extension</param>
        /// <param name="priority">the destination priority</param>
        public RedirectAction(string channel, string context, string exten, int priority)
        {
            this.Channel = channel;
            this.Context = context;
            this.Exten = exten;
            this.Priority = priority;
        }

        /// <summary>
        ///     Creates a new RedirectAction that redirects the given channels to the given context, extension, priority triple.
        /// </summary>
        /// <param name="channel">the name of the first channel to redirect</param>
        /// <param name="extraChannel">the name of the second channel to redirect</param>
        /// <param name="context">the destination context</param>
        /// <param name="exten">the destination extension</param>
        /// <param name="priority">the destination priority</param>
        public RedirectAction(string channel, string extraChannel, string context, string exten, int priority)
        {
            this.Channel = channel;
            this.ExtraChannel = extraChannel;
            this.Context = context;
            this.Exten = exten;
            this.Priority = priority;
        }

        /// <summary>
        ///     Get the name of this action, i.e. "Redirect".
        /// </summary>
        public override string Action
        {
            get { return "Redirect"; }
        }

        /// <summary>
        ///     Get/Set name of the channel to redirect.
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        ///     Get/Set the name of the additional channel to redirect.
        /// </summary>
        public string ExtraChannel { get; set; }

        /// <summary>
        ///     Get/Set the destination context.
        /// </summary>
        public string Context { get; set; }

        /// <summary>
        ///     Get/Set the destination extension.
        /// </summary>
        public string Exten { get; set; }

        /// <summary>
        ///     Get/Set the destination priority.
        /// </summary>
        public int Priority { get; set; }
    }
}