using System;
using System.Linq;
using OnionPattern.Domain.DataTransferObjects.Game;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Game;
using System.Threading.Tasks;
using Serilog;

namespace OnionPattern.Service.Requests.Game
{
    public class GetAllGamesRequestAsync : BaseServiceRequestAsync<Domain.Entities.Game>, IGetAllGamesRequestAsync
    {
        public GetAllGamesRequestAsync(IRepositoryAsync<Domain.Entities.Game> repository, IRepositoryAsyncAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate) { }

        #region Implementation of IGetAllGamesRequestAsync

        public async Task<GameListResponseDto> Execute()
        {
            Log.Logger.Information("Retrieving Games List (async)...");
            var gameListResponse = new GameListResponseDto();
            try
            {
                var games = (await Repository.GetAllAsync())?.ToArray();

                if (games == null || !games.Any())
                {
                    var exception = new Exception("No Games Returned.");
                    HandleErrors(gameListResponse, exception, 404);
                }
                else
                {
                    gameListResponse = new GameListResponseDto
                    {
                        Games = games,
                        StatusCode = 200
                    };
                    Log.Logger.Information($"Retrieved [{gameListResponse.Games.Count()}] Games (async).");
                }
            }
            catch (Exception x)
            {
                Log.Logger.Error($"Failed to get All Games List. {x.Message}");
                HandleErrors(gameListResponse, x);
            }
            return gameListResponse;
        }

        #endregion
    }
}
