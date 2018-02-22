using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Platform.Responses;
using OnionPattern.Domain.Services.Requests.Platform;
using OnionPattern.Service.Requests.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OnionPattern.Service.Tests.Requests.Platform
{
    public class GetAllPlatformRequestTests
    {

        [TestClass]
        public class ConstructorTests : TestBase<Domain.Platform.Entities.Platform>
        {
            private GetAllPlatformsRequest request;

            [TestInitialize]
            public void TestInitialize()
            {
               InitializeFakes();
                request = new GetAllPlatformsRequest(FakeRepository, FakeRepositoryAggregate);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
            }

            [TestMethod]
            public void InheritsFromIGetAllPlatformsRequests()
            {
                request.Should().BeAssignableTo<IGetAllPlatformsRequest>();
            }

            [TestMethod]
            public void InheritsFromBaseServiceRequest()
            {
                request.Should().BeAssignableTo<BaseServiceRequest<Domain.Platform.Entities.Platform>>();
            }
        }

        [TestClass]
        public class MethodTests : TestBase<Domain.Platform.Entities.Platform>
        {
            private GetAllPlatformsRequest request;
            private Expression<Func<IEnumerable<Domain.Platform.Entities.Platform>>> getAll;

            [TestInitialize]
            public void TestInitalize()
            {
                InitializeFakes();
                getAll = () => FakeRepository.GetAll();
                request = new GetAllPlatformsRequest(FakeRepository, FakeRepositoryAggregate);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
                getAll = null;
            }

            [TestMethod]
            public void Execute()
            {
               var platforms = MockData.Mocks.GeneratePlatforms().ToArray();

                A.CallTo(getAll).Returns(platforms);

                request.Should().NotBeNull();    
                
                var response = request.Execute();
                response.Should().NotBeNull();
                response.Should().BeOfType<PlatformListResponse>();

                response.Platforms.Should().NotBeNullOrEmpty();
                response.ErrorResponse.Should().BeNull();

                response.Platforms.Count().Should().Be(platforms.Length);
                
                A.CallTo(getAll).MustHaveHappened(Repeated.Exactly.Once);
            }

            [TestMethod]
            public void ExecuteErrorThrown()
            {
                var exception = new Exception("Oh noes n' stuff.");

                A.CallTo(getAll).Throws(exception);

                var response = request.Execute();

                response.Should().NotBeNull();
                response.Platforms.Should().BeNull();
                response.ErrorResponse.Should().NotBeNull();
                response.ErrorResponse.ErrorSummary.Should().NotBeNullOrWhiteSpace();
                response.ErrorResponse.ErrorSummary.Should().Be(exception.Message);

                A.CallTo(getAll).MustHaveHappened(Repeated.Exactly.Once);
            }
        }
    }
}
