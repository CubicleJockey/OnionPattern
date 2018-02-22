using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Errors;
using OnionPattern.Domain.Game.Responses;
using OnionPattern.Domain.Responses;

namespace OnionPattern.Domain.Tests.Game.Responses
{
    public class GameListResponseTests
    {
        [TestClass]
        public class ConstructorTests : TestBase<GameListResponse>
        {
            [TestMethod]
            public void InheritsFromIError()
            {
                Entity.Should().BeAssignableTo<IError>();
            }

            [TestMethod]
            public void InheritsFromIListResponse()
            {
                Entity.Should().NotBeAssignableTo<IListResponse>();
            }
        }
    }
}
