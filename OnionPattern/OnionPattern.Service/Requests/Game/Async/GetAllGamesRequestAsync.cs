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
        public GetAllGamesRequestAsync(IRepositoryAsync<Domain.Entities.Game> repository, IRepositoryAsyncAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate) { }

        #region Implementation of IGetAllGamesRequestAsync

        public async Task<GameListResponseDto> Execute()
        {
            Log.Information("Retrieving Games List (async)...");
            var gameListResponse = new GameListResponseDto();
            try
            {
                var games = (await Repository.GetAllAsync())?.ToArray();

                if (games == null || !games.Any())
                {
                    var exception = new Exception("No Games Returned.");
                    Log.Error("{Message}", exception.Message);
                    HandleErrors(gameListResponse, exception, 404);
                }
                else
                {
                    gameListResponse = new GameListResponseDto
                    {
                        Games = games,
                        StatusCode = 200
                    };
                    Log.Information("Retrieved [{V}] Games (async).", gameListResponse.Games.Count());
                }
            }
            catch (Exception x)
            {
                Log.Error("Failed to get All Games List. {Message}", x.Message);
                HandleErrors(gameListResponse, x);
            }
            return gameListResponse;
        }

        #endregion
    }
}
