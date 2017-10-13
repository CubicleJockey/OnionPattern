using OnionPattern.Domain.DataTransferObjects.Platform;

namespace OnionPattern.Domain.Services.Requests.Platform
{
    public interface IGetPlatformByIdRequest
    {
        PlatformResponseDto Execute(int id);
    }
}