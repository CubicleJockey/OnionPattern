using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Services.Requests.Platform.Async;
using OnionPattern.Service.Requests;
using OnionPattern.Service.Tests.Requests.Mocks;

namespace OnionPattern.Service.Tests.Requests
{
    public class BaseRequestAsyncAggregateTests
    {
        [TestClass]
        public class ConstructorTests : TestBaseAsync<FakeEntity>
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
            public void RepositoryAsyncIsNull()
            {
                Action ctor = () => new MockBaseRequestAsyncAggregate(null, FakeRepositoryAsyncAggregate);

                ctor.Should()
                    .Throw<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: repositoryAsync cannot be null.");
            }

            [TestMethod]
            public void RepositoryAsyncAggregateIsNull()
            {
                Action ctor = () => new MockBaseRequestAsyncAggregate(FakeRepositoryAsync, null);

                ctor.Should()
                    .Throw<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: repositoryAsyncAggregate cannot be null.");
            }

            [TestMethod]
            public void Inheritence()
            {
                var baseRequestAsync = new MockBaseRequestAsyncAggregate(FakeRepositoryAsync, FakeRepositoryAsyncAggregate);

                baseRequestAsync.Should().NotBeNull();
                baseRequestAsync.Should().BeAssignableTo<BaseRequestAsyncAggregate<FakeEntity>>();
                baseRequestAsync.Should().BeOfType<MockBaseRequestAsyncAggregate>();
            }
        }
    }
}
