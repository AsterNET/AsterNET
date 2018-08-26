using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsterNET.Manager.Action
{
    class BlindTransferAction : ManagerAction
    {
        /// <summary>
        ///     Blind transfer channel(s) to the given destination
        ///     
        ///     See <see target="_blank"  href="https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_BlindTransfer">https://wiki.asterisk.org/wiki/display/AST/Asterisk+16+ManagerAction_BlindTransfer</see>
        /// </summary>
        public BlindTransferAction()
        {
        }

        /// <summary>
        ///     Bridge two channels already in the PBX.
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="context"></param>
        /// <param name="extension"></param>
        public BlindTransferAction(string channel, string context, string extension)
        {
            Channel = channel;
            Context = context;
            Exten = extension;
        }

        public override string Action
        {
            get { return "Bridge"; }
        }

        public string Channel { get; set; }

        public string Context { get; set; }

        public string Exten { get; set; }
    }
}
