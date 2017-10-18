using AutoMapper;
using OnionPattern.Domain.DataTransferObjects.Platform;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Platform.Async;
using Serilog;
using System;
using System.Threading.Tasks;

namespace OnionPattern.Service.Requests.Platform
{
    public class GetPlatformByIdRequestAsync : BaseServiceRequestAsync<Domain.Entities.Platform>, IGetPlatformByIdRequestAsync
    {
        public GetPlatformByIdRequestAsync(IRepositoryAsync<Domain.Entities.Platform> repository, IRepositoryAsyncAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate) { }

        #region Implementation of IGetPlatformByIdRequestAsync

        public async Task<PlatformResponseDto> ExecuteAsync(int id)
        {
            Log.Information("Retrieving Platform by Id: [{Id}]...", id);
            var platformResponse = new PlatformResponseDto();
            try
            {
                var platform = await Repository.SingleOrDefaultAsync(p => p.Id == id);
                if (platform == null)
                {
                    var exception = new Exception($"Could not find Platform with Id: [{id}].");
                    HandleErrors(platformResponse, exception, 404);
                }
                else
                {
                    platformResponse = Mapper.Map<Domain.Entities.Platform, PlatformResponseDto>(platform);
                    platformResponse.StatusCode = 200;
                    Log.Information("Retrieved [{Name}] for Id: [{Id}].", platformResponse.Name, id);
                }
            }
            catch (Exception x)
            {
                Log.Error("Failed to get Platforms List. [{Message}].", x.Message);
                HandleErrors(platformResponse, x);
            }
            return platformResponse;
        }

        #endregion
    }
}
