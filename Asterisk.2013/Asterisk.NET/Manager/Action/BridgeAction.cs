namespace AsterNET.Manager.Action
{
    /// <summary>
    ///     Bridge two channels already in the PBX.
    ///     
    ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_Bridge">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_Bridge</see>
    /// </summary>
    public class BridgeAction : ManagerAction
    {
        /// <summary>
        ///     Creates a new empty <see cref="BridgeAction"/>.
        /// </summary>
        public BridgeAction()
        {
        }

        /// <summary>
        ///     Creates a new <see cref="BridgeAction"/>.
        /// </summary>
        /// <param name="channel1">Channel to Bridge to Channel2</param>
        /// <param name="channel2">Channel to Bridge to Channel1</param>
        /// <param name="tone">Play courtesy tone to Channel 2 [yes|no]</param>
        public BridgeAction(string channel1, string channel2, string tone)
        {
            Channel1 = channel1;
            Channel2 = channel2;
            Tone = tone;
        }

        /// <summary>
        ///     Get the name of this action, i.e. "Bridge".
        /// </summary>
        public override string Action
        {
            get { return "Bridge"; }
        }

        /// <summary>
        /// Gets or sets the channel1.
        /// </summary>
        public string Channel1 { get; set; }

        /// <summary>
        /// Gets or sets the channel2.
        /// </summary>
        public string Channel2 { get; set; }

        /// <summary>
        /// Gets or sets the tone.
        /// </summary>
        public string Tone { get; set; }
    }
}