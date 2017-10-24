using System;
using AutoMapper;
using OnionPattern.Domain.DataTransferObjects.Platform;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Platform;
using Serilog;

namespace OnionPattern.Service.Requests.Platform
{
    public class GetPlatformByIdRequest : BaseServiceRequest<Domain.Entities.Platform>, IGetPlatformByIdRequest
    {
        public GetPlatformByIdRequest(IRepository<Domain.Entities.Platform> repository, IRepositoryAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate) { }

        #region Implementation of IGetPlatformByIdRequest

        public PlatformResponseDto Execute(int id)
        {
            CheckInputValidity(id);
            Log.Information("Retrieving Platform by Id: [{Id}]...", id);
            
            var platformResponse = new PlatformResponseDto();
            try
            {
                var platform = Repository.SingleOrDefault(p => p.Id == id);
                if (platform == null)
                {
                    var exception = new Exception($"Could not find Platform with Id: [{id}].");
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
                Log.Error("Failed to get Platforms List. [{Message}].", exception.Message);
                HandleErrors(platformResponse, exception);
            }
            return platformResponse;
        }

        #endregion

        private void CheckInputValidity(int id)
        {
            if(id <= 0) {  throw new ArgumentException($"{nameof(id)} must be 1 or greater.");}
        }
    }
}
