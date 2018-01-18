namespace OnionPattern.Domain.Services.Requests.Platform
{
    public interface IPlatformRequestAggregate
    {
        IGetAllPlatformsRequest GetAllPlatformsRequest { get; }
        IGetPlatformByIdRequest GetPlatformByIdRequest { get; }
        IUpdatePlatformNameRequest UpdatePlatformNameRequest { get; }
        IDeletePlatformByIdRequest DeletePlatformByIdRequest { get; }
        ICreatePlatformRequest CreatePlatformRequest { get; }
    }
}