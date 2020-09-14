using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TechDesk.Api.Controllers;
using TechDesk.Common;
using TechDesk.IService;
using TechDesk.Model.ViewModel;
using Moq;
using NUnit.Framework;

namespace TechDesk.Api.Tests
{
    [TestFixture]
    public class MathControllerTests
    {
        private MathController controller;
        private IEnumerable<Log> expected;

        [SetUp]
        public void Setup()
        {
            var log = new Log
            {
                Id = 10, LogLevel = LogLevel.Info, Info = "Log Info", DataType = nameof(MathController), Created = DateTime.Now
            };

            expected = new List<Log> {log};

            Mock<ILogService> logService = new Mock<ILogService>();
            logService.Setup(x => x.GetList(It.IsAny<Int32>())).Returns(expected);

            controller = new MathController(logService.Object)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }


        [Test]
        public void DivideByZeroExceptionTest()
        {
            var response = controller.Divide(8, 0);
            Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        [Test]
        public void DivideTest()
        {
            var response = controller.Divide(6, 2);
            var result = response.TryGetContentValue<Int32>(out int actual);
            Assert.IsTrue(result);
            Assert.AreEqual(3, actual);
        }

        [Test]
        public void MultiplyTest()
        {
            var response = controller.Multiply(3, 2);
            var result = response.TryGetContentValue<Int32>(out int actual);
            Assert.IsTrue(result);
            Assert.AreEqual(6, actual);
        }

        [Test]
        public void AddTest()
        {
            var response = controller.Add(3,2);
            var result = response.TryGetContentValue<Int32>(out int actual);
            Assert.IsTrue(result);
            Assert.AreEqual(5, actual);
        }

        [Test]
        public void GetTest()
        {
            var response = controller.Get();
            var result = response.TryGetContentValue<List<Log>>(out var actual);
            Assert.IsTrue(result);
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
