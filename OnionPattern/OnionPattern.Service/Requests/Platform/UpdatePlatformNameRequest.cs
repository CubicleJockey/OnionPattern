using System;
using AutoMapper;
using OnionPattern.Domain.Platform.Requests;
using OnionPattern.Domain.Platform.Responses;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Platform;
using Serilog;

namespace OnionPattern.Service.Requests.Platform
{
    public class UpdatePlatformNameRequest : BaseServiceRequest<Domain.Platform.Entities.Platform>, IUpdatePlatformNameRequest
    {
        /// <inheritdoc />
        /// <summary>
        ///     Request to update a Platforms Name
        /// </summary>
        /// <exception cref="T:System.ArgumentNullException">Condition.</exception>
        public UpdatePlatformNameRequest(IRepository<Domain.Platform.Entities.Platform> repository, IRepositoryAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate) { }

        #region Implementation of IUpdatePlatformNameRequest

        /// <summary>
        /// Execute the request based on the input properties.
        /// </summary>
        /// <param name="input">Inputs required to update a Platform.</param>
        /// <returns></returns>
        public PlatformResponse Execute(UpdatePlatformNameInput input)
        {
            
            var platformResponse = new PlatformResponse();
            try
            {
                CheckInputValidity(input);
                Log.Information("Updating name Platform with Id: [{Id}] to [{NewName}]...", input.Id, input.NewName);
                var platformToUpdate = Repository.SingleOrDefault(p => p.Id == input.Id);
                if (platformToUpdate == null)
                {
                    var exception = new Exception($"Failed to find platform with Id: [{input.Id}].");
                    Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                    HandleErrors(platformResponse, exception, 404);
                }
                else
                {
                    var previousName = platformToUpdate.Name;
                    platformToUpdate.Name = input.NewName;
                    var updatedPlatform = Repository.Update(platformToUpdate);

                    platformResponse = Mapper.Map(updatedPlatform, platformResponse);
                    platformResponse.StatusCode = 200;

                    Log.Information("Updated Platform from [{PreviousName}] to [{NewName}].", previousName, input.NewName);
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Failed to update Platform.");
                HandleErrors(platformResponse, exception);
            }
            return platformResponse;
        }

        #endregion

        private void CheckInputValidity(UpdatePlatformNameInput input)
        {
            if (input == null) { throw new ArgumentNullException(nameof(input)); }
            if (input.Id <= 0) { throw new ArgumentException($"Input {nameof(input.Id)} must be 1 or greater."); }
            if(string.IsNullOrWhiteSpace(input.NewName)) { throw new ArgumentException($"Input {nameof(input.NewName)} cannot be empty."); }
        }
    }
}
