using OnionPattern.Domain.Repository;

namespace OnionPattern.Service.Tests.Requests
{
    public class MockBaseRequest : BaseServiceRequest<FakeEntity>
    {
        public MockBaseRequest(IRepository<FakeEntity> repository, IRepositoryAggregate repositoryAggregate) : base(repository, repositoryAggregate) { }
    }
}
