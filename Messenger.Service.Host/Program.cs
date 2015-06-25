using System;
using Messenger.WebApi;
using Microsoft.Owin.Hosting;

namespace Messenger.Service.Host
{
    static class Program
    {
        static void Main()
        {
            using (WebApp.Start<Startup>("http://localhost:1234"))
            {
                Console.WriteLine("Service is running");
                Console.ReadLine();
            }
        }
    }
}
