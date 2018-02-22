using System;
using System.Linq;
using System.Threading.Tasks;
using OnionPattern.Domain.Game.Responses;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Game.Async;
using Serilog;

namespace OnionPattern.Service.Requests.Game.Async
{
    public class GetAllGamesRequestAsync : BaseServiceRequestAsync<Domain.Game.Entities.Game>, IGetAllGamesRequestAsync
    {
        public GetAllGamesRequestAsync(IRepositoryAsync<Domain.Game.Entities.Game> repository, IRepositoryAsyncAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate) { }

        #region Implementation of IGetAllGamesRequestAsync

        public async Task<GameListResponse> ExecuteAsync()
        {
            Log.Information("Retrieving Games List...");
            var gameListResponse = new GameListResponse();
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
                    gameListResponse = new GameListResponse
                    {
                        Games = games,
                        StatusCode = 200
                    };
                    var count = games.Length;
                    Log.Information("Retrieved [{Count}] Games.", count);
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Failed to get All Games List.");
                HandleErrors(gameListResponse, exception);
            }
            return gameListResponse;
        }

        #endregion
    }
}
