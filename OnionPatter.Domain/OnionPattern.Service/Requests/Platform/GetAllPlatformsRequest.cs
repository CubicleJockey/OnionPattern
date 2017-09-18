using MediatR;
using OnionPattern.Domain.Repository;
using OnionPattern.Service.Responses;

namespace OnionPattern.Service.Requests.Platform
{
    public class GetAllPlatformsRequest : BaseRequest<Domain.Entities.Platform, GetAllPlatformsResponse>, IRequest<GetAllPlatformsResponse>
    {
        public GetAllPlatformsRequest(IRepository<Domain.Entities.Platform> repository) : base(repository) {}

        public override GetAllPlatformsResponse Execute()
        {
            var platforms = Repository.GetAll();
            return new GetAllPlatformsResponse
            {
                Platforms = platforms
            };
        }
    }
}
