using System;
using System.Net;
using System.Web.Http;

namespace Messenger.WebApi.Controllers
{
    public class MessageController : ApiController
    {
        [HttpGet]
        public RequestStatus Send(string message, string username)
        {
            ChatUser user = Singleton.GetServer.User(username);
            if (user == null)
                return RequestStatus.UserNotFound;

            user.Display.Write(message);
            return RequestStatus.Success;
        }

        [HttpGet]
        public ChatInfo GetText(string userName, string roomName)
        {
            ChatRoom room = Singleton.GetServer.Room(roomName);
            if (room == null)
                return new ChatInfo() { Status = RequestStatus.RoomNotFound };

            return room.GiveText(userName);
        }
    }
}
