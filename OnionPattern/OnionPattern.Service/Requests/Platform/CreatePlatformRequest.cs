using System;
using AutoMapper;
using OnionPattern.Domain.Platform.Requests;
using OnionPattern.Domain.Platform.Responses;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Platform;
using Serilog;

namespace OnionPattern.Service.Requests.Platform
{
    public class CreatePlatformRequest : BaseServiceRequest<Domain.Platform.Entities.Platform>, ICreatePlatformRequest
    {
        /// <inheritdoc />
        /// <summary>
        ///     Request to create a Platform
        /// </summary>
        /// <exception cref="T:System.ArgumentNullException">Condition.</exception>
        public CreatePlatformRequest(IRepository<Domain.Platform.Entities.Platform> repository, IRepositoryAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate) { }

        #region Implementation of ICreatePlatformRequest

        /// <summary>
        /// Execute the Request based on the input propreties.
        /// </summary>
        /// <param name="input">Input properties required to create a Platform.</param>
        /// <returns></returns>
        public PlatformResponse Execute(CreatePlatformInput input)
        {
            var platformResponse = new PlatformResponse();
            try
            {
                Log.Information("Creating Platform [{Name}]...", input?.Name);
                var platformToCreate = Mapper.Map<CreatePlatformInput, Domain.Platform.Entities.Platform>(input);
                var createdPlatform = Repository.Create(platformToCreate);

                platformResponse.Platform = createdPlatform;
                platformResponse.StatusCode = 200;

                Log.Information("Created Platform [{Name}]", createdPlatform.Name);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Failed to create Platform [{Name}]", input?.Name);
                HandleErrors(platformResponse, exception);
            }
            return platformResponse;
        }

        #endregion
    }
}
