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
            [TestMethod]
            public void Inheritence()
            {
                var mockBaseServiceRequest = A.Fake<BaseServiceRequest<FakeEntity>>();

                mockBaseServiceRequest.Should().NotBeNull();
                mockBaseServiceRequest.Should().BeAssignableTo<BaseServiceRequest<FakeEntity>>();
            }
        }
    }
}
