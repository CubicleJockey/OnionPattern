using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Api.Controllers;
using OnionPattern.Domain.Services.Requests.Platform.Async;

namespace OnionPattern.Api.Tests.Controllers
{
    public class PlatformAsyncControllerTests
    {
        [TestClass]
        public class ConstructorTests
        {
            private IGetAllPlatformsRequestAsync fakeAllPlatformsRequest;

            [TestInitialize]
            public void TestInitalize()
            {
                fakeAllPlatformsRequest = A.Fake<IGetAllPlatformsRequestAsync>();
            }

            [TestCleanup]
            public void TestCleanup()
            {
                Fake.ClearConfiguration(fakeAllPlatformsRequest);
            }

            [TestMethod]
            public void Inheritence()
            {
                var controller = new PlatfomsAsyncController(fakeAllPlatformsRequest);

                controller.Should().NotBeNull();
                controller.Should().BeAssignableTo<Controller>();
                controller.Should().BeAssignableTo<BaseAsyncController>();
                controller.Should().BeOfType<PlatfomsAsyncController>();
            }
        }
    }
}
