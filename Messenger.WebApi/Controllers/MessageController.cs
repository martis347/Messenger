using System;
using System.Web.Http;

namespace Messenger.WebApi.Controllers
{
    public class MessageController : ApiController
    {
        [HttpGet]
        public void Send(string message,string roomName, string username)
        {
            Singleton.GetServer.User(username).Display.Write(message);
        }

        [HttpGet]
        public string GetText(string userName, string roomName)
        {
            return Singleton.GetServer.Room(roomName).GiveText(userName);
        }
    }
}
