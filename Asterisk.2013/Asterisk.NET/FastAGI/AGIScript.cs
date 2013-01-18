using System;

namespace Asterisk.NET.FastAGI
{
	/// <summary>
	/// The BaseAGIScript provides some convinience methods to make it easier to
	/// write custom AGIScripts.<br/>
	/// Just extend it by your own AGIScripts.
	/// </summary>
	public abstract class AGIScript
	{
		#region Answer()
		/// <summary>
		/// Answers the channel.
		/// </summary>
		protected internal void Answer()
		{
			this.Channel.SendCommand(new Command.AnswerCommand());
		}
		#endregion

		#region Hangup()
		/// <summary>
		/// Hangs the channel up.
		/// </summary>
		protected internal void Hangup()
		{
			this.Channel.SendCommand(new Command.HangupCommand());
		}
		#endregion

		#region SetAutoHangup
		/// <summary>
		/// Cause the channel to automatically hangup at the given number of seconds in the future.<br/>
		/// 0 disables the autohangup feature.
		/// </summary>
		protected internal void SetAutoHangup(int time)
		{
			this.Channel.SendCommand(new Command.SetAutoHangupCommand(time));
		}
		#endregion

		#region SetCallerId
		/// <summary>
		/// Sets the caller id on the current channel.<br/>
		/// The raw caller id to set, for example "John Doe<1234>".
		/// </summary>
		protected internal void SetCallerId(string callerId)
		{
			this.Channel.SendCommand(new Command.SetCallerIdCommand(callerId));
		}
		#endregion

		#region PlayMusicOnHold()
		/// <summary>
		/// Plays music on hold from the default music on hold class.
		/// </summary>
		protected internal void PlayMusicOnHold()
		{
			this.Channel.SendCommand(new Command.SetMusicOnCommand());
		}
		#endregion

		#region PlayMusicOnHold(string musicOnHoldClass)
		/// <summary>
		/// Plays music on hold from the given music on hold class.
		/// </summary>
		/// <param name="musicOnHoldClass">the music on hold class to play music from as configures in Asterisk's <code><musiconhold.conf/code>.</param>
		protected internal void PlayMusicOnHold(string musicOnHoldClass)
		{
			this.Channel.SendCommand(new Command.SetMusicOnCommand(musicOnHoldClass));
		}
		#endregion

		#region StopMusicOnHold()
		/// <summary>
		/// Stops playing music on hold.
		/// </summary>
		protected internal void StopMusicOnHold()
		{
			this.Channel.SendCommand(new Command.SetMusicOffCommand());
		}
		#endregion

		#region GetChannelStatus
		/// <summary>
		/// Returns the status of the channel.<br/>
		/// Return values:
		/// <ul>
		/// <li>0 Channel is down and available
		/// <li>1 Channel is down, but reserved
		/// <li>2 Channel is off hook
		/// <li>3 Digits (or equivalent) have been dialed
		/// <li>4 Line is ringing
		/// <li>5 Remote end is ringing
		/// <li>6 Line is up
		/// <li>7 Line is busy
		/// </ul>
		/// 
		/// </summary>
		/// <returns> the status of the channel.
		/// </returns>
		protected internal int GetChannelStatus()
		{
			AGIChannel channel = this.Channel;
			channel.SendCommand(new Command.ChannelStatusCommand());
			return channel.LastReply.ResultCode;
		}
		#endregion

		#region GetData(string file)
		/// <summary>
		/// Plays the given file and waits for the user to enter DTMF digits until he
		/// presses '#'. The user may interrupt the streaming by starting to enter
		/// digits.
		/// </summary>
		/// <param name="file">the name of the file to play</param>
		/// <returns> a String containing the DTMF the user entered</returns>
		protected internal string GetData(string file)
		{
			AGIChannel channel = this.Channel;
			channel.SendCommand(new Command.GetDataCommand(file));
			return channel.LastReply.GetResult();
		}
		#endregion

