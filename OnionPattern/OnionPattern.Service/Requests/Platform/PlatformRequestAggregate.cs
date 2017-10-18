using System;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Platform;

namespace OnionPattern.Service.Requests.Platform
{
    public class PlatformRequestAggregate : BaseRequestAggregate<Domain.Entities.Platform>, IPlatformRequestAggregate
    {

        public PlatformRequestAggregate(IRepository<Domain.Entities.Platform> repository, IRepositoryAggregate repositoryAggregate)
            : base(repository, repositoryAggregate) { }

        #region Implementation of IPlatformRequestAggregate

        private IGetAllPlatformsRequest getAllPlatformsRequest;
        public IGetAllPlatformsRequest GetAllPlatformsRequest => getAllPlatformsRequest ?? (getAllPlatformsRequest = new GetAllPlatformsRequest(Repository, RepositoryAggregate));

        private IGetPlatformByIdRequest getPlatformByIdRequest;
        public IGetPlatformByIdRequest GetPlatformByIdRequest => getPlatformByIdRequest ?? (getPlatformByIdRequest = new GetPlatformByIdRequest(Repository, RepositoryAggregate));

        private IUpdatePlatformNameRequest updatePlatformNameRequest;
        public IUpdatePlatformNameRequest UpdatePlatformNameRequest => throw new NotImplementedException();

        private IDeletePlatformByIdRequest deletePlatformByIdRequest;
        public IDeletePlatformByIdRequest DeletePlatformByIdRequest => throw new NotImplementedException();

        private ICreatePlatformRequest createPlatformRequest;
        public ICreatePlatformRequest CreatePlatformRequest => throw new NotImplementedException();
    }

    #endregion
}

