using System.Threading.Tasks;
using OnionPattern.Domain.Platform.Requests;
using OnionPattern.Domain.Platform.Responses;

namespace OnionPattern.Domain.Services.Requests.Platform.Async
{
    public interface ICreatePlatformRequestAsync
    {
        Task<PlatformResponse> ExecuteAsync(CreatePlatformInput input);
    }
}