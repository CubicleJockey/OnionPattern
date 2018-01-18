using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OnionPattern.Domain.DataTransferObjects.Platform;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Platform.Async;
using Serilog;

namespace OnionPattern.Service.Requests.Platform.Async
{
    public class GetAllPlatformsRequestAsync : BaseServiceRequestAsync<Domain.Entities.Platform>, IGetAllPlatformsRequestAsync
    {
        /// <inheritdoc />
        /// <summary>
        ///     Request a list of all the Platforms asynchronously.
        /// </summary>
        /// <exception cref="T:System.ArgumentNullException">Condition.</exception>
        public GetAllPlatformsRequestAsync(IRepositoryAsync<Domain.Entities.Platform> repository, IRepositoryAsyncAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate) { }

        #region Implementation of IGetAllPlatformsRequestAsync

        /// <summary>
        /// Execute Request ashynchronouly.
        /// </summary>
        /// <returns></returns>
        public async Task<PlatformListResponseDto> ExecuteAsync()
        {
            Log.Information("Retrieving Platform List...");
            var platformListResponse = new PlatformListResponseDto();
            try
            {
                var platforms = (await Repository.GetAllAsync())?.ToArray();
                if (platforms == null || !platforms.Any())
                {
                    var exception = new Exception("No Platforms Returned.");
                    Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                    HandleErrors(platformListResponse, exception, 404);
                }
                else
                {
                    platformListResponse.Platforms = platforms.Select(Mapper.Map<Domain.Entities.Platform, PlatformResponseDto>);
                    platformListResponse.StatusCode = 200;

                    var count = platforms.Length;
                    Log.Information("Retrieved [{Count}] Platforms.", count);
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Failed to get Platforms List.");
                HandleErrors(platformListResponse, exception);
            }
            return platformListResponse;
        }

        #endregion
    }
}
