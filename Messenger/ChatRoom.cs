using System;
using System.Collections.Generic;
using System.Linq;
using Messenger.Displays;

namespace Messenger
{
    public class ChatRoom
    {
        private readonly Dictionary<string, ChatUser> _usersList = new Dictionary<string, ChatUser>();
        private readonly Dictionary<string, string> _newMessages = new Dictionary<string, string>();
        private readonly string _chatRoomName;

        private const int USERS_LIMIT = 5;

        private readonly IDisplay _display;

        public ChatRoom(string chatRoomName, ChatUser user)
        {
            if (chatRoomName == null) 
                throw new Exception("Chat room name is null");
            _chatRoomName = chatRoomName;
            _usersList.Add(user.Username, user);

            _newMessages.Add(user.Username, "");

            _display = new RoomDisplay();
        }

        public RequestStatus AddUser(ChatUser user)
        {
            if (!RoomHasSpace())
                return RequestStatus.RoomIsFull;

            try
            {
                _usersList.Add(user.Username, user);
                _newMessages.Add(user.Username, "");
            }
            catch (Exception)
            {
                return RequestStatus.UserAlreadyExists;
            }

            _display.Write(DisplayCommands.NewUserAdded(user.Username));

            return RequestStatus.Success;
        }

        public RequestStatus RemoveUser(ChatUser user)
        {
            if (_usersList.Count <= 0)
                return RequestStatus.RoomIsEmpty;
            try
            {
                _usersList.Remove(user.Username);
                return RequestStatus.Success;
            }
            catch (Exception e)
            {
                return RequestStatus.UserNotFound;
            }
        }

        public void AddNewText(string text,string user)
        {
            try
            {
                foreach (var users in _usersList.Where(users => users.Key != user))
                {
                    _newMessages[users.Key] += String.Concat(user, ": ", text, "%0D%0A");
                }
            }
            catch (Exception)
            {
                throw new Exception("Unable to add new text for all users");
            }
        }

        public ChatInfo GiveText(string user)
        {
            ChatInfo chatInfo = new ChatInfo
            {
                NewMessages = _newMessages[user],
                UsersInRoom = _usersList.Count,
                Status = RequestStatus.Success
            };
            _newMessages[user] = "";
            return chatInfo;
        }

        private bool RoomHasSpace()
        {
            return (_usersList.Count < USERS_LIMIT);
        }

    }
}