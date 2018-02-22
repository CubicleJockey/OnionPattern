using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Game;
using Serilog;
using System;
using System.Linq;
using OnionPattern.Domain.Game.Responses;

namespace OnionPattern.Service.Requests.Game
{
    public class GetAllGamesRequest : BaseServiceRequest<Domain.Game.Entities.Game>, IGetAllGamesRequest
    {
        public GetAllGamesRequest(IRepository<Domain.Game.Entities.Game> repository, IRepositoryAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate) { }


        #region Implementation of IGetAllGamesRequest

        public GameListResponse Execute()
        {
            Log.Information("Retrieving Games List...");
            var gameListResponse = new GameListResponse();
            try
            {
                var games = Repository.GetAll()?.ToArray();

                if (games == null || !games.Any())
                {
                    var exception = new Exception("No Games Returned.");
                    Log.Error(EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
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
                Log.Error(exception, "Failed to get All Games List. {Message}", exception.Message);
                HandleErrors(gameListResponse, exception);
            }
            return gameListResponse;
        }

        #endregion
    }
}
