using OnionPattern.Domain.Repository;
using Serilog;

namespace OnionPattern.Service.Tests.Requests.Mocks
{
    public class MockBaseRequest : BaseServiceRequest<FakeEntity>
    {
        public MockBaseRequest(IRepository<FakeEntity> repository, IRepositoryAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate) { }
    }
}
