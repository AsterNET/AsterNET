using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsterNET.Manager.Action
{
    public class BridgeAction : ManagerAction
    {

        private string _channel1;
        private string _channel2;
        private string _tone;

        /// <summary>
        /// Bridge two channels already in the PBX.
        /// </summary>
        public BridgeAction()
        {
        }

        /// <summary>
        /// Bridge two channels already in the PBX.
        /// </summary>
        /// <param name="channel1">Channel to Bridge to Channel2</param>
        /// <param name="channel2">Channel to Bridge to Channel1</param>
        /// <param name="tone">Play courtesy tone to Channel 2 [yes|no]</param>
        public BridgeAction(string channel1, string channel2, string tone)
        {
            _channel1 = channel1;
            _channel2 = channel2;
            _tone = tone;
        }

        public override string Action
        {
            get { return "Bridge"; }
        }

        public string Channel1
        {
            get { return _channel1; }
            set { _channel1 = value; }
        }

        public string Channel2
        {
            get { return _channel2; }
            set { _channel2 = value; }
        }

        public string Tone
        {
            get { return _tone; }
            set { _tone = value; }
        }
    }
}
