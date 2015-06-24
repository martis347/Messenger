using System;
using System.Web.Http;

namespace Messenger.WebApi.Controllers
{
    public class TestController: ApiController
    {
        [HttpGet]
        public string Get()
        {
            Console.WriteLine("dfgdg");
            return "Fuck you";
        }
    }
}
