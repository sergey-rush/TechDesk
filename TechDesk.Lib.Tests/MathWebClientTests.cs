using System;
using System.Collections.Generic;
using TechDesk.IService;
using TechDesk.Lib;
using Moq;
using NUnit.Framework;

namespace TechDesk.Lib.Tests
{
    [TestFixture]
    public class MathWebClientTests
    {
        private MathWebClient mathWebClient;

        [SetUp]
        public void Setup()
        {
            Mock<ILogService> logService = new Mock<ILogService>();
            mathWebClient = new MathWebClient(logService.Object);
        }

        [Test]
        public void AddTest()
        {
            var result = mathWebClient.Add(3, 2);
            Assert.AreEqual(5, result);
        }

        [Test]
        public void MultiplyTest()
        {
            var result = mathWebClient.Multiply(3, 2);
            Assert.AreEqual(6, result);
        }

        [Test]
        public void DivideTest()
        {
            var result = mathWebClient.Divide(6, 2);
            Assert.AreEqual(3, result);
        }

        [Test]
        public void DivideByZeroExceptionTest()
        {
            var result = mathWebClient.Divide(8, 0);
            Assert.AreEqual(0, result);
        }
    }
}
