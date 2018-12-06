using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Api.Controllers;

namespace OnionPattern.Api.Tests.Controllers
{
    public class BaseAsyncControllerTests
    {
        [TestClass]
        public class ConstructorTests
        {
            private BaseAsyncController controller;

            [TestInitialize]
            public void TestInitailize()
            {
                controller = A.Fake<BaseAsyncController>();
            }

            [TestMethod]
            public void InheritsFromBaseAsyncController()
            {
                controller.Should().BeAssignableTo<BaseAsyncController>();
            }

            [TestMethod]
            public void InheritsFromController()
            {
                controller.Should().BeAssignableTo<Controller>();
            }
        }
    }
}
