using System;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.DataTransferObjects.Platform.Input;
using OnionPattern.Domain.Services.Requests.Platform;
using OnionPattern.Domain.Services.Requests.Platform.Async;
using OnionPattern.Service.Requests.Platform;
using OnionPattern.Service.Requests.Platform.Async;

namespace OnionPattern.Service.Tests.Requests.Platform.Async
{
    public class UpdatePlatformNameRequestAsyncTests
    {
        [TestClass]
        public class ConstructorTests : TestBaseAsync<Domain.Entities.Platform>
        {
            [TestInitialize]
            public void TestInitialize()
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
                var request = new UpdatePlatformNameRequestAsync(FakeRepositoryAsync, FakeRepositoryAsyncAggregate);

                request.Should().NotBeNull();
                request.Should().BeAssignableTo<BaseServiceRequestAsync<Domain.Entities.Platform>>();
                request.Should().BeAssignableTo<IUpdatePlatformNameRequestAsync>();
                request.Should().BeOfType<UpdatePlatformNameRequestAsync>();
            }
        }

        [TestClass]
        public class MethodsTests : TestBaseAsync<Domain.Entities.Platform>
        {
            private IUpdatePlatformNameRequestAsync request;

            [TestInitialize]
            public void TestInitialize()
            {
                InitializeFakes();
                request = new UpdatePlatformNameRequestAsync(FakeRepositoryAsync, FakeRepositoryAsyncAggregate);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
            }

            [TestMethod]
            public async Task InputIsNull()
            {
                var response = await request.ExecuteAsync(null);

                response.Should().NotBeNull();
                response.ErrorSummary.Should().NotBeNullOrWhiteSpace();
                response.ErrorSummary.Should().BeEquivalentTo($"Value cannot be null.{Environment.NewLine}Parameter name: input");
                response.StatusCode.HasValue.Should().BeTrue();
                response.StatusCode.Should().Be(500);
            }

            [DataTestMethod]
            [DataRow(-1)]
            [DataRow(0)]
            public async Task InvalidInputIdNotValid(int Id)
            {
                var invalidInput = new UpdatePlatformNameInputDto { Id = Id, NewName = "Something" };
                var response = await request.ExecuteAsync(invalidInput);

                response.Should().NotBeNull();
                response.ErrorSummary.Should().NotBeNullOrWhiteSpace();
                response.ErrorSummary.Should().BeEquivalentTo($"Input {nameof(Id)} must be 1 or greater.");
                response.StatusCode.HasValue.Should().BeTrue();
                response.StatusCode.Should().Be(500);
            }

            [DataTestMethod]
            [DataRow(default(string))]
            [DataRow("")]
            [DataRow("      ")]
            public async Task InvalidInputNameIsEmpty(string name)
            {
                var invalidInput = new UpdatePlatformNameInputDto { Id = 666, NewName = name };
                var response = await request.ExecuteAsync(invalidInput);

                response.Should().NotBeNull();
                response.ErrorSummary.Should().NotBeNullOrWhiteSpace();
                response.ErrorSummary.Should().BeEquivalentTo("Input NewName cannot be empty.");
                response.StatusCode.HasValue.Should().BeTrue();
                response.StatusCode.Should().Be(500);
            }
        }
    }
}
