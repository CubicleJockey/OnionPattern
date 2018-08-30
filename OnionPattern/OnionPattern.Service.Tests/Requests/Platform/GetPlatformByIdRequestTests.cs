using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Services.Requests.Platform;
using OnionPattern.Service.Requests.Platform;
using System;

namespace OnionPattern.Service.Tests.Requests.Platform
{
    public class GetPlatformByIdRequestTests
    {
        [TestClass]
        public class ConstructorTests : TestBase<Domain.Platform.Entities.Platform>
        {
            private GetPlatformByIdRequest request;

            [TestInitialize]
            public void TestInitalize()
            {
                InitializeFakes();
                request = new GetPlatformByIdRequest(FakeRepository, FakeRepositoryAggregate);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
                request = null;
            }

            [TestMethod]
            public void InheritsFromIGetPlatformByIdRequest()
            {
                request.Should().BeAssignableTo<IGetPlatformByIdRequest>();
            }

            [TestMethod]
            public void InheritsFromBaseServiceRequest()
            {
                request.Should().BeAssignableTo<BaseServiceRequest<Domain.Platform.Entities.Platform>>();
            }
        }

        [TestClass]
        public class MethodsTests : TestBase<Domain.Platform.Entities.Platform>
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
