using System;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Api.Controllers;
using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Services;
using OnionPattern.Service.Responses;

namespace OnionPattern.Api.Tests.Controllers
{
    public class PlatformControllerTests
    {

        [TestClass]
        public class ConstructorTests
        {
            private IServiceRequest<Platform, GetAllPlatformsResponse> fakeAllPlatformsRequest;

            [TestInitialize]
            public void TestInitalize()
            {
                fakeAllPlatformsRequest = A.Fake<IServiceRequest<Platform, GetAllPlatformsResponse>>();
            }

            [TestCleanup]
            public void TestCleanup()
            {
                Fake.ClearConfiguration(fakeAllPlatformsRequest);
            }

            [TestMethod]
            public void GetAllGamesRequestIsNull()
            {
                Action ctor = () => new PlatformController(null);

                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: getAllPlatformsRequest cannot be null.");
            }

            [TestMethod]
            public void Inheritence()
            {
                var controller = new PlatformController(fakeAllPlatformsRequest);

                controller.Should().NotBeNull();
                controller.Should().BeAssignableTo<Controller>();
                controller.Should().BeOfType<PlatformController>();
            }
        }
    }
}
