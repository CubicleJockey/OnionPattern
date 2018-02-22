using OnionPattern.Domain.Game.Responses;

namespace OnionPattern.Domain.Services.Requests.Game
{
    public interface IDeleteGameByIdRequest
    {
        GameResponse Execute(int id);
    }
}