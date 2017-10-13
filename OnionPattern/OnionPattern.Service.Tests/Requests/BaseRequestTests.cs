using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Repository;
using System;
using Serilog;

namespace OnionPattern.Service.Tests.Requests
{
    public class BaseRequestTests
    {
        [TestClass]
        public class ConstructorTests
        {
            private IRepository<FakeEntity> fakeRepository;
            private IRepositoryAggregate fakeRepositoryAggregate;
            private ILogger fakeLogger;

            [TestInitialize]
            public void TestInitialize()
            {
                fakeRepository = A.Fake<IRepository<FakeEntity>>();
                fakeRepositoryAggregate = A.Fake<IRepositoryAggregate>();
                fakeLogger = A.Fake<ILogger>();
            }

            [TestCleanup]
            public void TestCleanup()
            {
                Fake.ClearConfiguration(fakeRepository);
                Fake.ClearConfiguration(fakeRepositoryAggregate);
                Fake.ClearConfiguration(fakeLogger);
            }

            [TestMethod]
            public void RepositoryIsNull()
            {
                Action ctor = () => new MockBaseRequest(null, fakeRepositoryAggregate, fakeLogger);
                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: repository cannot be null.");
            }

            [TestMethod]
            public void RepositoryAggregateIsNull()
            {
                Action ctor = () => new MockBaseRequest(fakeRepository, null, fakeLogger);
                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: repositoryAggregate cannot be null.");
            }

            [TestMethod]
            public void LoggerIsNull()
            {
                Action ctor = () => new MockBaseRequest(fakeRepository, fakeRepositoryAggregate, null);
                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: logger cannot be null.");
            }

            [TestMethod]
            public void IsValid()
            {
                var baseRequest = new MockBaseRequest(fakeRepository, fakeRepositoryAggregate, fakeLogger);

                baseRequest.Should().NotBeNull();
                baseRequest.Should().BeAssignableTo<BaseServiceRequest<FakeEntity>>();
                baseRequest.Should().BeOfType<MockBaseRequest>();
            }
        }
    }
}
