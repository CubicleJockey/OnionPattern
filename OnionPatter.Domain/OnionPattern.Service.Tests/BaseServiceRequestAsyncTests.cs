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
            [TestMethod]
            public void Inheritence()
            {
                var mockBaseServiceRequest = A.Fake<BaseServiceRequestAsync<FakeEntity>>();

                mockBaseServiceRequest.Should().NotBeNull();
                mockBaseServiceRequest.Should().BeAssignableTo<BaseServiceRequestAsync<FakeEntity>>();
            }
        }
    }
}
