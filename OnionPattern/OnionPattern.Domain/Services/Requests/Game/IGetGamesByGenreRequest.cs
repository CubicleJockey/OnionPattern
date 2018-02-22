using OnionPattern.Domain.Game.Responses;

namespace OnionPattern.Domain.Services.Requests.Game
{
    public interface IGetGamesByGenreRequest
    {
        GameListResponse Execute(string genre);
    }
}