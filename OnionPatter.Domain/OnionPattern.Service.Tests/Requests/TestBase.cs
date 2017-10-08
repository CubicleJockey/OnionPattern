using FakeItEasy;
using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Repository;

namespace OnionPattern.Service.Tests.Requests
{
    public abstract class TestBase<TEntity> where TEntity : VideoGameEntity
    {
        protected IRepository<TEntity> FakeRepository;
        protected IRepositoryAggregate FakeRepositoryAggregate;

        protected void InitializeFakes()
        {
            FakeRepository = A.Fake<IRepository<TEntity>>();
            FakeRepositoryAggregate = A.Fake<IRepositoryAggregate>();
        }

        protected void ClearFakes()
        {
            Fake.ClearConfiguration(FakeRepository);
            Fake.ClearConfiguration(FakeRepositoryAggregate);
        }
    }
}
