using System.Web.Http;

namespace Messenger.WebApi.Controllers
{
    public class UsersController : ApiController
    {
        [HttpGet]
        public RequestStatus CreateUser(string username)
        {
            RequestStatus status = Singleton.GetServer.CreateUser(username);
            return status;
        }

        [HttpGet]
        public RequestStatus CreateRoom(string roomName, string username)
        {
            ChatUser user = Singleton.GetServer.User(username);
            if(user == null)
                return RequestStatus.UserNotFound;

            RequestStatus status = Singleton.GetServer.CreateRoom(roomName, user);

            if (status == RequestStatus.Success)
                Singleton.GetServer.User(username).CurrentChatRoomName = roomName;

            return status;
        }

        [HttpGet]
        public RequestStatus JoinRoom(string roomName, string username)
        {
            ChatUser user = Singleton.GetServer.User(username);
            if (user == null)
                return RequestStatus.UserNotFound;

            ChatRoom room = Singleton.GetServer.Room(roomName);
            if (room == null)
                return RequestStatus.RoomNotFound;

            RequestStatus status = room.AddUser(user);

            if (status == RequestStatus.Success)
                Singleton.GetServer.User(username).CurrentChatRoomName = roomName;

            return status;
        }

    }
}
