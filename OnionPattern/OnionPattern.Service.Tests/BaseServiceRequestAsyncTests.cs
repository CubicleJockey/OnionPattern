using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OnionPattern.Service.Tests
{
    public class BaseServiceRequestAsyncTests
    {
        [TestClass]
        public class ConstructorTests
        {
            private readonly BaseServiceRequestAsync<FakeEntity> fakeBaseServiceRequestAsync;

            public ConstructorTests()
            {
                fakeBaseServiceRequestAsync = A.Fake<BaseServiceRequestAsync<FakeEntity>>();
            }

            [TestCleanup]
            public void TestCleanup()
            {
                Fake.ClearConfiguration(fakeBaseServiceRequestAsync);
            }

            [TestMethod]
            public void InheritsFromServiceHandleError()
            {
                fakeBaseServiceRequestAsync.Should().BeAssignableTo<ServiceHandleError>();
            }
        }
    }
}
