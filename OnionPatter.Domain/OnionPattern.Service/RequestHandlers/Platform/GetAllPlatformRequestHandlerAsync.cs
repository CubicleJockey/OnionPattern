using System.Threading.Tasks;
using MediatR;
using OnionPattern.Service.Requests.Platform;
using OnionPattern.Service.Responses;

namespace OnionPattern.Service.RequestHandlers.Platform
{
    public class GetAllPlatformRequestHandlerAsync :IAsyncRequestHandler<GetAllPlatformsRequest, GetAllPlatformsResponse>
    {
        public Task<GetAllPlatformsResponse> Handle(GetAllPlatformsRequest request)
        {
            return Task.FromResult(request.Execute());
        }
    }
}
