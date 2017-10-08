using FakeItEasy;
using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Repository;

namespace OnionPattern.Service.Tests.Requests
{
    public abstract class TestBaseAsync<TEntity> where TEntity : VideoGameEntity
    {
        protected IRepositoryAsync<TEntity> FakeRepositoryAsync;
        protected IRepositoryAsyncAggregate FakeRepositoryAsyncAggregate;

        protected void InitializeFakes()
        {
            FakeRepositoryAsync = A.Fake<IRepositoryAsync<TEntity>>();
            FakeRepositoryAsyncAggregate = A.Fake<IRepositoryAsyncAggregate>();
        }

        protected void ClearFakes()
        {
            Fake.ClearConfiguration(FakeRepositoryAsync);
            Fake.ClearConfiguration(FakeRepositoryAsyncAggregate);
        }
    }
}