namespace AsterNET.Manager.Response
{
    public class ExtensionStateResponse : ManagerResponse
    {
        private string context;
        private string exten;
        private string hint;
        private int status;

        public string Exten
        {
            get { return exten; }
            set { this.exten = value; }
        }

        public string Context
        {
            get { return context; }
            set { this.context = value; }
        }

        public string Hint
        {
            get { return hint; }
            set { this.hint = value; }
        }

        public int Status
        {
            get { return status; }
            set { this.status = value; }
        }
    }
}