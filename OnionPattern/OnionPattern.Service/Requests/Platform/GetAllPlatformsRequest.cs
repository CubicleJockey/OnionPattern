using System;
using System.Linq;
using OnionPattern.Domain.Platform.Responses;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Platform;
using Serilog;

namespace OnionPattern.Service.Requests.Platform
{
    public class GetAllPlatformsRequest : BaseServiceRequest<Domain.Platform.Entities.Platform>, IGetAllPlatformsRequest
    {
        /// <inheritdoc />
        /// <summary>
        ///     Request to retrieve a list of all of the Platforms.
        /// </summary>
        /// <exception cref="T:System.ArgumentNullException">Condition.</exception>
        public GetAllPlatformsRequest(IRepository<Domain.Platform.Entities.Platform> repository, IRepositoryAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate) {}

        #region Implementation of IGetAllPlatformsRequest

        /// <summary>
        /// Execute the request.
        /// </summary>
        /// <returns></returns>
        public PlatformListResponse Execute()
        {
            Log.Information("Retrieving Platform List...");
            var platformListResponse = new PlatformListResponse();
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
