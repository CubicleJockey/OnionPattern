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
        public IGetAllPlatformsRequestAsync GetAllPlatformsRequestAsync => getAllPlatformsRequestAsync 
                                                                           ?? (getAllPlatformsRequestAsync = new GetAllPlatformsRequestAsync(RepositoryAsync, RepositoryAsyncAggregate));

        private IGetPlatformByIdRequestAsync getPlatformByIdRequestAsync;
        public IGetPlatformByIdRequestAsync GetPlatformByIdRequestAsync => throw new NotImplementedException();

        private IUpdatePlatformNameRequestAsync updatePlatformNameRequestAsync;
        public IUpdatePlatformNameRequestAsync UpdatePlatformNameRequestAsync => throw new NotImplementedException();

        private IDeletePlatformByIdRequestAsync deletePlatformByIdRequestAsync;
        public IDeletePlatformByIdRequestAsync DeletePlatformByIdRequestAsync => throw new NotImplementedException();

        private ICreatePlatformRequestAsync createPlatformRequestAsync;
        public ICreatePlatformRequestAsync CreatePlatformRequestAsync => throw new NotImplementedException();

        #endregion
    }
}
