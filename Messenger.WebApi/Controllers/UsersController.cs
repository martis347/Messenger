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
        public bool CreateUser(string username)
        {
            Singleton.GetServer.CreateUser(username);
            return true;
            //TODO: username exists check
        }

        [HttpGet]
        public bool CreateRoom(string roomName, string username)
        {
            Singleton.GetServer.CreateRoom(roomName, Singleton.GetServer.User(username));
            Singleton.GetServer.User(username).CurrentChatRoomName = roomName;
            return true;
            //TODO: room name exists check
        }

        [HttpGet]
        public void JoinRoom(string roomName, string username)
        {
            Singleton.GetServer.Room(roomName).AddUser(Singleton.GetServer.User(username));
            Singleton.GetServer.User(username).CurrentChatRoomName = roomName;
        }

    }
}
