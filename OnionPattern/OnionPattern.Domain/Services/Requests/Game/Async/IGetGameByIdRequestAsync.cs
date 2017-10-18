using System.Threading.Tasks;
using OnionPattern.Domain.DataTransferObjects.Game;

namespace OnionPattern.Domain.Services.Requests.Game.Async
{
    public interface IGetGameByIdRequestAsync
    {
        Task<GameResponseDto> ExecuteAsync(int id);
    }
}