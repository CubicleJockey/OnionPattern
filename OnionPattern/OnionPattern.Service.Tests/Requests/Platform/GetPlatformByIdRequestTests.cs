using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Services.Requests.Platform;
using OnionPattern.Service.Requests.Platform;

namespace OnionPattern.Service.Tests.Requests.Platform
{
    public class GetPlatformByIdRequestTests
    {
        [TestClass]
        public class ConstructorTests : TestBase<Domain.Entities.Platform>
        {
            [TestInitialize]
            public void TestInitalize()
            {
                InitializeFakes();
            }

            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
            }

            [TestMethod]
            public void Inheritence()
            {
                var request = new GetPlatformByIdRequest(FakeRepository, FakeRepositoryAggregate);

                request.Should().NotBeNull();
                request.Should().BeAssignableTo<BaseServiceRequest<Domain.Entities.Platform>>();
                request.Should().BeAssignableTo<IGetPlatformByIdRequest>();
                request.Should().BeOfType<GetPlatformByIdRequest>();
            }
        }

        [TestClass]
        public class MethodsTests : TestBase<Domain.Entities.Platform>
        {
            private IGetPlatformByIdRequest request;

            [TestInitialize]
            public void TestInitialize()
            {
                InitializeFakes();
                request = new GetPlatformByIdRequest(FakeRepository, FakeRepositoryAggregate);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
            }

            [DataTestMethod]
            [DataRow(-1)]
            [DataRow(0)]
            public void InputIdIsInvalid(int id)
            {
                Action execute = () => request.Execute(id);

                execute.Should()
                       .Throw<ArgumentException>()
                       .WithMessage($"{nameof(id)} must be 1 or greater.");
            }
        }
    }
}
