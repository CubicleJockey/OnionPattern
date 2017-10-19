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
                    platformResponse = Mapper.Map<Domain.Entities.Platform, PlatformResponseDto>(platform);
                    platformResponse.StatusCode = 200;
                }
            }
            catch (Exception x)
            {
                HandleErrors(platformResponse, x);
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
