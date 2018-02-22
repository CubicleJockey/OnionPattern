using OnionPattern.Domain.Platform.Responses;

namespace OnionPattern.Domain.Services.Requests.Platform
{
    public interface IGetPlatformByIdRequest
    {
        PlatformResponse Execute(int id);
    }
}