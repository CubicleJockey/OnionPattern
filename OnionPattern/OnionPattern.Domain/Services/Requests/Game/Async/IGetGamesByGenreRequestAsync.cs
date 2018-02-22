using System.Threading.Tasks;
using OnionPattern.Domain.Game.Responses;

namespace OnionPattern.Domain.Services.Requests.Game.Async
{
    public interface IGetGamesByGenreRequestAsync
    {
        Task<GameListResponse> ExecuteAsync(string genre);
    }
}