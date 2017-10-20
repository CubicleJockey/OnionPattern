using System;
using AutoMapper;
using OnionPattern.Domain.DataTransferObjects.Platform;
using OnionPattern.Domain.DataTransferObjects.Platform.Input;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Platform;
using Serilog;

namespace OnionPattern.Service.Requests.Platform
{
    public class CreatePlatformRequest : BaseServiceRequest<Domain.Entities.Platform>, ICreatePlatformRequest
    {
        public CreatePlatformRequest(IRepository<Domain.Entities.Platform> repository, IRepositoryAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate) { }

        #region Implementation of ICreatePlatformRequest

        public PlatformResponseDto Execute(CreatePlatformInputDto input)
        {
            var platformResponse = new PlatformResponseDto();
            try
            {
                Log.Information("Creating Platform [{Name}]...", input.Name);
                var platformToCreate = Mapper.Map<CreatePlatformInputDto, Domain.Entities.Platform>(input);
                var createdPlatform = Repository.Create(platformToCreate);

                platformResponse = Mapper.Map(createdPlatform, platformResponse);
                platformResponse.StatusCode = 200;

                Log.Information("Created Platform [{Name}]", createdPlatform.Name);
            }
            catch (Exception x)
            {
                Log.Error(x, "Failed to create Platform [{Name}]", input.Name);
                HandleErrors(platformResponse, x);
            }
            return platformResponse;
        }

        #endregion
    }
}
