using System;
using OnionPattern.Domain.DataTransferObjects.Platform;
using OnionPattern.Domain.DataTransferObjects.Platform.Input;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Platform;

namespace OnionPattern.Service.Requests.Platform
{
    public class UpdatePlatformNameRequest : BaseServiceRequest<Domain.Entities.Platform>, IUpdatePlatformNameRequest
    {
        public UpdatePlatformNameRequest(IRepository<Domain.Entities.Platform> repository, IRepositoryAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate) { }

        #region Implementation of IUpdatePlatformNameRequest

        public PlatformResponseDto Execute(UpdatePlatformNameInputDto input)
        {
            CheckInputValidity(input);
            var platformResponse = new PlatformResponseDto();
            try
            {

            }
            catch (Exception x)
            {
                HandleErrors(platformResponse, x);
            }
            return platformResponse;
        }

        #endregion

        private void CheckInputValidity(UpdatePlatformNameInputDto input)
        {
            if (input == null) { throw new ArgumentNullException($"{nameof(input)} cannot be null."); }
            if (input.Id <= 0) { throw new ArgumentException($"Input {nameof(input.Id)} must be 1 or greater."); }
            if(string.IsNullOrWhiteSpace(input.Name)) { throw new ArgumentException($"Input {nameof(input.Name)} cannot be empty."); }
        }
    }
}
