using System.Threading.Tasks;
using OnionPattern.Domain.DataTransferObjects.Game;

namespace OnionPattern.Domain.Services.Requests.Game.Async
{
    public interface IGetAllGamesRequestAsync
    {
        Task<GameListResponseDto> Execute();
    }
}