using OnionPattern.Domain.DataTransferObjects.Game;

namespace OnionPattern.Domain.Services.Requests.Game
{
    public interface IGetGameByIdRequest
    {
        GameResponseDto Execute(int id);
    }
}