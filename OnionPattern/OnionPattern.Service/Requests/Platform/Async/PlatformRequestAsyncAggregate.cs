using System;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Platform.Async;

namespace OnionPattern.Service.Requests.Platform.Async
{
    public class PlatformRequestAsyncAggregate : BaseRequestAsyncAggregate<Domain.Entities.Platform>, IPlatformRequestAsyncAggregate
    {
        public PlatformRequestAsyncAggregate(IRepositoryAsync<Domain.Entities.Platform> repositoryAsync, IRepositoryAsyncAggregate repositoryAsyncAggregate) 
            : base(repositoryAsync, repositoryAsyncAggregate) { }

        #region Implementation of IPlatformRequestAsyncAggregate

        private IGetAllPlatformsRequestAsync getAllPlatformsRequestAsync;
        public IGetAllPlatformsRequestAsync GetAllPlatformsRequestAsync => getAllPlatformsRequestAsync ?? 
                                                                          (getAllPlatformsRequestAsync = new GetAllPlatformsRequestAsync(RepositoryAsync, RepositoryAsyncAggregate));

        private IGetPlatformByIdRequestAsync getPlatformByIdRequestAsync;
        public IGetPlatformByIdRequestAsync GetPlatformByIdRequestAsync => getPlatformByIdRequestAsync ??
                                                                          (getPlatformByIdRequestAsync = new GetPlatformByIdRequestAsync(RepositoryAsync, RepositoryAsyncAggregate));

        private IUpdatePlatformNameRequestAsync updatePlatformNameRequestAsync;
        public IUpdatePlatformNameRequestAsync UpdatePlatformNameRequestAsync => updatePlatformNameRequestAsync ?? 
                                                                                (updatePlatformNameRequestAsync = new UpdatePlatformNameRequestAsync(RepositoryAsync, RepositoryAsyncAggregate));

        private IDeletePlatformByIdRequestAsync deletePlatformByIdRequestAsync;
        public IDeletePlatformByIdRequestAsync DeletePlatformByIdRequestAsync => throw new NotImplementedException();

        private ICreatePlatformRequestAsync createPlatformRequestAsync;
        public ICreatePlatformRequestAsync CreatePlatformRequestAsync => createPlatformRequestAsync ?? 
                                                                        (createPlatformRequestAsync = new CreatePlatformRequestAsync(RepositoryAsync, RepositoryAsyncAggregate));

        #endregion
    }
}
