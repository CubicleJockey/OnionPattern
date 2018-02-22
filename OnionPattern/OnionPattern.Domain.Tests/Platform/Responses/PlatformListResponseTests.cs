using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Errors;
using OnionPattern.Domain.Platform.Responses;
using OnionPattern.Domain.Responses;

namespace OnionPattern.Domain.Tests.Platform.Responses
{
    public class PlatformListResponseTests
    {
        [TestClass]
        public class ConstructorTests : TestBase<PlatformListResponse>
        {
            [TestMethod]
            public void InheritsFromIError()
            {
                Entity.Should().BeAssignableTo<IError>();
            }

            [TestMethod]
            public void InheritsFromIListResponse()
            {
                Entity.Should().BeAssignableTo<IListResponse>();
            }
        }
    }
}
