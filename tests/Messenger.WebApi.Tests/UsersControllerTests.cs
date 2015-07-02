using System;
using System.Net.Http;
using System.Web.Http;
using Messenger.WebApi.Controllers;
using Moq;
using NUnit.Framework;

namespace Messenger.WebApi.Tests
{
    [TestFixture]
    public class UsersControllerTests
    {
        private UsersController _controller;
        private Mock<Server> _mockSingleton;
        [SetUp]
        public void Setup()
        {
            _controller = new UsersController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            Server singleton = Singleton.GetServer;

            System.Reflection.FieldInfo instance = typeof(Singleton).GetField("Instance.Server", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

            _mockSingleton = new Mock<Server>();
                instance.SetValue(null, _mockSingleton.Object);
        }
        [Test]
        public void CreateUserBadRequestTest()
        {
            _mockSingleton.Object.CreateUser("Test");
            Console.WriteLine(_mockSingleton.Object.User("Test").Username);
        }
    }
}
