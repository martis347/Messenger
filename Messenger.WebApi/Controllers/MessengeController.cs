using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Messenger.WebApi.Controllers
{
    public class MessengeController : ApiController
    {
        [HttpPost]
        public void Send(string message,string roomName, string username)
        {
            //Singleton.GetServer.Room(Singleton.GetServer.)
        }
    }
}
