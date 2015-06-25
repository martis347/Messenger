using System;
using System.Net;
using System.Web.Http;

namespace Messenger.WebApi.Controllers
{
    public class MessageController : ApiController
    {
        [HttpGet]
        public HttpStatusCode Send(string message, string username)
        {
            ChatUser user = Singleton.GetServer.User(username);
            if (user == null)
                return HttpStatusCode.NoContent;

            user.Display.Write(message);
            return HttpStatusCode.OK;
        }

        [HttpGet]
        public ChatInfo GetText(string userName, string roomName)
        {
            ChatRoom room = Singleton.GetServer.Room(roomName);
            if (room == null)
                return new ChatInfo() { Status = HttpStatusCode.NotFound };

            return room.GiveText(userName);
        }
    }
}
