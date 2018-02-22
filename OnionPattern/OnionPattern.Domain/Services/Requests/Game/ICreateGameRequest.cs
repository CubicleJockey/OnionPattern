using OnionPattern.Domain.Game.Requests;
using OnionPattern.Domain.Game.Responses;

namespace OnionPattern.Domain.Services.Requests.Game
{
    public interface ICreateGameRequest
    {
        GameResponse Execute(CreateGameInput input);
    }
}