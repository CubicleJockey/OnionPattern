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

        public async Task<GameListResponseDto> ExecuteAsync()
        {
            Log.Information("Retrieving Games List (async)...");
            var gameListResponse = new GameListResponseDto();
            try
            {
                var games = (await Repository.GetAllAsync())?.ToArray();

                if (games == null || !games.Any())
                {
                    var exception = new Exception("No Games Returned.");
                    Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                    HandleErrors(gameListResponse, exception, 404);
                }
                else
                {
                    gameListResponse = new GameListResponseDto
                    {
                        Games = games,
                        StatusCode = 200
                    };
                    var count = games.Length;
                    Log.Information("Retrieved [{Count}] Games (async).", count);
                }
            }
            catch (Exception x)
            {
                Log.Error(x, "Failed to get All Games List.");
                HandleErrors(gameListResponse, x);
            }
            return gameListResponse;
        }

        #endregion
    }
}
