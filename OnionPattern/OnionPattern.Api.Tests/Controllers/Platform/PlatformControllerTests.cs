using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Api.Controllers;
using OnionPattern.Api.Controllers.Platform;
using OnionPattern.Domain.Services.Requests.Platform;
using OnionPattern.TestUtils;
using System;

namespace OnionPattern.Api.Tests.Controllers.Platform
{
    public class PlatformControllerTests
    {

        [TestClass]
        public class ConstructorTests
        {
            private IPlatformRequestAggregate fakePlatformRequestAggregate;
            private PlatformsController controller;

            [TestInitialize]
            public void TestInitalize()
            {
                fakePlatformRequestAggregate = A.Fake<IPlatformRequestAggregate>();
                controller = new PlatformsController(fakePlatformRequestAggregate);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                Fake.ClearConfiguration(fakePlatformRequestAggregate);
            }

            [TestMethod]
            public void IPlatformRequestAggregateIsNull()
            {
                Action ctor = () => new PlatformsController(null);

                ctor.Should()
                    .Throw<ArgumentNullException>()
                    .WithMessage(ExceptionsUtility.NullArgument("requestAggregate"));
            }

            [TestMethod]
            public void ShouldInheritFromController()
            {
                controller.Should().BeAssignableTo<Controller>();
            }

            [TestMethod]
            public void ShouldInheritFromBaseController()
            {
                controller.Should().BeAssignableTo<BaseController>();
            }

            [TestMethod]
            public void ShouldBeTypeOfPlatfomsController()
            {
                controller.Should().BeOfType<PlatformsController>();
            }
        }
    }
}
