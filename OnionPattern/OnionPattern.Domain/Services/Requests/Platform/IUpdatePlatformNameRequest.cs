using OnionPattern.Domain.DataTransferObjects.Platform;
using OnionPattern.Domain.DataTransferObjects.Platform.Input;

namespace OnionPattern.Domain.Services.Requests.Platform
{
    public interface IUpdatePlatformNameRequest
    {
        PlatformResponseDto Execute(UpdatePlatformNameInputDto input);
    }
}