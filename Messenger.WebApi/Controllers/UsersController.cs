using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Messenger.WebApi.Controllers
{
    public class UsersController : ApiController
    {
        [HttpGet]
        public HttpStatusCode CreateUser(string username)
        {
            HttpStatusCode status = Singleton.GetServer.CreateUser(username);
            return status;
        }

        [HttpGet]
        public HttpStatusCode CreateRoom(string roomName, string username)
        {
            ChatUser user = Singleton.GetServer.User(username);
            if(user == null)
                return HttpStatusCode.NoContent;

            HttpStatusCode status = Singleton.GetServer.CreateRoom(roomName, user);

            if(status == HttpStatusCode.OK)
                Singleton.GetServer.User(username).CurrentChatRoomName = roomName;

            return status;
        }

        [HttpGet]
        public HttpStatusCode JoinRoom(string roomName, string username)
        {
            ChatUser user = Singleton.GetServer.User(username);
            if (user == null)
                return HttpStatusCode.NoContent;

            ChatRoom room = Singleton.GetServer.Room(roomName);
            if (room == null)
                return HttpStatusCode.NoContent;

            HttpStatusCode status = room.AddUser(user);

            if (status == HttpStatusCode.OK)
                Singleton.GetServer.User(username).CurrentChatRoomName = roomName;

            return status;
        }

    }
}