		#region GetData(string file, int timeout)
		/// <summary>
		/// Plays the given file and waits for the user to enter DTMF digits until he
		/// presses '#' or the timeout occurs. The user may interrupt the streaming
		/// by starting to enter digits.
		/// </summary>
		/// <param name="file">the name of the file to play</param>
		/// <param name="timeout">the timeout in milliseconds to wait for user input.<br/>
		/// 0 means standard timeout value, -1 means "ludicrous time"
		/// (essentially never times out).</param>
		/// <returns> a String containing the DTMF the user entered</returns>
		protected internal string GetData(string file, long timeout)
		{
			AGIChannel channel = this.Channel;
			channel.SendCommand(new Command.GetDataCommand(file, timeout));
			return channel.LastReply.GetResult();
		}
		#endregion

		#region GetData(string file, int timeout, int maxDigits)
		/// <summary>
		/// Plays the given file and waits for the user to enter DTMF digits until he
		/// presses '#' or the timeout occurs or the maximum number of digits has
		/// been entered. The user may interrupt the streaming by starting to enter
		/// digits.
		/// </summary>
		/// <param name="file">the name of the file to play</param>
		/// <param name="timeout">the timeout in milliseconds to wait for user input.<br/>
		/// 0 means standard timeout value, -1 means "ludicrous time"
		/// (essentially never times out).</param>
		/// <param name="maxDigits">the maximum number of digits the user is allowed to enter</param>
		/// <returns> a String containing the DTMF the user entered</returns>
		protected internal string GetData(string file, long timeout, int maxDigits)
		{
			AGIChannel channel = this.Channel;
			channel.SendCommand(new Command.GetDataCommand(file, timeout, maxDigits));
			return channel.LastReply.GetResult();
		}
		#endregion

		
		#region GetOption(string file, string escapeDigits)
		/// <summary>
		/// Plays the given file, and waits for the user to press one of the given
		/// digits. If none of the esacpe digits is pressed while streaming the file
		/// it waits for the default timeout of 5 seconds still waiting for the user
		/// to press a digit.
		/// </summary>
		/// <param name="file">the name of the file to stream, must not include extension.</param>
		/// <param name="escapeDigits">contains the digits that the user is expected to press.</param>
		/// <returns> the DTMF digit pressed or 0x0 if none was pressed.</returns>
		protected internal char GetOption(string file, string escapeDigits)
		{
			AGIChannel channel = this.Channel;
			channel.SendCommand(new Command.GetOptionCommand(file, escapeDigits));
			return channel.LastReply.ResultCodeAsChar;
		}
		#endregion

		#region GetOption(string file, string escapeDigits, int timeout)
		/// <summary>
		/// Plays the given file, and waits for the user to press one of the given
		/// digits. If none of the esacpe digits is pressed while streaming the file
		/// it waits for the specified timeout still waiting for the user to press a
		/// digit.
		/// </summary>
		/// <param name="file">the name of the file to stream, must not include extension.</param>
		/// <param name="escapeDigits">contains the digits that the user is expected to press.</param>
		/// <param name="timeout">the timeout in seconds to wait if none of the defined esacpe digits was presses while streaming.</param>
		/// <returns> the DTMF digit pressed or 0x0 if none was pressed.</returns>
		protected internal char GetOption(string file, string escapeDigits, int timeout)
		{
			AGIChannel channel = this.Channel;
			channel.SendCommand(new Command.GetOptionCommand(file, escapeDigits, timeout));
			return channel.LastReply.ResultCodeAsChar;
		}
		#endregion

		#region Exec(string application)
		/// <summary>
		/// Executes the given command.
		/// </summary>
		/// <param name="application">the name of the application to execute, for example "Dial".</param>
		/// <returns> the return code of the application of -2 if the application was not found.</returns>
		protected internal int Exec(string application)
		{
			AGIChannel channel = this.Channel;
			channel.SendCommand(new Command.ExecCommand(application));
			return channel.LastReply.ResultCode;
		}
		#endregion

		#region Exec(string application, string options)
		/// <summary>
		/// Executes the given command.
		/// </summary>
		/// <param name="application">the name of the application to execute, for example "Dial".</param>
		/// <param name="options">the parameters to pass to the application, for example "SIP/123".</param>
		/// <returns> the return code of the application of -2 if the application was not found.</returns>
		protected internal int Exec(string application, string options)
		{
			AGIChannel channel = this.Channel;
			channel.SendCommand(new Command.ExecCommand(application, options));
			return channel.LastReply.ResultCode;
		}
		#endregion

