using OnionPattern.Domain.Platform.Responses;

namespace OnionPattern.Domain.Services.Requests.Platform
{
    public interface IDeletePlatformByIdRequest
    {
        PlatformResponse Execute(int id);
    }
}