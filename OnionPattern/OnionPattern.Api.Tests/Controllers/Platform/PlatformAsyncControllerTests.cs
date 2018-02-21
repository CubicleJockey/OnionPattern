using System;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Api.Controllers;
using OnionPattern.Api.Controllers.Platform;
using OnionPattern.Domain.Services.Requests.Platform.Async;

namespace OnionPattern.Api.Tests.Controllers.Platform
{
    public class PlatformAsyncControllerTests
    {
        [TestClass]
        public class ConstructorTests
        {
            private IPlatformRequestAsyncAggregate fakePlatformRequestAsyncAggregate;
            private PlatfomsAsyncController controller;

            [TestInitialize]
            public void TestInitalize()
            {
                fakePlatformRequestAsyncAggregate = A.Fake<IPlatformRequestAsyncAggregate>();
                controller = new PlatfomsAsyncController(fakePlatformRequestAsyncAggregate);
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
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: requestAggregate");
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
                controller.Should().BeOfType<PlatfomsAsyncController>();
            }

        }
    }
}
