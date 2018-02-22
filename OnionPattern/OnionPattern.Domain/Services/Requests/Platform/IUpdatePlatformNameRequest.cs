using OnionPattern.Domain.Platform.Requests;
using OnionPattern.Domain.Platform.Responses;

namespace OnionPattern.Domain.Services.Requests.Platform
{
    public interface IUpdatePlatformNameRequest
    {
        PlatformResponse Execute(UpdatePlatformNameInput input);
    }
}