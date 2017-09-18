using System;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Repository;
using OnionPattern.Service.Requests;

namespace OnionPattern.Service.Tests.Requests
{
    public class BaseRequestTests
    {
        [TestClass]
        public class ConstructorTests
        {
            private IRepository<FakeEntity> fakeRepository;

            [TestInitialize]
            public void TestInitialize()
            {
                fakeRepository = A.Fake<IRepository<FakeEntity>>();
            }

            [TestCleanup]
            public void TestCleanup()
            {
                Fake.ClearConfiguration(fakeRepository);
            }

            [TestMethod]
            public void RepositoryIsNull()
            {
                Action ctor = () => new MockBaseRequest(null);
                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: repository cannot be null.");
            }

            [TestMethod]
            public void IsValid()
            {
                var baseRequest = new MockBaseRequest(fakeRepository);

                baseRequest.Should().NotBeNull();
                baseRequest.Should().BeAssignableTo<BaseRequest<FakeEntity, string>>();
                baseRequest.Should().BeOfType<MockBaseRequest>();
            }
        }

        #region Mocks

        public class MockBaseRequest : BaseRequest<FakeEntity, string>
        {
            public MockBaseRequest(IRepository<FakeEntity> repository) : base(repository) { }
            public override string Execute()
            {
                throw new System.NotImplementedException("Oh noes n' stuff!");
            }
        }
        public class FakeEntity : VideoGameEntity { }

        #endregion Mocks
    }
}
