using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Service.Requests;

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
                TestConstructor<BaseRequestAsyncAggregate<FakeEntity>>(null, FakeRepositoryAsyncAggregate);
            }

            [TestMethod]
            public void RepositoryAsyncAggregateIsNull()
            {

                TestConstructor<BaseRequestAsyncAggregate<FakeEntity>>(FakeRepositoryAsync, null);
            }

            [TestMethod]
            public void Inheritence()
            {
                var baseRequestAsync = A.Fake<BaseRequestAsyncAggregate<FakeEntity>>();

                baseRequestAsync.Should().BeAssignableTo<BaseRequestAsyncAggregate<FakeEntity>>();
            }
        }
    }
}
