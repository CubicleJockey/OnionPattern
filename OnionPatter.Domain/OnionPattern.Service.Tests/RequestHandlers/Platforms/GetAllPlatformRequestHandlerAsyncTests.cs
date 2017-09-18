using FakeItEasy;
using FluentAssertions;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Repository;
using OnionPattern.Service.RequestHandlers.Platform;
using OnionPattern.Service.Requests.Platform;
using OnionPattern.Service.Responses;

namespace OnionPattern.Service.Tests.RequestHandlers.Platforms
{
    public class GetAllPlatformRequestHandlerAsyncTests
    {
        [TestClass]
        public class ConstructorTests
        {
            [TestMethod]
            public void Inheritence()
            {
                var handlerAsync = new GetAllPlatformRequestHandlerAsync();

                handlerAsync.Should().NotBeNull();
                handlerAsync.Should()
                    .BeAssignableTo<IAsyncRequestHandler<GetAllPlatformsRequest, GetAllPlatformsResponse>>();
                handlerAsync.Should().BeOfType<GetAllPlatformRequestHandlerAsync>();
            }
        }

        [TestClass]
        public class MethodsTests
        {
            private IRepository<Platform> fakeRepository;

            [TestInitialize]
            public void TestInitialize()
            {
                fakeRepository = A.Fake<IRepository<Platform>>();
            }

            [TestCleanup]
            public void TestCleanup()
            {
                Fake.ClearConfiguration(fakeRepository);
            }


        }
    }
}
