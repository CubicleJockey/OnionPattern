using System.Threading.Tasks;
using OnionPattern.Domain.DataTransferObjects.Platform;
using OnionPattern.Domain.DataTransferObjects.Platform.Input;

namespace OnionPattern.Domain.Services.Requests.Platform.Async
{
    public interface IUpdatePlatformNameRequestAsync
    {
        Task<PlatformResponseDto> ExecuteAsync(UpdatePlatformNameInputDto input);
    }
}
