using System;
namespace Asterisk.NET.FastAGI.Command
{
	public class AnswerCommand : AGICommand
	{
		public AnswerCommand()
		{
		}
		public override string BuildCommand()
		{
			return "ANSWER";
		}
	}
}