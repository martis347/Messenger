using System;
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
                Console.WriteLine("Press any key to exit");
                Console.ReadLine();
            }
        }
    }
}
