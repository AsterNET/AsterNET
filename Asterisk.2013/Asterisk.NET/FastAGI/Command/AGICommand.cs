using System.Text;

namespace Asterisk.NET.FastAGI.Command
{
	public abstract class AGICommand
	{
		public abstract string BuildCommand();

		protected internal string EscapeAndQuote(string s)
		{
			string tmp;
			if (s == null)
				return "\"\"";

			tmp = s;
			tmp = tmp.Replace("\\\"", "\\\\\"");		// escape quotes
			tmp = tmp.Replace("\\\n", "");				// filter newline
			return "\"" + tmp + "\"";					// add quotes
		}

		public override string ToString()
		{
			return Helper.ToString(this);
		}
	}
}
