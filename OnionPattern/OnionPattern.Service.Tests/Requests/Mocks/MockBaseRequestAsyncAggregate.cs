using OnionPattern.Domain.Repository;
using OnionPattern.Service.Requests;

namespace OnionPattern.Service.Tests.Requests.Mocks
{
    public class MockBaseRequestAsyncAggregate : BaseRequestAsyncAggregate<FakeEntity>
    {
        public MockBaseRequestAsyncAggregate(IRepositoryAsync<FakeEntity> repositoryAsync, IRepositoryAsyncAggregate repositoryAsyncAggregate) 
            : base(repositoryAsync, repositoryAsyncAggregate) { }
    }
}
