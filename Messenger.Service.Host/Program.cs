using System;
using Messenger.Displays;
using Messenger.WebApi;
using Microsoft.Owin.Hosting;

namespace Messenger.Service.Host
{
    class Program
    {
        static void Main()
        {
            using (WebApp.Start<Startup>("http://localhost:1234"))
            {
                Console.ReadLine();
                Console.WriteLine("Added");

                Singleton.GetServer.CreateUser("A");
                Singleton.GetServer.CreateUser("B");
                Singleton.GetServer.CreateUser("C");
                Singleton.GetServer.Room("aba").AddUser(Singleton.GetServer.User("A"));
                Singleton.GetServer.Room("aba").AddUser(Singleton.GetServer.User("C"));
                Singleton.GetServer.Room("aba").AddUser(Singleton.GetServer.User("B"));

                Singleton.GetServer.Room("aba").AddNewText("testing ababa", "A");
                Singleton.GetServer.Room("aba").AddNewText("testing 2", "B");
                Singleton.GetServer.Room("aba").AddNewText("testing 34", "C");

                Console.ReadLine();
                Singleton.GetServer.Room("aba").AddNewText("testukas","D");
                //while (true)
                //{
                //    Console.WriteLine("Press A or B to choose user");
                //    var user = Console.ReadLine();
                //    Console.WriteLine("Enter your message");
                //    if (user == "A")
                //        Singleton.GetServer.User("A").Display.Write(Console.ReadLine());
                //    else
                //    {
                //        Singleton.GetServer.User("B").Display.Write(Console.ReadLine());                    
                //    }
                //}
                Console.ReadLine();
            }
        }
    }
}
