using System.Threading.Tasks;
using OnionPattern.Domain.Platform.Responses;

namespace OnionPattern.Domain.Services.Requests.Platform.Async
{
    public interface IGetAllPlatformsRequestAsync
    {
        Task<PlatformListResponse> ExecuteAsync();
    }
}