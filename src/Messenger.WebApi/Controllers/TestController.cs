using System.Web.Http;

namespace Messenger.WebApi.Controllers
{
    public class TestController: ApiController
    {
        [HttpGet]
        public string Abc()
        {
            return "This \nis\ntest";
        }
    }
}
