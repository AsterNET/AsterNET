using System;

using Asterisk.NET.Manager;
using Asterisk.NET.Manager.Action;
using Asterisk.NET.Manager.Response;
using Asterisk.NET.FastAGI;
using Asterisk.NET.Manager.Event;

namespace Asterisk.NET.Test
{
	class Program
	{
		const string DEV_HOST = "192.168.2.34";
		const int ASTERISK_PORT = 5038;
		const string ASTERISK_HOST = "192.168.2.39";
		const string ASTERISK_LOGINNAME = "admin";
		const string ASTERISK_LOGINPWD = "amp111";

		const string ORIGINATE_CONTEXT = "from-internal";
		const string ORIGINATE_CHANNEL = "IAX2/100";
		const string ORIGINATE_EXTRA_CHANNEL = "SIP/101";
		const string ORIGINATE_EXTRA_EXTEN = "101";
		const string ORIGINATE_EXTEN = "101";
		const string ORIGINATE_CALLERID = "Asterisk.NET";
		const int ORIGINATE_TIMEOUT = 15000;

		[STAThread]
		static void Main()
		{
			checkManagerAPI();
			checkFastAGI();
		}

		#region checkFastAGI()
		private static void checkFastAGI()
		{
			Console.WriteLine(@"
Add next lines to your extension.conf file
	exten => 200,1,agi(agi://" + DEV_HOST + @"/customivr)
	exten => 200,2,Hangup()
reload Asterisk and dial 200 from phone.
Also enter 'agi debug' from Asterisk console to more information.
See CustomIVR.cs and fastagi-mapping.resx to detail.

Ctrl-C to exit");
			AsteriskFastAGI agi = new AsteriskFastAGI();
			agi.Start();
		}
		#endregion

		private static ManagerConnection manager;
		private static string monitorChannel = null;
		private static string transferChannel = null;

		#region displayQueue()
		private static void displayQueue()
		{
			manager = new ManagerConnection(ASTERISK_HOST, ASTERISK_PORT, ASTERISK_LOGINNAME, ASTERISK_LOGINPWD);

			try
			{
#if NOTIMEOUT
				manager.Connection.DefaultTimeout = 0;
				manager.Connection.DefaultEventTimeout = 0;
#endif
				manager.Login();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine("Press ENTER to next test or CTRL-C to exit.");
				Console.ReadLine();
				return;
			}

			ResponseEvents re;
			try
			{
				re = manager.SendEventGeneratingAction(new QueueStatusAction());
			}
			catch (EventTimeoutException e)
			{
				// this happens with Asterisk 1.0.x as it doesn't send a QueueStatusCompleteEvent
				re = e.PartialResult;
			}

			foreach (ManagerEvent e in re.Events)
			{
				if (e is QueueParamsEvent)
				{
					QueueParamsEvent qe = (QueueParamsEvent)e;
					Console.WriteLine("QueueParamsEvent" + "\n\tQueue:\t\t" + qe.Queue + "\n\tServiceLevel:\t" + qe.ServiceLevel);
				}
				else if (e is QueueMemberEvent)
				{
					QueueMemberEvent qme = (QueueMemberEvent)e;
					Console.WriteLine("QueueMemberEvent" + "\n\tQueue:\t\t" + qme.Queue + "\n\tLocation:\t" + qme.Location);
				}
				else if (e is QueueEntryEvent)
				{
					QueueEntryEvent qee = (QueueEntryEvent)e;
					Console.WriteLine("QueueEntryEvent" + "\n\tQueue:\t\t" + qee.Queue + "\n\tChannel:\t" + qee.Channel + "\n\tPosition:\t" + qee.Position);
				}
			}
			Console.WriteLine("Press ENTER to next test or CTRL-C to exit.");
			Console.ReadLine();
		}
		#endregion

		#region checkManagerAPI()
		private static void checkManagerAPI()
		{
			manager = new ManagerConnection(ASTERISK_HOST, ASTERISK_PORT, ASTERISK_LOGINNAME, ASTERISK_LOGINPWD);

			// Register user event class
			manager.RegisterUserEventClass(typeof(UserAgentLoginEvent));

			// Add or Remove events
			manager.UserEvents += new UserEventHandler(dam_UserEvents);

			// Dont't display this event
			manager.NewExten += new NewExtenEventHandler(manager_IgnoreEvent);

			// Display all other
			manager.UnhandledEvent += new ManagerEventHandler(dam_Events);

			// +++ Only to debug purpose
			manager.FireAllEvents = true;
			// manager.DefaultEventTimeout = 0;
			// manager.DefaultResponseTimeout = 0;
			manager.PingInterval = 0;
			// +++
			try
			{
				manager.Login();			// Login only (fast)

				Console.WriteLine("Asterisk version : " + manager.Version);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				Console.ReadLine();
				manager.Logoff();
				return;
			}

			{
				Console.WriteLine("\nGetConfig action");
				ManagerResponse response = manager.SendAction(new GetConfigAction("manager.conf"));
				if (response.IsSuccess())
				{
					GetConfigResponse responseConfig = (GetConfigResponse)response;
					foreach (int key in responseConfig.Categories.Keys)
					{
						Console.WriteLine(string.Format("{0}:{1}", key, responseConfig.Categories[key]));
						foreach (int keyLine in responseConfig.Lines(key).Keys)
						{
							Console.WriteLine(string.Format("\t{0}:{1}", keyLine, responseConfig.Lines(key)[keyLine]));
						}
					}
				}
				else
					Console.WriteLine(response);
			}

			{
				Console.WriteLine("\nUpdateConfig action");
				UpdateConfigAction config = new UpdateConfigAction("manager.conf", "manager.conf");
				config.AddCommand(UpdateConfigAction.ACTION_NEWCAT, "testadmin");
				config.AddCommand(UpdateConfigAction.ACTION_APPEND, "testadmin", "secret", "blabla");
				ManagerResponse response = manager.SendAction(config);
				Console.WriteLine(response);
			}

			// Originate call example
			Console.WriteLine("\nPress ENTER key to originate call.\n"
				+ "Start phone (or connect) or make a call to see events.\n"
				+ "After all events press a key to originate call.");
			Console.ReadLine();

			OriginateAction oc = new OriginateAction();
			oc.Context = ORIGINATE_CONTEXT;
			oc.Priority = 1;
			oc.Channel = ORIGINATE_CHANNEL;
			oc.CallerId = ORIGINATE_CALLERID;
			oc.Exten = ORIGINATE_EXTEN;
			oc.Timeout = ORIGINATE_TIMEOUT;
			// oc.Variable = "VAR1=abc|VAR2=def";
			// oc.SetVariable("VAR3", "ghi");
			ManagerResponse originateResponse = manager.SendAction(oc, oc.Timeout);
			Console.WriteLine("Response:");
			Console.WriteLine(originateResponse);

			Console.WriteLine("Press ENTER key to next test.");
			Console.ReadLine();

			//
			// Display result of Show Queues command
			//
			{
				CommandAction command = new CommandAction();
				CommandResponse response = new CommandResponse();
				if (manager.AsteriskVersion == AsteriskVersion.ASTERISK_1_6)
					command.Command = "queue show";
				else
					command.Command = "show queues";
				try
				{
					response = (CommandResponse)manager.SendAction(command);
					Console.WriteLine("Result of " + command.Command);
					foreach (string str in response.Result)
						Console.WriteLine("\t" + str);
				}
				catch (Exception err)
				{
					Console.WriteLine("Response error: " + err);
				}
				Console.WriteLine("Press ENTER to next test or CTRL-C to exit.");
				Console.ReadLine();
			}
			//
			// Display Queues and Members
			//
			ResponseEvents re;
			try
			{
				re = manager.SendEventGeneratingAction(new QueueStatusAction());
			}
			catch (EventTimeoutException e)
			{
				// this happens with Asterisk 1.0.x as it doesn't send a QueueStatusCompleteEvent
				re = e.PartialResult;
			}

			foreach (ManagerEvent e in re.Events)
			{
				if (e is QueueParamsEvent)
				{
					QueueParamsEvent qe = (QueueParamsEvent)e;
					Console.WriteLine("QueueParamsEvent" + "\n\tQueue:\t\t" + qe.Queue + "\n\tServiceLevel:\t" + qe.ServiceLevel);
				}
				else if (e is QueueMemberEvent)
				{
					QueueMemberEvent qme = (QueueMemberEvent)e;
					Console.WriteLine("QueueMemberEvent" + "\n\tQueue:\t\t" + qme.Queue + "\n\tLocation:\t" + qme.Location);
				}
				else if (e is QueueEntryEvent)
				{
					QueueEntryEvent qee = (QueueEntryEvent)e;
					Console.WriteLine("QueueEntryEvent" + "\n\tQueue:\t\t" + qee.Queue + "\n\tChannel:\t" + qee.Channel + "\n\tPosition:\t" + qee.Position);
				}
			}

			Console.WriteLine("Press ENTER to next test or CTRL-C to exit.");
			Console.ReadLine();

			//
			//	To test create 3 extensions:
			//	1 - SIP/4012 w/o voicemail (with eyeBeam softphone)
			//	2 - IAX2/4008 w/o voicemail (with iaxComm softphone)
			//	3 - SIP/4010 w/ voicemal but no phone connect

			//	RedirectCall: call from IAX2/4008 to SIP/4012
			//	Don't answer on SIP/4012 and call must redirect to SIP/4010 (to voicemail really)
			//	Dial event used to define redirect channel

			Console.WriteLine("Redirect Call from " + ORIGINATE_CHANNEL + " to " + ORIGINATE_EXTRA_CHANNEL + " or press ESC.");
			// Wait for Dial Event from ORIGINATE_CHANNEL
			DialEventHandler de = new DialEventHandler(dam_Dial);
			manager.Dial += de;
			while (transferChannel == null)
			{
				System.Threading.Thread.Sleep(100);
				if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
					break;
			}
			manager.Dial -= de;

			// Now send Redirect action
			RedirectAction ra = new RedirectAction();
			ra.Channel = transferChannel;
			ra.ExtraChannel = ORIGINATE_EXTRA_CHANNEL;
			ra.Context = ORIGINATE_CONTEXT;
			ra.Exten = ORIGINATE_EXTRA_EXTEN;
			ra.Priority = 1;
			try
			{
				ManagerResponse mr = manager.SendAction(ra, 10000);
				Console.WriteLine("Transfer Call"
					+ "\n\tResponse:" + mr.Response
					+ "\n\tMessage:" + mr.Message
					);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			//	Monitor call.
			//	Call from IA2/4008 to SIP/4012
			//	Link event used to define monitor channel
			Console.WriteLine("Monitor call. Please call " + ORIGINATE_CHANNEL + " and answer or press ESC.");
			// Wait for Link event
			LinkEventHandler le = new LinkEventHandler(dam_Link);
			manager.Link += le;
			while (monitorChannel == null)
			{
				System.Threading.Thread.Sleep(100);
				if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
					break;
			}
			manager.Link -= le;
			// Now send Monitor action
			MonitorAction ma = new MonitorAction();
			ma.Channel = monitorChannel;
			ma.File = "voicefile";
			ma.Format = "gsm";
			ma.Mix = true;
			try
			{
				ManagerResponse mr = manager.SendAction(ma, 10000);
				Console.WriteLine("Monitor Call"
					+ "\n\tResponse:" + mr.Response);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			manager.Logoff();
		}

		static void manager_IgnoreEvent(object sender, NewExtenEvent e)
		{
			// Ignore this event.
		}

		#endregion

		#region Event handlers
		static void dam_Events(object sender, ManagerEvent e)
		{
			Console.WriteLine(e);
		}

		static void dam_Reload(object sender, ReloadEvent e)
		{
			Console.WriteLine(string.Format("\nReload Event: {0}", e.Message));
		}

		static void dam_Link(object sender, LinkEvent e)
		{
			Console.WriteLine("Link Event"
				+ "\n\tChannel1:\t" + e.Channel1
				+ "\n\tChannel2:\t" + e.Channel2
				);
			if (e.Channel1.StartsWith(ORIGINATE_CHANNEL) || e.Channel2.StartsWith(ORIGINATE_CHANNEL))
				monitorChannel = e.Channel1;
		}

		static void dam_ExtensionStatus(object sender, ExtensionStatusEvent e)
		{
			Console.WriteLine("ExtensionStatus Event"
				+ "\n\tContext\t\t" + e.Context
				+ "\n\tExten\t\t" + e.Exten
				+ "\n\tStatus\t\t" + e.Status
			);
		}

		static void dam_Dial(object sender, DialEvent e)
		{
			Console.WriteLine(
				"Dial Event"
				+ "\n\tCallerId\t" + e.CallerId
				+ "\n\tCallerIdName\t" + e.CallerIdName
				+ "\n\tDestination\t" + e.Destination
				+ "\n\tDestUniqueId\t" + e.DestUniqueId
				+ "\n\tSrc\t\t" + e.Src
				+ "\n\tSrcUniqueId\t" + e.SrcUniqueId
				);
			if (e != null && e.Destination != null && e.Destination.StartsWith(ORIGINATE_CHANNEL))
				transferChannel = e.Src;
		}

		static void dam_Hangup(object sender, HangupEvent e)
		{
			Console.WriteLine("Hangup Event"
				+ "\n\tChannel\t\t" + e.Channel
				+ "\n\tUniqueId\t" + e.UniqueId
				);
		}

		static void dam_NewExten(object sender, NewExtenEvent e)
		{
			Console.WriteLine(
				"New Extension Event"
				+ "\n\tChannel\t\t" + e.Channel
				+ "\n\tExtension\t" + e.Extension
				+ "\n\tContext\t\t" + e.Context
				+ "\n\tDateReceived\t" + e.DateReceived.ToString()
				+ "\n\tPriority\t" + e.Priority.ToString()
				+ "\n\tPrivilege\t" + e.Privilege
				+ "\n\tUniqueId\t" + e.UniqueId
				+ "\n\tAppData\t\t" + e.AppData
				+ "\n\tApplication\t" + e.Application
				);
		}

		static void dam_NewChannel(object sender, NewChannelEvent e)
		{
			Console.WriteLine("New channel Event"
				+ "\n\tChannel\t\t" + e.Channel
				+ "\n\tUniqueId\t" + e.UniqueId
				+ "\n\tCallerId\t" + e.CallerId
				+ "\n\tCallerIdName\t" + e.CallerIdName
				+ "\n\tState\t\t" + e.State
				+ "\n\tDateReceived\t" + e.DateReceived.ToString()
				);
		}

		static void dam_PeerStatus(object sender, PeerStatusEvent e)
		{
			Console.WriteLine("Peer Status Event"
				+ "\n\tPeer\t\t" + e.Peer
				+ "\n\tStatus\t\t" + e.PeerStatus
				+ "\n\tDateReceived\t" + e.DateReceived.ToString()
				);
		}

		static void dam_UserEvents(object sender, UserEvent e)
		{
			if (e is UserAgentLoginEvent)
			{
				Console.WriteLine("User Event - AgentLogin:"
					+ "\n\tAgent\t\t" + ((UserAgentLoginEvent)e).Agent
					);
			}
			else
			{
				Console.WriteLine("User Event:"
					+ "\n\tUserEventName\t\t" + e.UserEventName
					);
				foreach (System.Collections.Generic.KeyValuePair<string, string> pair in e.Attributes)
				{
					Console.WriteLine(String.Format("\t{0}\t{1}", pair.Key, pair.Value));
				}
			}
		}
		#endregion
	}

	public class UserAgentLoginEvent : UserEvent
	{
		private string agent;
		public string Agent
		{
			get { return agent; }
			set { agent = value; }
		}

		public UserAgentLoginEvent(ManagerConnection source)
			: base(source)
		{
		}
	}
}