using OnionPattern.Domain.Game.Responses;

namespace OnionPattern.Domain.Services.Requests.Game
{
    public interface IGetGameByIdRequest
    {
        GameResponse Execute(int id);
    }
}