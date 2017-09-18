using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Services;

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
                var mockBaseServiceRequest = A.Fake<BaseServiceRequest<FakeEntity, int>>();

                mockBaseServiceRequest.Should().NotBeNull();
                mockBaseServiceRequest.Should().BeAssignableTo<IServiceRequest<FakeEntity, int>>();
                mockBaseServiceRequest.Should().BeAssignableTo<BaseServiceRequest<FakeEntity, int>>();
            }

            #region Mocks

            public class FakeEntity : VideoGameEntity { }

            #endregion Mocks
        }
    }
}
