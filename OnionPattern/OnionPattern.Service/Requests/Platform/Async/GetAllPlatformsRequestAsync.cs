using System;
using System.Linq;
using System.Threading.Tasks;
using OnionPattern.Domain.DataTransferObjects.Platform;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Platform.Async;
using Serilog;

namespace OnionPattern.Service.Requests.Platform.Async
{
    public class GetAllPlatformsRequestAsync : BaseServiceRequestAsync<Domain.Entities.Platform>, IGetAllPlatformsRequestAsync
    {
        public GetAllPlatformsRequestAsync(IRepositoryAsync<Domain.Entities.Platform> repository, IRepositoryAsyncAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate) { }

        #region Implementation of IGetAllPlatformsRequestAsync

        public async Task<PlatformListResponseDto> Execute()
        {
            Log.Logger.Information("Retrieving Platform List...");
            var platformListResponse = new PlatformListResponseDto();
            try
            {
                var platforms = (await Repository.GetAllAsync())?.ToArray();
                if (platforms == null || !platforms.Any())
                {
                    var exception = new Exception("No Platforms Returned.");
                    Log.Logger.Error(exception.Message);
                    HandleErrors(platformListResponse, exception, 404);
                }
                else
                {
                    platformListResponse.Platforms = platforms;
                    platformListResponse.StatusCode = 200;
                    Log.Logger.Information($"Retrieved [{platformListResponse.Platforms.Count()}] Platforms.");
                }
            }
            catch (Exception x)
            {
                Log.Logger.Error($"Failed to get Platforms List. [{x.Message}].");
                HandleErrors(platformListResponse, x);
            }
            return platformListResponse;
        }

        #endregion
    }
}
