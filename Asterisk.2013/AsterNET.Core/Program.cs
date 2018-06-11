using System;
using System.Diagnostics;
using System.Reflection;
using AsterNET.Manager;
using AsterNET.Manager.Event;

namespace AsterNET.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new ManagerConnection("192.168.3.201", 5038, "admin", "admin");
            manager.FireAllEvents = true;
            var fi = manager.GetType().GetField("internalEvent", BindingFlags.Instance | BindingFlags.NonPublic);
            // ReSharper disable once JoinDeclarationAndInitializer
            ManagerEventHandler val;
            val = (sender, e) => 
            {
                Debug.WriteLine(e.ToString());
                Console.WriteLine(e.ToString());
            };
            fi?.SetValue(manager, val);

            try
            {
                // Uncomment next 2 line comments to Disable timeout (debug mode)
                manager.DefaultResponseTimeout = 0;
                manager.DefaultEventTimeout = 0;
                manager.Login();
                Console.WriteLine("Connected...");
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine("Error connect\n" + ex.Message);
                manager.Logoff();
            }
        }
    }
}
