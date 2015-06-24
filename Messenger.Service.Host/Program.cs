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
                Singleton.GetServer.CreateUser("A");
                Singleton.GetServer.CreateUser("B");
                Singleton.GetServer.CreateUser("C");
                Singleton.GetServer.CreateRoom("aba", Singleton.GetServer.User("A"));
                Singleton.GetServer.CreateRoom("abas", Singleton.GetServer.User("C"));
                Singleton.GetServer.Room("abas").AddUser(Singleton.GetServer.User("B"));

                while (true)
                {
                    Console.WriteLine("Press A or B to choose user");
                    var user = Console.ReadLine();
                    Console.WriteLine("Enter your message");
                    if (user == "A")
                        Singleton.GetServer.User("A").Display.Write(Console.ReadLine());
                    else
                    {
                        Singleton.GetServer.User("B").Display.Write(Console.ReadLine());                    
                    }
                }
            }
        }
    }
}
