using OnionPattern.Domain.Repository;

namespace OnionPattern.Service.Requests.Platform
{
    public class DeletePlatformByIdRequest : BaseServiceRequest<Domain.Entities.Platform>
    {
        public DeletePlatformByIdRequest(IRepository<Domain.Entities.Platform> repository, IRepositoryAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate) { }
    }
}