		#region SetContext
		/// <summary>
		/// Sets the context for continuation upon exiting the application.
		/// </summary>
		protected internal void SetContext(string context)
		{
			this.Channel.SendCommand(new Command.SetContextCommand(context));
		}
		#endregion

		#region SetExtension
		/// <summary>
		/// Sets the extension for continuation upon exiting the application.
		/// </summary>
		protected internal void SetExtension(string extension)
		{
			this.Channel.SendCommand(new Command.SetExtensionCommand(extension));
		}
		#endregion

		#region  SetPriority(int priority)
		/// <summary>
		/// Sets the priority for continuation upon exiting the application.
		/// </summary>
		protected internal void SetPriority(int priority)
		{
			this.Channel.SendCommand(new Command.SetPriorityCommand(priority));
		}
		#endregion

		#region  SetPriority(string label priority)
		/// <summary>
		/// Sets the label for continuation upon exiting the application.
		/// </summary>
		protected internal void SetPriority(string label)
		{
			this.Channel.SendCommand(new Command.SetPriorityCommand(label));
		}
		#endregion

		#region StreamFile(string file)
		/// <summary>
		/// Plays the given file.
		/// </summary>
		/// <param name="file">name of the file to play.</param>
		protected internal void StreamFile(string file)
		{
			this.Channel.SendCommand(new Command.StreamFileCommand(file));
		}
		#endregion

		#region StreamFile(string file, string escapeDigits)
		/// <summary>
		/// Plays the given file and allows the user to escape by pressing one of the given digit.
		/// </summary>
		/// <param name="file">name of the file to play.</param>
		/// <param name="escapeDigits">a String containing the DTMF digits that allow the user to escape.</param>
		/// <returns> the DTMF digit pressed or 0x0 if none was pressed.</returns>
		protected internal char StreamFile(string file, string escapeDigits)
		{
			AGIChannel channel = this.Channel;
			channel.SendCommand(new Command.StreamFileCommand(file, escapeDigits));
			return channel.LastReply.ResultCodeAsChar;
		}
		#endregion

		#region SayDigits(string digits)
		/// <summary>
		/// Says the given digit string.
		/// </summary>
		/// <param name="digits">the digit string to say.</param>
		protected internal void SayDigits(string digits)
		{
			this.Channel.SendCommand(new Command.SayDigitsCommand(digits));
		}
		#endregion

		#region SayDigits(string digits, string escapeDigits)
		/// <summary>
		/// Says the given number, returning early if any of the given DTMF number
		/// are received on the channel.
		/// </summary>
		/// <param name="digits">the digit string to say.</param>
		/// <param name="escapeDigits">a String containing the DTMF digits that allow the user to escape.</param>
		/// <returns> the DTMF digit pressed or 0x0 if none was pressed.</returns>
		protected internal char SayDigits(string digits, string escapeDigits)
		{
			AGIChannel channel = this.Channel;
			channel.SendCommand(new Command.SayDigitsCommand(digits, escapeDigits));
			return channel.LastReply.ResultCodeAsChar;
		}
		#endregion

		#region SayNumber(string number)
		/// <summary>
		/// Says the given number.
		/// </summary>
		/// <param name="number">the number to say.</param>
		protected internal void SayNumber(string number)
		{
			this.Channel.SendCommand(new Command.SayNumberCommand(number));
		}
		#endregion

		#region SayNumber(string number, string escapeDigits)
		/// <summary>
		/// Says the given number, returning early if any of the given DTMF number
		/// are received on the channel.
		/// </summary>
		/// <param name="number">the number to say.</param>
		/// <param name="escapeDigits">a String containing the DTMF digits that allow the user to escape.</param>
		/// <returns> the DTMF digit pressed or 0x0 if none was pressed.</returns>
		protected internal char SayNumber(string number, string escapeDigits)
		{
			AGIChannel channel = this.Channel;
			channel.SendCommand(new Command.SayNumberCommand(number, escapeDigits));
			return channel.LastReply.ResultCodeAsChar;
		}
		#endregion

