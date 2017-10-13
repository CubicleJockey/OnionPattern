using OnionPattern.Domain.Repository;
using Serilog;

namespace OnionPattern.Service.Tests.Requests
{
    public class MockBaseRequest : BaseServiceRequest<FakeEntity>
    {
        public MockBaseRequest(IRepository<FakeEntity> repository, IRepositoryAggregate repositoryAggregate, ILogger logger) 
            : base(repository, repositoryAggregate, logger) { }
    }
}
