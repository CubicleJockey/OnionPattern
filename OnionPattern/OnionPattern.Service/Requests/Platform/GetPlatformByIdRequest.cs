using System;
using AutoMapper;
using OnionPattern.Domain.Platform.Responses;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Platform;
using Serilog;

namespace OnionPattern.Service.Requests.Platform
{
    public class GetPlatformByIdRequest : BaseServiceRequest<Domain.Platform.Entities.Platform>, IGetPlatformByIdRequest
    {
        /// <inheritdoc />
        /// <summary>
        ///     Request to get a Platform by it's Id.
        /// </summary>
        /// <exception cref="T:System.ArgumentNullException">Condition.</exception>
        public GetPlatformByIdRequest(IRepository<Domain.Platform.Entities.Platform> repository, IRepositoryAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate) { }

        #region Implementation of IGetPlatformByIdRequest

        /// <summary>
        /// Execute the request
        /// </summary>
        /// <param name="id">Id of the Platform to retreive.</param>
        /// <returns></returns>
        public PlatformResponse Execute(int id)
        {
            CheckInputValidity(id);
            Log.Information("Retrieving Platform by Id: [{Id}]...", id);
            
            var platformResponse = new PlatformResponse();
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
                    Log.Information("Retrieved [{NewName}] for Id: [{Id}].", platformResponse.Platform.Name, id);
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