		#region SayPhonetic(string text)
		/// <summary>
		/// Says the given character string with phonetics.
		/// </summary>
		/// <param name="text">the text to say.</param>
		protected internal void SayPhonetic(string text)
		{
			this.Channel.SendCommand(new Command.SayPhoneticCommand(text));
		}
		#endregion

		#region SayPhonetic(string text, string escapeDigits)
		/// <summary>
		/// Says the given character string with phonetics, returning early if any of
		/// the given DTMF number are received on the channel.
		/// </summary>
		/// <param name="text">the text to say.</param>
		/// <param name="escapeDigits">a String containing the DTMF digits that allow the user to escape.</param>
		/// <returns> the DTMF digit pressed or 0x0 if none was pressed.</returns>
		protected internal char SayPhonetic(string text, string escapeDigits)
		{
			AGIChannel channel = this.Channel;
			channel.SendCommand(new Command.SayPhoneticCommand(text, escapeDigits));
			return channel.LastReply.ResultCodeAsChar;
		}
		#endregion

		#region SayAlpha(string text)
		/// <summary>
		/// Says the given character string.
		/// </summary>
		/// <param name="text">the text to say.</param>
		protected internal void  SayAlpha(string text)
		{
			this.Channel.SendCommand(new Command.SayAlphaCommand(text));
		}
		#endregion

		#region SayAlpha(string text, string escapeDigits)
		/// <summary>
		/// Says the given character string, returning early if any of the given DTMF
		/// number are received on the channel.
		/// </summary>
		/// <param name="text">the text to say.</param>
		/// <param name="escapeDigits">a String containing the DTMF digits that allow the user to escape.</param>
		/// <returns> the DTMF digit pressed or 0x0 if none was pressed.</returns>
		protected internal char SayAlpha(string text, string escapeDigits)
		{
			AGIChannel channel = this.Channel;
			channel.SendCommand(new Command.SayAlphaCommand(text, escapeDigits));
			return channel.LastReply.ResultCodeAsChar;
		}
		#endregion

		#region SayTime(long time)
		/// <summary>
		/// Says the given time.
		/// </summary>
		/// <param name="time">the time to say in seconds since 00:00:00 on January 1, 1970.</param>
		protected internal void SayTime(long time)
		{
			this.Channel.SendCommand(new Command.SayTimeCommand(time));
		}
		#endregion

		#region SayTime(long time, string escapeDigits)
		/// <summary>
		/// Says the given time, returning early if any of the given DTMF number are
		/// received on the channel.
		/// </summary>
		/// <param name="time">the time to say in seconds since 00:00:00 on January 1, 1970.</param>
		/// <param name="escapeDigits">a String containing the DTMF digits that allow the user to escape.</param>
		/// <returns> the DTMF digit pressed or 0x0 if none was pressed.</returns>
		protected internal char SayTime(long time, string escapeDigits)
		{
			AGIChannel channel = this.Channel;
			channel.SendCommand(new Command.SayTimeCommand(time, escapeDigits));
			return channel.LastReply.ResultCodeAsChar;
		}
		#endregion

		#region GetVariable(string name)
		/// <summary>
		/// Returns the value of the given channel variable.
		/// </summary>
		/// <param name="name">the name of the variable to retrieve.</param>
		/// <returns> the value of the given variable or <code>null</code> if not set.</returns>
		protected internal string GetVariable(string name)
		{
			AGIChannel channel = this.Channel;
			channel.SendCommand(new Command.GetVariableCommand(name));
			if (channel.LastReply.ResultCode != 1)
				return null;
			return channel.LastReply.Extra;
		}
		#endregion

		#region SetVariable(string name, string value_Renamed)
		/// <summary>
		/// Sets the value of the given channel variable to a new value.
		/// </summary>
		/// <param name="name">the name of the variable to retrieve.</param>
		/// <param name="val">the new value to set.</param>
		protected internal void SetVariable(string name, string val)
		{
			this.Channel.SendCommand(new Command.SetVariableCommand(name, val));
		}
		#endregion

