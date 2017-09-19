using System;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Repository;

namespace OnionPattern.Service.Tests.Requests
{
    public class BaseRequestTests
    {
        [TestClass]
        public class ConstructorTests
        {
            private IRepository<FakeEntity> fakeRepository;
            private IRepositoryAggregate fakeRepositoryAggregate;

            [TestInitialize]
            public void TestInitialize()
            {
                fakeRepository = A.Fake<IRepository<FakeEntity>>();
                fakeRepositoryAggregate = A.Fake<IRepositoryAggregate>();
            }

            [TestCleanup]
            public void TestCleanup()
            {
                Fake.ClearConfiguration(fakeRepository);
                Fake.ClearConfiguration(fakeRepositoryAggregate);
            }

            [TestMethod]
            public void RepositoryIsNull()
            {
                Action ctor = () => new MockBaseRequest(null, fakeRepositoryAggregate);
                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: repository cannot be null.");
            }

            [TestMethod]
            public void RepositoryAggregateIsNull()
            {
                Action ctor = () => new MockBaseRequest(fakeRepository, null);
                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: repositoryAggregate cannot be null.");
            }

            [TestMethod]
            public void IsValid()
            {
                var baseRequest = new MockBaseRequest(fakeRepository, fakeRepositoryAggregate);

                baseRequest.Should().NotBeNull();
                baseRequest.Should().BeAssignableTo<BaseServiceRequest<FakeEntity, string>>();
                baseRequest.Should().BeOfType<MockBaseRequest>();
            }
        }

        #region Mocks

        public class MockBaseRequest : BaseServiceRequest<FakeEntity, string>
        {
            public MockBaseRequest(IRepository<FakeEntity> repository, IRepositoryAggregate repositoryAggregate) : base(repository, repositoryAggregate) { }

            public override Task<string> Execute()
            {
                throw new NotImplementedException();
            }
        }
        public class FakeEntity : VideoGameEntity { }

        #endregion Mocks
    }
}
