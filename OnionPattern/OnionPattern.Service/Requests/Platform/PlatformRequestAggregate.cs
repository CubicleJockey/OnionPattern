using System;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Platform;

namespace OnionPattern.Service.Requests.Platform
{
    public class PlatformRequestAggregate : BaseRequestAggregate<Domain.Platform.Entities.Platform>, IPlatformRequestAggregate
    {
        /// <inheritdoc />
        /// <exception cref="T:System.ArgumentNullException">Condition.</exception>
        public PlatformRequestAggregate(IRepository<Domain.Platform.Entities.Platform> repository, IRepositoryAggregate repositoryAggregate)
            : base(repository, repositoryAggregate) { }

        #region Implementation of IPlatformRequestAggregate

        private IGetAllPlatformsRequest getAllPlatformsRequest;
        public IGetAllPlatformsRequest GetAllPlatformsRequest => getAllPlatformsRequest ?? (getAllPlatformsRequest = new GetAllPlatformsRequest(Repository, RepositoryAggregate));

        private IGetPlatformByIdRequest getPlatformByIdRequest;
        public IGetPlatformByIdRequest GetPlatformByIdRequest => getPlatformByIdRequest ?? (getPlatformByIdRequest = new GetPlatformByIdRequest(Repository, RepositoryAggregate));

        private IUpdatePlatformNameRequest updatePlatformNameRequest;
        public IUpdatePlatformNameRequest UpdatePlatformNameRequest => updatePlatformNameRequest ?? (updatePlatformNameRequest = new UpdatePlatformNameRequest(Repository, RepositoryAggregate));

        private IDeletePlatformByIdRequest deletePlatformByIdRequest;
        public IDeletePlatformByIdRequest DeletePlatformByIdRequest => deletePlatformByIdRequest ?? (deletePlatformByIdRequest = new DeletePlatformByIdRequest(Repository, RepositoryAggregate));

        private ICreatePlatformRequest createPlatformRequest;
        public ICreatePlatformRequest CreatePlatformRequest => createPlatformRequest ?? (createPlatformRequest = new CreatePlatformRequest(Repository, RepositoryAggregate));
    }

    #endregion
}