		#region WaitForDigit(int timeout)
		/// <summary>
		/// Waits up to 'timeout' milliseconds to receive a DTMF digit.
		/// </summary>
		/// <param name="timeout">timeout the milliseconds to wait for the channel to receive a DTMF digit, -1 will wait forever.</param>
		/// <returns> the DTMF digit pressed or 0x0 if none was pressed.</returns>
		protected internal char WaitForDigit(int timeout)
		{
			AGIChannel channel = this.Channel;
			channel.SendCommand(new Command.WaitForDigitCommand(timeout));
			return channel.LastReply.ResultCodeAsChar;
		}
		#endregion

		#region GetFullVariable(string name)
		/// <summary>
		/// Returns the value of the current channel variable, unlike getVariable()
		/// this method understands complex variable names and builtin variables.<br/>
		/// Available since Asterisk 1.2.
		/// </summary>
		/// <param name="name">the name of the variable to retrieve.</param>
		/// <returns>the value of the given variable or <code>null</code> if not et.</returns>
		protected internal string GetFullVariable(string name)
		{
			AGIChannel channel = this.Channel;
			channel.SendCommand(new Command.GetFullVariableCommand(name));
			if (channel.LastReply.ResultCode != 1)
				return null;
			return channel.LastReply.Extra;
		}
		#endregion

		#region GetFullVariable(string name, string channel)
		/// <summary>
		/// Returns the value of the given channel variable.<br/>
		/// Available since Asterisk 1.2.
		/// </summary>
		/// <param name="name">the name of the variable to retrieve.</param>
		/// <param name="channel">the name of the channel.</param>
		/// <returns>the value of the given variable or <code>null</code> if not set.</returns>
		protected internal string GetFullVariable(string name, string channelName)
		{
			AGIChannel channel = this.Channel;
			channel.SendCommand(new Command.GetFullVariableCommand(name, channelName));
			if (channel.LastReply.ResultCode != 1)
				return null;
			return channel.LastReply.Extra;
		}
		#endregion

		#region SayDateTime(...)
		/// <summary>
		/// Says the given time.<br/>
		/// Available since Asterisk 1.2.
		/// </summary>
		/// <param name="time">the time to say in seconds elapsed since 00:00:00 on January 1, 1970, Coordinated Universal Time (UTC)</param>
		protected internal void SayDateTime(long time)
		{
			this.Channel.SendCommand(new Command.SayDateTimeCommand(time));
		}

		/// <summary>
		/// Says the given time and allows interruption by one of the given escape digits.<br/>
		/// Available since Asterisk 1.2.
		/// </summary>
		/// <param name="time">the time to say in seconds elapsed since 00:00:00 on January 1, 1970, Coordinated Universal Time (UTC)</param>
		/// <param name="escapeDigits">the digits that allow the user to interrupt this command or <code>null</code> for none.</param>
		/// <returns>the DTMF digit pressed or 0x0 if none was pressed.</returns>
		protected internal char SayDateTime(long time, string escapeDigits)
		{
			AGIChannel channel = this.Channel;
			channel.SendCommand(new Command.SayDateTimeCommand(time, escapeDigits));
			return channel.LastReply.ResultCodeAsChar;
		}

		/// <summary>
		/// Says the given time in the given format and allows interruption by one of the given escape digits.<br/>
		/// Available since Asterisk 1.2.
		/// </summary>
		/// <param name="time">the time to say in seconds elapsed since 00:00:00 on January 1, 1970, Coordinated Universal Time (UTC)</param>
		/// <param name="escapeDigits">the digits that allow the user to interrupt this command or <code>null</code> for none.</param>
		/// <param name="format">the format the time should be said in</param>
		/// <returns>the DTMF digit pressed or 0x0 if none was pressed.</returns>
		protected internal char SayDateTime(long time, string escapeDigits, string format)
		{
			AGIChannel channel = this.Channel;
			channel.SendCommand(new Command.SayDateTimeCommand(time, escapeDigits, format));
			return channel.LastReply.ResultCodeAsChar;
		}

