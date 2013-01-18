using System.IO;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System;

namespace Asterisk.NET.IO
{
	public class SocketConnection
	{
		private TcpClient tcpClient;
		private NetworkStream networkStream;
		private StreamReader reader;
		private StreamWriter writer;
		private Encoding encoding;
		private bool initial;

		#region Constructor - SocketConnection(string host, int port, int receiveTimeout) 
		/// <summary>
		/// Consructor
		/// </summary>
		/// <param name="host">client host</param>
		/// <param name="port">client port</param>
		/// <param name="encoding">encoding</param>
		public SocketConnection(string host, int port, Encoding encoding)
		{
			initial = true;
			this.encoding = encoding;
			this.tcpClient = new TcpClient(host, port);
			this.networkStream = this.tcpClient.GetStream();
			this.reader = new StreamReader(this.networkStream, encoding);
			this.writer = new StreamWriter(this.networkStream, encoding);
			this.writer.AutoFlush = true;
		}
		#endregion

		#region Constructor - SocketConnection(socket) 
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="socket">TCP client from Listener</param>
		/// <param name="encoding">encoding</param>
		internal SocketConnection(TcpClient tcpClient, Encoding encoding)
		{
			initial = true;
			this.encoding = encoding;
			this.tcpClient = tcpClient;
			this.networkStream = this.tcpClient.GetStream();
			this.reader = new StreamReader(this.networkStream, encoding);
			this.writer = new StreamWriter(this.networkStream, encoding);
			this.writer.AutoFlush = true;
		}
		#endregion

		public TcpClient TcpClient
		{
			get { return tcpClient; }
		}

		public NetworkStream NetworkStream
		{
			get { return networkStream; }
		}

		public Encoding Encoding
		{
			get { return encoding; }
		}

		public bool Initial
		{
			get { return initial; }
			set { initial = value; }
		}

		#region IsConnected 
		/// <summary>
		/// Returns the connection state of the socket.
		/// </summary>
		public bool IsConnected
		{
			get { return tcpClient.Connected; }
		}
		#endregion

		#region LocalAddress 
		public IPAddress LocalAddress
		{
			get
			{
				return ((IPEndPoint)(tcpClient.Client.LocalEndPoint)).Address;
			}
		}
		#endregion

		#region LocalPort 
		public int LocalPort
		{
			get
			{
				return ((IPEndPoint)(tcpClient.Client.LocalEndPoint)).Port;
			}
		}
		#endregion

		#region RemoteAddress 
		public IPAddress RemoteAddress
		{
			get
			{
				return ((IPEndPoint)(tcpClient.Client.RemoteEndPoint)).Address;
			}
		}
		#endregion

		#region RemotePort 
		public int RemotePort
		{
			get
			{
				return ((IPEndPoint)(tcpClient.Client.LocalEndPoint)).Port;
			}
		}
		#endregion

		#region ReadLine()
		/// <summary>
		/// Reads a line of text from the socket connection. The current thread is
		/// blocked until either the next line is received or an IOException
		/// encounters.
		/// </summary>
		/// <returns>the line of text received excluding any newline character</returns>
		/// <throws>  IOException if the connection has been closed. </throws>
		public string ReadLine()
		{
			string line = null;
			try
			{
				line = reader.ReadLine();
			}
			catch
			{
				line = null;
			}
			return line;
		}
		#endregion


		#region Write(string s)
		/// <summary>
		/// Sends a given String to the socket connection.
		/// </summary>
		/// <param name="s">the String to send.</param>
		/// <throws> IOException if the String cannot be sent, maybe because the </throws>
		/// <summary>connection has already been closed.</summary>
		public void Write(string s)
		{
			writer.Write(s);
		}
		#endregion

		#region Write(string msg) 
		/// <summary>
		/// Sends a given String to the socket connection.
		/// </summary>
		/// <param name="msg">the String to send.</param>
		/// <throws> IOException if the String cannot be sent, maybe because the </throws>
		/// <summary>connection has already been closed.</summary>
		public void WriteEx(string msg)
		{
			byte[] data = encoding.GetBytes(msg);
			networkStream.BeginWrite(data, 0, data.Length, onWriteFinished, networkStream);
			networkStream.Flush();
		}

		private void onWriteFinished(IAsyncResult ar)
		{
			NetworkStream stream = (NetworkStream)ar.AsyncState;
			stream.EndWrite(ar);
		}
		#endregion

		#region Close
		/// <summary>
		/// Closes the socket connection including its input and output stream and
		/// frees all associated ressources.<br/>
		/// When calling close() any Thread currently blocked by a call to readLine()
		/// will be unblocked and receive an IOException.
		/// </summary>
		/// <throws>  IOException if the socket connection cannot be closed. </throws>
		public void Close()
		{
			try
			{
				tcpClient.Client.Shutdown(SocketShutdown.Both);
				tcpClient.Client.Close();
				tcpClient.Close();
			}
			catch { }
		}
		#endregion
	}
}
