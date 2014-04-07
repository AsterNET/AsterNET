using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsterNET.Manager.Action
{
    public class CreateConfigAction : ManagerAction
    {

        private string _filename;

        /// <summary>
        /// Creates an empty file in the configuration directory.
        /// This action will create an empty file in the configuration directory. This action is intended to be used before an UpdateConfig action.
        /// </summary>
        public CreateConfigAction()
        {
        }

        /// <summary>
        /// Creates an empty file in the configuration directory.
        /// This action will create an empty file in the configuration directory. This action is intended to be used before an UpdateConfig action.
        /// </summary>
        /// <param name="filename"></param>
        public CreateConfigAction(string filename)
        {
            _filename = filename;
        }

        public override string Action
        {
            get { return "CreateConfig"; }
        }

        public string Filename
        {
            get { return _filename; }
            set { _filename = value; }
        }
    }
}
