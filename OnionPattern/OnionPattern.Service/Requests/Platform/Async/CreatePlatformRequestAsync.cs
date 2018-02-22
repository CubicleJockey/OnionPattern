using System;
using System.Threading.Tasks;
using AutoMapper;
using OnionPattern.Domain.Platform.Requests;
using OnionPattern.Domain.Platform.Responses;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Platform.Async;
using Serilog;

namespace OnionPattern.Service.Requests.Platform.Async
{
    public class CreatePlatformRequestAsync : BaseServiceRequestAsync<Domain.Platform.Entities.Platform>, ICreatePlatformRequestAsync
    {
        /// <inheritdoc />
        /// <summary>
        ///     Request to create a Platform asynchronously.
        /// </summary>
        /// <exception cref="T:System.ArgumentNullException">Condition.</exception>
        public CreatePlatformRequestAsync(IRepositoryAsync<Domain.Platform.Entities.Platform> repository, IRepositoryAsyncAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate) { }

        #region Implementation of ICreatePlatformRequestAsync

        /// <summary>
        /// Executes the request asynchronously based on input properties..
        /// </summary>
        /// <param name="input">Required input properties to create a Platform.</param>
        /// <returns></returns>
        public async Task<PlatformResponse> ExecuteAsync(CreatePlatformInput input)
        {
            var platformResponse = new PlatformResponse();
            try
            {
                Log.Information("Creating Platform [{Name}]...", input?.Name);
                var platformToCreate = Mapper.Map<CreatePlatformInput, Domain.Platform.Entities.Platform>(input);
                var createdPlatform = await Repository.CreateAsync(platformToCreate);
                if (createdPlatform == null)
                {
                    var exception = new Exception($"Failed to create Platform [{platformToCreate.Name}].");
                    Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                    HandleErrors(platformResponse, exception);
                }
                else
                {
                    platformResponse = Mapper.Map(createdPlatform, platformResponse);
                    platformResponse.StatusCode = 200;

                    Log.Information("Created Platform [{Name}]", platformResponse.Platform.Name);
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Failed to create Platform [{Name}].", input?.Name);
                HandleErrors(platformResponse, exception);
            }
            return platformResponse;
        }

        #endregion
    }
}
