using System.Threading.Tasks;
using OnionPattern.Domain.Game.Requests;
using OnionPattern.Domain.Game.Responses;

namespace OnionPattern.Domain.Services.Requests.Game.Async
{
    public interface ICreateGameRequestAsync
    {
        Task<GameResponse> ExecuteAsync(CreateGameInput input);
    }
}