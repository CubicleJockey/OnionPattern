using OnionPattern.Domain.DataTransferObjects.Game;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Game;
using Serilog;
using System;
using System.Linq;

namespace OnionPattern.Service.Requests.Game
{
    public class GetAllGamesRequest : BaseServiceRequest<Domain.Entities.Game>, IGetAllGamesRequest
    {
        public GetAllGamesRequest(IRepository<Domain.Entities.Game> repository, IRepositoryAggregate repositoryAggregate, ILogger logger) 
            : base(repository, repositoryAggregate, logger) { }


        #region Implementation of IGetAllGamesRequest

        public GameListResponseDto Execute()
        {
            Logger.Information("Retrieving Games List...");
            var gameListResponse = new GameListResponseDto();
            try
            {
                var games = Repository.GetAll()?.ToArray();

                if (games == null || !games.Any())
                {
                    var exception = new Exception("No Games Returned.");
                    Logger.Error(exception.Message);
                    HandleErrors(gameListResponse, exception, 404);
                }
                else
                {
                    //TODO: Aggregate the Platforms data.

                    gameListResponse = new GameListResponseDto
                    {
                        Games = games,
                        StatusCode = 200
                    };
                    Logger.Information($"Retrieved [{gameListResponse.Games.Count()}] Games.");
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
