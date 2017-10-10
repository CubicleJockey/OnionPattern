using OnionPattern.Domain.DataTransferObjects.Platform;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Platform;
using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OnionPattern.Service.Requests.Platform
{
    public class GetAllPlatformsRequestAsync : BaseServiceRequestAsync<Domain.Entities.Platform>, IGetAllPlatformsRequestAsync
    {
        public GetAllPlatformsRequestAsync(IRepositoryAsync<Domain.Entities.Platform> repository, IRepositoryAsyncAggregate repositoryAggregate, ILogger logger) 
            : base(repository, repositoryAggregate, logger) { }

        #region Implementation of IGetAllPlatformsRequestAsync

        public async Task<PlatformListResponseDto> Execute()
        {
            Logger.Information("Retrieving Platform List...");
            var platformListResponse = new PlatformListResponseDto();
            try
            {
                var platforms = (await Repository.GetAllAsync())?.ToArray();
                if (platforms == null || !platforms.Any())
                {
                    var exception = new Exception("No Platforms Returned.");
                    HandleErrors(platformListResponse, exception, 404);
                }
                else
                {
                    platformListResponse.Platforms = platforms;
                    platformListResponse.StatusCode = 200;
                    Logger.Information($"Retrieved [{platformListResponse.Platforms.Count()}] Platforms.");
                }
            }
            catch (Exception x)
            {
                Logger.Error($"Failed to get Platforms List. [{x.Message}].");
                HandleErrors(platformListResponse, x);
            }
            return platformListResponse;
        }

        #endregion
    }
}
