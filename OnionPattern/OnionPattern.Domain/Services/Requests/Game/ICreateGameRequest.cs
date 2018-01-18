using OnionPattern.Domain.DataTransferObjects.Game;
using OnionPattern.Domain.DataTransferObjects.Game.Input;

namespace OnionPattern.Domain.Services.Requests.Game
{
    public interface ICreateGameRequest
    {
        GameResponseDto Execute(CreateGameInputDto input);
    }
}