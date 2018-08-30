using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OnionPattern.Service.Tests.Requests
{
    public class BaseRequestAsyncTests
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
                TestConstructor<BaseServiceRequestAsync<FakeEntity>>(null, FakeRepositoryAsyncAggregate);
            }

            [TestMethod]
            public void RepositoryAsyncAggregateIsNull()
            {
                TestConstructor<BaseServiceRequestAsync<FakeEntity>>(FakeRepositoryAsync, null);
            }

            [TestMethod]
            public void IsValid()
            {
                var baseRequest = A.Fake<BaseServiceRequestAsync<FakeEntity>>();

                baseRequest.Should().BeAssignableTo<BaseServiceRequestAsync<FakeEntity>>();
            }
        }
    }


}
