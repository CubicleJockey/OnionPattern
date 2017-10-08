using OnionPattern.Domain.DataTransferObjects.Platform;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Platform;

namespace OnionPattern.Service.Requests.Platform
{
    public class GetAllPlatformsRequest : BaseServiceRequest<Domain.Entities.Platform>, IGetAllPlatformsRequest
    {
        public GetAllPlatformsRequest(IRepository<Domain.Entities.Platform> repository, IRepositoryAggregate repositoryAggregate) : base(repository, repositoryAggregate) {}

        #region Implementation of IGetAllPlatformsRequest

        public PlatformListResponseDto Execute()
        {
            var platforms = Repository.GetAll();
            return new PlatformListResponseDto
            {
                Platforms = platforms
            };
        }

        #endregion
    }
}
