using OnionPattern.Domain.Repository;

namespace OnionPattern.Service.Tests.Requests.Mocks
{
    public class MockBaseRequestAsync : BaseServiceRequestAsync<FakeEntity>
    {
        public MockBaseRequestAsync(IRepositoryAsync<FakeEntity> repositoryAsync, IRepositoryAsyncAggregate repositoryAsyncAggregate)
            : base(repositoryAsync, repositoryAsyncAggregate) { }
    }
}
