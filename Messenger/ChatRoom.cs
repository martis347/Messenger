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
        private int _usersOnline;


        private readonly IDisplay _display; //= new RoomDisplay(); { get; private set; }

        public ChatRoom(string chatRoomName, ChatUser user)
        {
            if (chatRoomName == null) 
                throw new Exception("Chat room name is null");
            _chatRoomName = chatRoomName;
            _usersList.Add(user.Username, user);
            _usersOnline = 1;

            _display = new RoomDisplay();
        }

        public bool AddUser(ChatUser user)
        {
            if (RoomHasSpace())
            {
                _usersList.Add(user.Username, user);
                _newMessages.Add(user.Username,"");
                _usersOnline++;
                _display.Write(DisplayCommands.NewUserAdded(user.Username));
                return true;
            }
            return false;
        }

        public bool RemoveUser(ChatUser user)
        {
            if(_usersOnline<=0)
                return false;

            _usersList.Remove(user.Username);
            _usersOnline--;
            return true;
        }

        public void AddNewText(string text,string user)
        {
            foreach (var users in _usersList.Where(users => users.Key != user))
            {
                _newMessages[user] += text;
            }
        }

        public string GiveText(string user)
        {
            string text = _newMessages[user];
            _newMessages[user] = "";
            return text;
        }

        private bool RoomHasSpace()
        {
            return (_usersOnline < USERS_LIMIT);
        }

    }
}