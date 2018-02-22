using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Errors;
using OnionPattern.Domain.Platform.Responses;

namespace OnionPattern.Domain.Tests.Platform.Responses
{
    public class PlatformResponseTests
    {
        [TestClass]
        public class ConstructorTests : TestBase<PlatformResponse>
        {
            [TestMethod]
            public void InheritsFromIError()
            {
                Entity.Should().BeAssignableTo<IError>();
            }
        }
    }
}
