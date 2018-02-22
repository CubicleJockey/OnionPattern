using OnionPattern.Domain.Game.Responses;

namespace OnionPattern.Domain.Services.Requests.Game
{
    public interface IGetAllGamesRequest
    {
        GameListResponse Execute();
    }
}