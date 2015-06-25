using System;
using System.Collections.Generic;
using System.Net;
using Messenger.Displays;

namespace Messenger
{
    public class Server
    {
        private readonly Dictionary<string, ChatRoom> _chatRooms = new Dictionary<string, ChatRoom>();
        private readonly Dictionary<string, ChatUser> _users = new Dictionary<string, ChatUser>();

        public HttpStatusCode CreateRoom(string roomName, ChatUser user)
        {
            try
            {
                _chatRooms.Add(roomName, new ChatRoom(roomName, user));
                return HttpStatusCode.OK;
            }
            catch (Exception)
            {
                return HttpStatusCode.Conflict;
            }
        }

        public void RemoveRoom(string roomName)
        {
            _chatRooms.Remove(roomName);
        }

        public HttpStatusCode CreateUser(string username)
        {
            var user = new ChatUser(username,new UserDisplay("NONE",username));
            try
            {
                _users.Add(username, new ChatUser(username, new UserDisplay("NONE", username)));
                return HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                return HttpStatusCode.Conflict;
            }
        }

        public ChatRoom Room(string name)
        {
            return _chatRooms[name];
        }
        public ChatUser User(string name)
        {
            return _users[name];
        }
    }
}