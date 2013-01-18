using System;

namespace Asterisk.NET.FastAGI.Command
{
	/// <summary>
	/// Sends the given image on a channel.<br/>
	/// Most channels do not support the transmission of images.<br/>
	/// Returns 0 if image is sent, or if the channel does not support image
	/// transmission. Returns -1 only on error/hangup.<br/>
	/// Image names should not include extensions.
	/// </summary>
	public class SendImageCommand : AGICommand
	{
		/// <summary>
		/// Get/Set the image to send.
		/// </summary>
		/// <param name="image">the image to send, should not include extension.</param>
		/// <returns> the image to send.</returns>
		public string Image
		{
			get { return image; }
			set { this.image = value; }
		}
		
		/// <summary> The name of the image to send.</summary>
		private string image;
		
		/// <summary>
		/// Creates a new SendImageCommand.
		/// </summary>
		/// <param name="image">the image to send, should not include extension.</param>
		public SendImageCommand(string image)
		{
			this.image = image;
		}
		
		public override string BuildCommand()
		{
			return "SEND IMAGE " + EscapeAndQuote(image);
		}
	}
}