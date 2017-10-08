using System.Threading.Tasks;
using OnionPattern.Domain.DataTransferObjects.Game;

namespace OnionPattern.Domain.Services.Requests.Game
{
    public interface IGetGameByIdRequestAsync
    {
        Task<GameResponseDto> Execute(int id);
    }
}