		/// <summary>
		/// Says the given time in the given format and timezone and allows interruption by one of the given escape digits.<br/>
		/// Available since Asterisk 1.2.
		/// </summary>
		/// <param name="time">the time to say in seconds elapsed since 00:00:00 on January 1, 1970, Coordinated Universal Time (UTC)</param>
		/// <param name="escapeDigits">the digits that allow the user to interrupt this command or <code>null</code> for none.</param>
		/// <param name="format">the format the time should be said in</param>
		/// <param name="timezone">the timezone to use when saying the time, for example "UTC" or "Europe/Berlin".</param>
		/// <returns>the DTMF digit pressed or 0x0 if none was pressed.</returns>
		protected internal char SayDateTime(long time, string escapeDigits, string format, string timezone)
		{
			AGIChannel channel = this.Channel;
			channel.SendCommand(new Command.SayDateTimeCommand(time, escapeDigits, format, timezone));
			return channel.LastReply.ResultCodeAsChar;
		}
		#endregion

		#region DatabaseGet(string family, string key)
		/// <summary>
		/// Retrieves an entry in the Asterisk database for a given family and key.
		/// </summary>
		/// <param name="family">the family of the entry to retrieve.</param>
		/// <param name="key">key the key of the entry to retrieve.</param>
		/// <return>the value of the given family and key or <code>null</code> if there is no such value.</return>
		protected internal string DatabaseGet(string family, string key)
		{
			AGIChannel channel = this.Channel;
			channel.SendCommand(new Command.DatabaseGetCommand(family, key));
			if (channel.LastReply.ResultCode != 1)
				return null;
			return channel.LastReply.Extra;
		}
		#endregion

		#region DatabasePut(string family, string key, string value)
		/// <summary>
		/// Adds or updates an entry in the Asterisk database for a given family, key and value.
		/// </summary>
		/// <param name="family">the family of the entry to add or update.</param>
		/// <param name="key">the key of the entry to add or update.</param>
		/// <param name="value">the new value of the entry.</param>
		protected internal void DatabasePut(string family, string key, string value)
		{
			this.Channel.SendCommand(new Command.DatabasePutCommand(family, key, value));
		}
		#endregion

		#region DatabaseDel(string family, string key)
		/// <summary>
		/// Deletes an entry in the Asterisk database for a given family and key.
		/// </summary>
		/// <param name="family">the family of the entry to delete.</param>
		/// <param name="key">the key of the entry to delete.</param>
		protected internal void DatabaseDel(string family, string key)
		{
			this.Channel.SendCommand(new Command.DatabaseDelCommand(family, key));
		}
		#endregion

		#region DatabaseDelTree(String family)
		/// <summary>
		/// Deletes a whole family of entries in the Asterisk database.
		/// </summary>
		/// <param name="family">the family to delete.</param>
    	protected internal void DatabaseDelTree(string family)
		{
			this.Channel.SendCommand(new Command.DatabaseDelTreeCommand(family));
		}
		#endregion

		#region DatabaseDelTree(string family, string keytree)
		/// <summary>
		/// Deletes all entries of a given family in the Asterisk database that have a key that starts with a given prefix.
		/// </summary>
		/// <param name="family">the family of the entries to delete.</param>
		/// <param name="keytree">the prefix of the keys of the entries to delete.</param>
		protected internal void DatabaseDelTree(string family, string keytree)
		{
			this.Channel.SendCommand(new Command.DatabaseDelTreeCommand(family, keytree));
		}
		#endregion

		#region Verbose(string message, int level)
		/// <summary>
		/// Sends a message to the Asterisk console via the verbose message system.
		/// </summary>
		/// <param name="message">the message to send</param>
		/// <param name="level">the verbosity level to use. Must be in [1..4]</param>
		public void Verbose(string message, int level)
		{
			this.Channel.SendCommand(new Command.VerboseCommand(message, level));
		}
		#endregion

