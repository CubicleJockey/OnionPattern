using OnionPattern.Domain.DataTransferObjects.Platform;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Platform;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnionPattern.Service.Requests.Platform
{
    public class GetAllPlatformsRequestAsync : BaseServiceRequestAsync<Domain.Entities.Platform>, IGetAllPlatformsRequestAsync
    {
        public GetAllPlatformsRequestAsync(IRepositoryAsync<Domain.Entities.Platform> repository, IRepositoryAsyncAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate) { }

        #region Implementation of IGetAllPlatformsRequestAsync

        public async Task<IEnumerable<IPlatform>> Execute()
        {
            var platforms = await RepositoryAsync.GetAllAsync();
            return platforms;
        }

        #endregion
    }
}
