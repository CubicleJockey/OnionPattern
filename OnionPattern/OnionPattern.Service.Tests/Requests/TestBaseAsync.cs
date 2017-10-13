using FakeItEasy;
using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Repository;
using Serilog;

namespace OnionPattern.Service.Tests.Requests
{
    public abstract class TestBaseAsync<TEntity> where TEntity : VideoGameEntity
    {
        protected IRepositoryAsync<TEntity> FakeRepositoryAsync;
        protected IRepositoryAsyncAggregate FakeRepositoryAsyncAggregate;
        protected ILogger FakeLogger;

        protected void InitializeFakes()
        {
            FakeRepositoryAsync = A.Fake<IRepositoryAsync<TEntity>>();
            FakeRepositoryAsyncAggregate = A.Fake<IRepositoryAsyncAggregate>();
            FakeLogger = A.Fake<ILogger>();
        }

        protected void ClearFakes()
        {
            Fake.ClearConfiguration(FakeRepositoryAsync);
            Fake.ClearConfiguration(FakeRepositoryAsyncAggregate);
            Fake.ClearConfiguration(FakeLogger);
        }
    }
}