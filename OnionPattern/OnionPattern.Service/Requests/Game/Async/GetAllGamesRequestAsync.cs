using System;
using System.Linq;
using System.Threading.Tasks;
using OnionPattern.Domain.DataTransferObjects.Game;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Game.Async;
using Serilog;

namespace OnionPattern.Service.Requests.Game.Async
{
    public class GetAllGamesRequestAsync : BaseServiceRequestAsync<Domain.Entities.Game>, IGetAllGamesRequestAsync
    {
        public GetAllGamesRequestAsync(IRepositoryAsync<Domain.Entities.Game> repository, IRepositoryAsyncAggregate repositoryAggregate, ILogger logger) 
            : base(repository, repositoryAggregate, logger) { }

        #region Implementation of IGetAllGamesRequestAsync

        public async Task<GameListResponseDto> Execute()
        {
            Logger.Information("Retrieving Games List (async)...");
            var gameListResponse = new GameListResponseDto();
            try
            {
                var games = (await Repository.GetAllAsync())?.ToArray();

                if (games == null || !games.Any())
                {
                    var exception = new Exception("No Games Returned.");
                    Logger.Error(exception.Message);
                    HandleErrors(gameListResponse, exception, 404);
                }
                else
                {
                    gameListResponse = new GameListResponseDto
                    {
                        Games = games,
                        StatusCode = 200
                    };
                    Logger.Information($"Retrieved [{gameListResponse.Games.Count()}] Games (async).");
                }
            }
            catch (Exception x)
            {
                Logger.Error($"Failed to get All Games List. {x.Message}");
                HandleErrors(gameListResponse, x);
            }
            return gameListResponse;
        }

        #endregion
    }
}
