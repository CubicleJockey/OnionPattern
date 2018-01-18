using OnionPattern.Domain.Repository;
using OnionPattern.Service.Requests;

namespace OnionPattern.Service.Tests.Requests.Mocks
{
    public class MockBaseRequestAggregate : BaseRequestAggregate<FakeEntity>
    {
        public MockBaseRequestAggregate(IRepository<FakeEntity> repository, IRepositoryAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate) { }
    }
}
