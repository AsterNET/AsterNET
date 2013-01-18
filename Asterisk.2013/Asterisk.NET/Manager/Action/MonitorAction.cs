using System;

namespace Asterisk.NET.Manager.Action
{
	/// <summary>
	/// The MonitorAction starts monitoring (recording) a channel.<br/>
	/// It is implemented in <code>res/res_monitor.c</code>
	/// </summary>
	public class MonitorAction : ManagerAction
	{
		private string channel;
		private string file;
		private string format;
		private bool mix;

		#region Action
		/// <summary>
		/// Get the name of this action, i.e. "Monitor".
		/// </summary>
		override public string Action
		{
			get { return "Monitor"; }
		}
		#endregion

		#region Channel
		/// <summary>
		/// Get/Set the name of the channel to monitor.<br/>
		/// This property is mandatory.
		/// </summary>
		public string Channel
		{
			get { return this.channel; }
			set { this.channel = value; }
		}
		#endregion

		#region File
		/// <summary>
		/// Get/Set the name of the file to which the voice data is written.<br/>
		/// If this property is not set it defaults to to the channel name as per CLI with the '/' replaced by '-'.
		/// </summary>
		public string File
		{
			get { return this.file; }
			set { this.file = value; }
		}
		#endregion

		#region Format
		/// <summary>
		/// Get/Set the format to use for encoding the voice files.<br/>
		/// If this property is not set it defaults to "wav".
		/// </summary>
		public string Format
		{
			get { return this.format; }
			set { this.format = value; }
		}
		#endregion

		#region Mix
		/// <summary> 
		/// Returns true if the two voice files should be joined at the end of the call.
		/// </summary>
		public bool Mix
		{
			get { return this.mix; }
			set { this.mix = value; }
		}
		#endregion

		#region MonitorAction()
		/// <summary>
		/// Creates a new empty MonitorAction.
		/// </summary>
		public MonitorAction()
		{
		}
		#endregion

		#region MonitorAction(string channel, string file)
		/// <summary>
		/// Creates a new MonitorAction that starts monitoring the given channel and
		/// writes voice data to the given file(s).
		/// </summary>
		/// <param name="channel">the name of the channel to monitor</param>
		/// <param name="file">the (base) name of the file(s) to which the voice data is written</param>
		public MonitorAction(string channel, string file)
		{
			this.channel = channel;
			this.file = file;
		}
		#endregion

		#region MonitorAction(string channel, string file)
		/// <summary>
		/// Creates a new MonitorAction that starts monitoring the given channel and
		/// writes voice data to the given file(s).
		/// </summary>
		/// <param name="channel">the name of the channel to monitor</param>
		/// <param name="file">the (base) name of the file(s) to which the voice data is written</param>
		/// <param name="format">the format to use for encoding the voice files</param>
		public MonitorAction(string channel, string file, string format)
		{
			this.channel = channel;
			this.file = file;
			this.format = format;
		}
		#endregion

		#region MonitorAction(string channel, string file, string format, int mix)
		/// <summary>
		/// Creates a new MonitorAction that starts monitoring the given channel and
		/// writes voice data to the given file(s).
		/// </summary>
		/// <param name="channel">the name of the channel to monitor</param>
		/// <param name="file">the (base) name of the file(s) to which the voice data is written</param>
		/// <param name="format">the format to use for encoding the voice files</param>
		/// <param name="mix">true if the two voice files should be joined at the end of the call</param>
		public MonitorAction(string channel, string file, string format, bool mix)
		{
			this.channel = channel;
			this.file = file;
			this.format = format;
			this.mix = mix;
		}
		#endregion
	}
}