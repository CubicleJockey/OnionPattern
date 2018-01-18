using System;
using System.Threading.Tasks;
using AutoMapper;
using OnionPattern.Domain.DataTransferObjects.Platform;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Platform.Async;
using Serilog;

namespace OnionPattern.Service.Requests.Platform.Async
{
    public class GetPlatformByIdRequestAsync : BaseServiceRequestAsync<Domain.Entities.Platform>, IGetPlatformByIdRequestAsync
    {
        /// <inheritdoc />
        /// <summary>
        ///     Request to get a Platform by it's Id asynchronously.
        /// </summary>
        /// <exception cref="T:System.ArgumentNullException">Condition.</exception>
        public GetPlatformByIdRequestAsync(IRepositoryAsync<Domain.Entities.Platform> repository, IRepositoryAsyncAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate) { }

        #region Implementation of IGetPlatformByIdRequestAsync

        /// <summary>
        /// Executes the request asynchronously.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<PlatformResponseDto> ExecuteAsync(int id)
        {
            Log.Information("Retrieving Platform by Id: [{Id}]...", id);

            CheckInputValidity(id);

            var platformResponse = new PlatformResponseDto();
            try
            {
                var platform = await Repository.SingleOrDefaultAsync(p => p.Id == id);
                if (platform == null)
                {
                    var exception = new Exception($"Could not find Platform with Id: [{id}].");
                    Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                    HandleErrors(platformResponse, exception, 404);
                }
                else
                {
                    platformResponse = Mapper.Map(platform, platformResponse);
                    platformResponse.StatusCode = 200;
                    Log.Information("Retrieved [{NewName}] for Id: [{Id}].", platformResponse.Name, id);
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Failed to get Platform with Id: [{Id}].", id);
                HandleErrors(platformResponse, exception);
            }
            return platformResponse;
        }

        #endregion

        private void CheckInputValidity(int id)
        {
            if (id <= 0) { throw new ArgumentException($"{nameof(id)} must be 1 or greater."); }
        }
    }
}
