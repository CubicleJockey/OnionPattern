using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Service.Requests;
using OnionPattern.Service.Tests.Requests.Mocks;
using OnionPattern.TestUtils;
using System;

namespace OnionPattern.Service.Tests.Requests
{
    public class BaseRequestAsyncAggregateTests
    {
        [TestClass]
        public class ConstructorTests : TestBaseAsync<FakeEntity>
        {
            [TestInitialize]
            public void TestInitialize()
            {
                InitializeFakes();
            }

            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
            }

            [TestMethod]
            public void RepositoryAsyncIsNull()
            {
                Action ctor = () => new MockBaseRequestAsyncAggregate(null, FakeRepositoryAsyncAggregate);

                ctor.Should()
                    .Throw<ArgumentNullException>()
                    .WithMessage(ExceptionMessages.ArgumentNull("repositoryAsync"));
            }

            [TestMethod]
            public void RepositoryAsyncAggregateIsNull()
            {
                Action ctor = () => new MockBaseRequestAsyncAggregate(FakeRepositoryAsync, null);

                ctor.Should()
                    .Throw<ArgumentNullException>()
                    .WithMessage(ExceptionMessages.ArgumentNull("repositoryAsyncAggregate"));
            }

            [TestMethod]
            public void Inheritence()
            {
                var baseRequestAsync = new MockBaseRequestAsyncAggregate(FakeRepositoryAsync, FakeRepositoryAsyncAggregate);

                baseRequestAsync.Should().NotBeNull();
                baseRequestAsync.Should().BeAssignableTo<BaseRequestAsyncAggregate<FakeEntity>>();
                baseRequestAsync.Should().BeOfType<MockBaseRequestAsyncAggregate>();
            }
        }
    }
}