		#region RecordFile(...)
		/// <summary>
		/// Record to a file until a given dtmf digit in the sequence is received.<br/>
		/// Returns -1 on hangup or error.<br/>
		/// The format will specify what kind of file will be recorded. The timeout is
		/// the maximum record time in milliseconds, or -1 for no timeout. Offset samples
		/// is optional, and if provided will seek to the offset without exceeding the
		/// end of the file. "maxSilence" is the number of seconds of maxSilence allowed
		/// before the function returns despite the lack of dtmf digits or reaching
		/// timeout.
		/// </summary>
		/// <param name="file">the name of the file to stream, must not include extension.</param>
		/// <param name="format">the format of the file to be recorded, for example "wav".</param>
		/// <param name="escapeDigits">contains the digits that allow the user to end recording.</param>
		/// <param name="timeout">the maximum record time in milliseconds, or -1 for no timeout.</param>
		/// <returns>result code</returns>
		protected internal int RecordFile(string file, string format, string escapeDigits, int timeout)
		{
			AGIChannel channel = this.Channel;
			channel.SendCommand(new Command.RecordFileCommand(file, format, escapeDigits, timeout));
			return channel.LastReply.ResultCode;
		}

		/// <summary>
		/// Record to a file until a given dtmf digit in the sequence is received.<br/>
		/// Returns -1 on hangup or error.<br/>
		/// The format will specify what kind of file will be recorded. The timeout is
		/// the maximum record time in milliseconds, or -1 for no timeout. Offset samples
		/// is optional, and if provided will seek to the offset without exceeding the
		/// end of the file. "maxSilence" is the number of seconds of maxSilence allowed
		/// before the function returns despite the lack of dtmf digits or reaching
		/// timeout.
		/// </summary>
		/// <param name="file">the name of the file to stream, must not include extension.</param>
		/// <param name="format">the format of the file to be recorded, for example "wav".</param>
		/// <param name="escapeDigits">contains the digits that allow the user to end recording.</param>
		/// <param name="timeout">the maximum record time in milliseconds, or -1 for no timeout.</param>
		/// <param name="offset">the offset samples to skip.</param>
		/// <param name="beep"><code>true</code> if a beep should be played before recording.</param>
		/// <param name="maxSilence">The amount of silence (in seconds) to allow before returning despite the lack of dtmf digits or reaching timeout.</param>
		/// <returns>result code</returns>
		protected internal int RecordFile(string file, string format, string escapeDigits, int timeout, int offset, bool beep, int maxSilence)
		{
			AGIChannel channel = this.Channel;
			channel.SendCommand(new Command.RecordFileCommand(file, format, escapeDigits, timeout, offset, beep, maxSilence));
			return channel.LastReply.ResultCode;
		}
		#endregion

