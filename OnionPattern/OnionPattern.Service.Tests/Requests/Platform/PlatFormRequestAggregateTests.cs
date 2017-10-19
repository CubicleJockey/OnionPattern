using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Platform;
using OnionPattern.Service.Requests;
using OnionPattern.Service.Requests.Platform;

namespace OnionPattern.Service.Tests.Requests.Platform
{
    public class PlatFormRequestAggregateTests
    {
        [TestClass]
        public class ConstructorTests
        {
            [TestMethod]
            public void Inheritence()
            {
                var fakeRepository = A.Fake<IRepository<Domain.Entities.Platform>>();
                var fakeRepositoryAggregate = A.Fake<IRepositoryAggregate>();

                var platformRequestAggregate = new PlatformRequestAggregate(fakeRepository, fakeRepositoryAggregate);

                platformRequestAggregate.Should().NotBeNull();
                platformRequestAggregate.Should().BeAssignableTo<IPlatformRequestAggregate>();
                platformRequestAggregate.Should().BeAssignableTo<BaseRequestAggregate<Domain.Entities.Platform>>();
                platformRequestAggregate.Should().BeOfType<PlatformRequestAggregate>();
            }
        }
    }
}
