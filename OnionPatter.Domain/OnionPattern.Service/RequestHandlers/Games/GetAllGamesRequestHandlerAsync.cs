using System.Threading.Tasks;
using MediatR;
using OnionPattern.Service.Requests.Games;
using OnionPattern.Service.Responses;

namespace OnionPattern.Service.RequestHandlers.Games
{
    public class GetAllGamesRequestHandlerAsync : IAsyncRequestHandler<GetAllGamesRequest, GetAllGamesResponse>
    {
        public Task<GetAllGamesResponse> Handle(GetAllGamesRequest request)
        {
            return Task.FromResult(request.Execute());
        }
    }
}
