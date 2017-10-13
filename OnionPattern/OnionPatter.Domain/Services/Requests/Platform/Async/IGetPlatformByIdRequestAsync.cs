using System.Threading.Tasks;
using OnionPattern.Domain.DataTransferObjects.Platform;

namespace OnionPattern.Domain.Services.Requests.Platform.Async
{
    public interface IGetPlatformByIdRequestAsync
    {
        Task<PlatformResponseDto> ExecuteAsync(int id);
    }
}