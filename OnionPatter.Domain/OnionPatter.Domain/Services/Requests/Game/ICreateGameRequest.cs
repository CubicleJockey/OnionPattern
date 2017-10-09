using OnionPattern.Domain.DataTransferObjects.Game;

namespace OnionPattern.Domain.Services.Requests.Game
{
    public interface ICreateGameRequest
    {
        GameResponseDto Execute(CreateGameDto game);
    }
}