using OnionPattern.Domain.DataTransferObjects.Platform;

namespace OnionPattern.Domain.Services.Requests.Platform
{
    public interface IGetAllPlatformsRequest
    {
        PlatformListResponseDto Execute();
    }
}