using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Api.Controllers;
using OnionPattern.Api.Controllers.Platform;
using OnionPattern.Domain.Services.Requests.Platform.Async;
using OnionPattern.TestUtils;
using System;

namespace OnionPattern.Api.Tests.Controllers.Platform
{
    public class PlatformAsyncControllerTests
    {
        [TestClass]
        public class ConstructorTests
        {
            private IPlatformRequestAsyncAggregate fakePlatformRequestAsyncAggregate;
            private PlatformsAsyncController controller;

            [TestInitialize]
            public void TestInitalize()
            {
                fakePlatformRequestAsyncAggregate = A.Fake<IPlatformRequestAsyncAggregate>();
                controller = new PlatformsAsyncController(fakePlatformRequestAsyncAggregate);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                Fake.ClearConfiguration(fakePlatformRequestAsyncAggregate);
            }

            [TestMethod]
            public void IPlatformRequestAsyncAggregatetIsNull()
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
            public void ShouldInheritFromBaseAsyncController()
            {
                controller.Should().BeAssignableTo<BaseAsyncController>();
            }


            [TestMethod]
            public void ShouldBeTypeOfPlatfomsAsyncController()
            {
                controller.Should().BeOfType<PlatformsAsyncController>();
            }

        }
    }
}
