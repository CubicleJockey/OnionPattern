namespace OnionPattern.Domain.Services.Requests.Platform.Async
{
    public interface IPlatformRequestAsyncAggregate
    {
        IGetAllPlatformsRequestAsync GetAllPlatformsRequestAsync { get; }
        IGetPlatformByIdRequestAsync GetPlatformByIdRequestAsync { get; }
        IUpdatePlatformNameRequestAsync UpdatePlatformNameRequestAsync { get; }
        IDeletePlatformByIdRequestAsync DeletePlatformByIdRequestAsync { get; }
        ICreatePlatformRequestAsync CreatePlatformRequestAsync { get; }
    }
}