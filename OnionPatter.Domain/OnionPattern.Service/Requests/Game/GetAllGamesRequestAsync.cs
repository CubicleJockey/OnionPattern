using OnionPattern.Domain.DataTransferObjects.Game;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Game;
using System.Threading.Tasks;

namespace OnionPattern.Service.Requests.Game
{
    public class GetAllGamesRequestAsync : BaseServiceRequestAsync<Domain.Entities.Game>, IGetAllGamesRequestAsync
    {
        public GetAllGamesRequestAsync(IRepositoryAsync<Domain.Entities.Game> repository, IRepositoryAsyncAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate) { }

        #region Implementation of IGetAllGamesRequestAsync

        public async Task<GameListResponseDto> Execute()
        {
            var games = await RepositoryAsync.GetAllAsync();
            return new GameListResponseDto { Games = games };
        }

        #endregion
    }
}
