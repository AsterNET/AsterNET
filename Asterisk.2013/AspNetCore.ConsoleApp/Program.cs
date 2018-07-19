using AsterNET.Manager;
using System;

namespace AspNetCore.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Address: ");
            var address = Console.ReadLine();

            Console.Write("\nPort: ");
            var port = int.Parse(Console.ReadLine());

            Console.Write("\nUser: ");
            var user = Console.ReadLine();

            Console.Write("\nPassword: ");
            var password = Console.ReadLine();

            Console.Clear();

            var manager = new ManagerConnection(address, port, user, password);
            try
            {
                manager.Login();
                Console.WriteLine("Asterisk connected: " + manager.AsteriskVersion);
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connect\n" + ex.Message);
                Console.ReadKey();
                manager.Logoff();
            }
        }
    }
}
