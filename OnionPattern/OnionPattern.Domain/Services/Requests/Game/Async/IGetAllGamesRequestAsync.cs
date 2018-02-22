using System.Threading.Tasks;
using OnionPattern.Domain.Game.Responses;

namespace OnionPattern.Domain.Services.Requests.Game.Async
{
    public interface IGetAllGamesRequestAsync
    {
        Task<GameListResponse> ExecuteAsync();
    }
}