using System.Threading.Tasks;
using OnionPattern.Domain.Repository;
using OnionPattern.Service.Responses;

namespace OnionPattern.Service.Requests.Platform
{
    public class GetAllPlatformsRequest : BaseServiceRequest<Domain.Entities.Platform, GetAllPlatformsResponse>
    {
        public GetAllPlatformsRequest(IRepository<Domain.Entities.Platform> repository, IRepositoryAggregate repositoryAggregate) : base(repository, repositoryAggregate) {}

        public override Task<GetAllPlatformsResponse> Execute()
        {
            var platforms = Repository.GetAll();
            return Task.FromResult(new GetAllPlatformsResponse
            {
                Platforms = platforms
            });
        }
    }
}
