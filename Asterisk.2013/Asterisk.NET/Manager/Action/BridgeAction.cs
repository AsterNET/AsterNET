namespace AsterNET.Manager.Action
{
    public class BridgeAction : ManagerAction
    {
        /// <summary>
        ///     Bridge two channels already in the PBX.
        ///     
        ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_Bridge">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_Bridge</see>
        /// </summary>
        public BridgeAction()
        {
        }

        /// <summary>
        ///     Bridge two channels already in the PBX.
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

        public override string Action
        {
            get { return "Bridge"; }
        }

        public string Channel1 { get; set; }

        public string Channel2 { get; set; }

        public string Tone { get; set; }
    }
}