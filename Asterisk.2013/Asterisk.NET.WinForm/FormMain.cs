using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Asterisk.NET.Manager;
using Asterisk.NET.Manager.Event;
using System.Diagnostics;

namespace Asterisk.NET.WinForm
{
	public partial class FormMain : Form
	{
		public FormMain()
		{
			InitializeComponent();
		}

		private ManagerConnection manager = null;
		private void btnConnect_Click(object sender, EventArgs e)
		{
			string address = this.tbAddress.Text;
			int port = int.Parse(this.tbPort.Text);
			string user = this.tbUser.Text;
			string password = this.tbPassword.Text;

			btnConnect.Enabled = false;
			manager = new ManagerConnection(address, port, user, password);
			manager.UnhandledEvent += new ManagerEventHandler(manager_Events);
			try
			{
				// Uncomment next 2 line comments to Disable timeout (debug mode)
				// manager.DefaultResponseTimeout = 0;
				// manager.DefaultEventTimeout = 0;
				manager.Login();
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error connect\n" + ex.Message);
				manager.Logoff();
				this.Close();
			}
			btnDisconnect.Enabled = true;
		}

		void manager_Events(object sender, ManagerEvent e)
		{
			Debug.WriteLine("Event : " + e.GetType().Name);
		}

		private void btnDisconnect_Click(object sender, EventArgs e)
		{
			btnConnect.Enabled = true;
			if (this.manager != null)
			{
				manager.Logoff();
				this.manager = null;
			}
			btnDisconnect.Enabled = false;
		}
	}
}
