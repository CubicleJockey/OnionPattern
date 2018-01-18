using OnionPattern.Domain.DataTransferObjects.Platform;

namespace OnionPattern.Domain.Services.Requests.Platform
{
    public interface IDeletePlatformByIdRequest
    {
        PlatformResponseDto Execute(int id);
    }
}