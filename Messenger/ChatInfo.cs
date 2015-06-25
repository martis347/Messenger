using System.Net;

namespace Messenger
{
    public class ChatInfo
    {
        public string NewMessages { get; set; }
        public int UsersInRoom { get; set; }
        public HttpStatusCode Status { get; set; }
    }
}
