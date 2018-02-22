using OnionPattern.Domain.Platform.Requests;
using OnionPattern.Domain.Platform.Responses;

namespace OnionPattern.Domain.Services.Requests.Platform
{
    public interface ICreatePlatformRequest
    {
        PlatformResponse Execute(CreatePlatformInput input);
    }
}