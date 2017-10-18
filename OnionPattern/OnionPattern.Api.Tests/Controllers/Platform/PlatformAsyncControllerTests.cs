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

            [TestInitialize]
            public void TestInitalize()
            {
                fakePlatformRequestAsyncAggregate = A.Fake<IPlatformRequestAsyncAggregate>();
            }

            [TestCleanup]
            public void TestCleanup()
            {
                Fake.ClearConfiguration(fakePlatformRequestAsyncAggregate);
            }

            [TestMethod]
            public void Inheritence()
            {
                var controller = new PlatfomsAsyncController(fakePlatformRequestAsyncAggregate);

                controller.Should().NotBeNull();
                controller.Should().BeAssignableTo<Controller>();
                controller.Should().BeAssignableTo<BaseAsyncController>();
                controller.Should().BeOfType<PlatfomsAsyncController>();
            }
        }
    }
}