		#region ControlStreamFile(...)
		/// <summary>
		/// Plays the given file, allowing playback to be interrupted by the given
		/// digits, if any, and allows the listner to control the stream.<br/>
		/// If offset is provided then the audio will seek to sample offset before play
		/// starts.<br/>
		/// Returns 0 if playback completes without a digit being pressed, or the ASCII
		/// numerical value of the digit if one was pressed, or -1 on error or if the
		/// channel was disconnected. <br/>
		/// Remember, the file extension must not be included in the filename.<br/>
		/// Available since Asterisk 1.2
		/// </summary>
		/// <seealso cref="Command.ControlStreamFileCommand"/>
		/// <param name="file">the name of the file to stream, must not include extension.</param>
		/// <returns>result code</returns>
		protected internal int ControlStreamFile(string file)
		{
			AGIChannel channel = this.Channel;
			channel.SendCommand(new Command.ControlStreamFileCommand(file));
			return channel.LastReply.ResultCode;
		}
		/// <summary>
		/// Plays the given file, allowing playback to be interrupted by the given
		/// digits, if any, and allows the listner to control the stream.<br/>
		/// If offset is provided then the audio will seek to sample offset before play
		/// starts.<br/>
		/// Returns 0 if playback completes without a digit being pressed, or the ASCII
		/// numerical value of the digit if one was pressed, or -1 on error or if the
		/// channel was disconnected. <br/>
		/// Remember, the file extension must not be included in the filename.<br/>
		/// Available since Asterisk 1.2
		/// </summary>
		/// <seealso cref="Command.ControlStreamFileCommand"/>
		/// <param name="file">the name of the file to stream, must not include extension.</param>
		/// <param name="escapeDigits">contains the digits that allow the user to interrupt this command.</param>
		/// <returns>result code</returns>
		protected internal int ControlStreamFile(string file, string escapeDigits)
		{
			AGIChannel channel = this.Channel;
			channel.SendCommand(new Command.ControlStreamFileCommand(file, escapeDigits));
			return channel.LastReply.ResultCode;
		}
		/// <summary>
		/// Plays the given file, allowing playback to be interrupted by the given
		/// digits, if any, and allows the listner to control the stream.<br/>
		/// If offset is provided then the audio will seek to sample offset before play
		/// starts.<br/>
		/// Returns 0 if playback completes without a digit being pressed, or the ASCII
		/// numerical value of the digit if one was pressed, or -1 on error or if the
		/// channel was disconnected. <br/>
		/// Remember, the file extension must not be included in the filename.<br/>
		/// Available since Asterisk 1.2
		/// </summary>
		/// <seealso cref="Command.ControlStreamFileCommand"/>
		/// <param name="file">the name of the file to stream, must not include extension.</param>
		/// <param name="escapeDigits">contains the digits that allow the user to interrupt this command.</param>
		/// <param name="offset">the offset samples to skip before streaming.</param>
		/// <returns>result code</returns>
		protected internal int ControlStreamFile(string file, string escapeDigits, int offset)
		{
			AGIChannel channel = this.Channel;
			channel.SendCommand(new Command.ControlStreamFileCommand(file, escapeDigits, offset));
			return channel.LastReply.ResultCode;
		}
		/// <summary>
		/// Plays the given file, allowing playback to be interrupted by the given
		/// digits, if any, and allows the listner to control the stream.<br/>
		/// If offset is provided then the audio will seek to sample offset before play
		/// starts.<br/>
		/// Returns 0 if playback completes without a digit being pressed, or the ASCII
		/// numerical value of the digit if one was pressed, or -1 on error or if the
		/// channel was disconnected. <br/>
		/// Remember, the file extension must not be included in the filename.<br/>
		/// Available since Asterisk 1.2
		/// </summary>
		/// <seealso cref="Command.ControlStreamFileCommand"/>
		/// <param name="file">the name of the file to stream, must not include extension.</param>
		/// <param name="escapeDigits">contains the digits that allow the user to interrupt this command.</param>
		/// <param name="offset">the offset samples to skip before streaming.</param>
		/// <param name="forwardDigit">the digit for fast forward.</param>
		/// <param name="rewindDigit">the digit for rewind.</param>
		/// <param name="pauseDigit">the digit for pause and unpause.</param>
		/// <returns>result code</returns>
		protected internal int ControlStreamFile(string file, string escapeDigits, int offset, string forwardDigit, string rewindDigit, string pauseDigit)
		{
			AGIChannel channel = this.Channel;
			channel.SendCommand(new Command.ControlStreamFileCommand(file, escapeDigits, offset, forwardDigit, rewindDigit, pauseDigit));
			return channel.LastReply.ResultCode;
		}
		#endregion

		#region SendCommand(Command.AGICommand command)
		/// <summary>
		/// Sends the given command to the channel attached to the current thread.
		/// </summary>
		/// <param name="command">the command to send to Asterisk</param>
		/// <returns> the reply received from Asterisk</returns>
		/// <throws>  AGIException if the command could not be processed properly </throws>
		private AGIReply SendCommand(Command.AGICommand command)
		{
			return this.Channel.SendCommand(command);
		}
		#endregion

		#region Channel
		protected internal AGIChannel Channel
		{
			get
			{
				AGIChannel channel = AGIConnectionHandler.Channel;
				if (channel == null)
					throw new SystemException("Trying to send command from an invalid thread");
				return channel;
			}
		}
		#endregion

		#region Service(AGIRequest param1, AGIChannel param2);
		public abstract void Service(AGIRequest param1, AGIChannel param2);
		#endregion
	}
}
