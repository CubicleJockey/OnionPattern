using System;
using System.Linq;
using OnionPattern.Domain.DataTransferObjects.Platform;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Platform;
using Serilog;

namespace OnionPattern.Service.Requests.Platform
{
    public class GetAllPlatformsRequest : BaseServiceRequest<Domain.Entities.Platform>, IGetAllPlatformsRequest
    {
        public GetAllPlatformsRequest(IRepository<Domain.Entities.Platform> repository, IRepositoryAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate) {}

        #region Implementation of IGetAllPlatformsRequest

        public PlatformListResponseDto Execute()
        {
            Log.Information("Retrieving Platform List...");
            var platformListResponse = new PlatformListResponseDto();
            try
            {
                var platforms = Repository.GetAll()?.ToArray();
                if (platforms == null || !platforms.Any())
                {
                    var exception = new Exception("No Platforms Returned.");
                    Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                    HandleErrors(platformListResponse, exception, 404);
                }
                else
                {
                    platformListResponse.Platforms = platforms;
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
