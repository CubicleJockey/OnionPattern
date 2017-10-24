using System;
using AutoMapper;
using OnionPattern.Domain.DataTransferObjects.Platform;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Platform;
using Serilog;

namespace OnionPattern.Service.Requests.Platform
{
    public class DeletePlatformByIdRequest : BaseServiceRequest<Domain.Entities.Platform>, IDeletePlatformByIdRequest
    {
        public DeletePlatformByIdRequest(IRepository<Domain.Entities.Platform> repository, IRepositoryAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate) { }

        #region Implementation of IDeletePlatformByIdRequest

        public PlatformResponseDto Execute(int id)
        {
            var platformResponse = new PlatformResponseDto();
            try
            {
                Log.Information("Deleting Platform with Id: [{Id}]", id);
                CheckInputValidity(id);
                
                var platform = Repository.SingleOrDefault(p => p.Id == id);
                if (platform == null)
                {
                    var exception = new Exception($"Platform not found for Id: [{id}]");
                    Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                    HandleErrors(platformResponse, exception, 404);
                }
                else
                {
                    platformResponse = Mapper.Map(platform, platformResponse);
                    platformResponse.StatusCode = 200;

                    Log.Information("Retrieved Platform [{NewName}] for Id: [{Id}].", platform.Name, platform.Id);
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Failed to get Platform with Id: [{Id}]", id);
                HandleErrors(platformResponse, exception);
            }
            return platformResponse;
        }

        #endregion

        private void CheckInputValidity(int id)
        {
            if(id <= 0) { throw new ArgumentException($"{nameof(id)} must be 1 or greater."); }
        }
    }
}
