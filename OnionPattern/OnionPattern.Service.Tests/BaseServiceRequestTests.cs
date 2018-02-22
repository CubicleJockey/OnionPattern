using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OnionPattern.Service.Tests
{
    public class BaseServiceRequestTests
    {
        [TestClass]
        public class ConstructorTests
        {
            private readonly BaseServiceRequest<FakeEntity> fakeBaseServiceRequest;

            public ConstructorTests()
            {
                fakeBaseServiceRequest = A.Fake<BaseServiceRequest<FakeEntity>>();
            }

            [TestCleanup]
            public void TestCleanup()
            {
                Fake.ClearConfiguration(fakeBaseServiceRequest);
            }

            [TestMethod]
            public void InheritsFromServiceHandleError()
            {
                fakeBaseServiceRequest.Should().BeAssignableTo<ServiceHandleError>();
            }
        }
    }
}
