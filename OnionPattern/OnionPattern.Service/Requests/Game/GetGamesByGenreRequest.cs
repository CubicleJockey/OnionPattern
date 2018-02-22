using OnionPattern.Domain.Game.Responses;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Game;
using Serilog;
using System;

namespace OnionPattern.Service.Requests.Game
{
    public class GetGamesByGenreRequest : BaseServiceRequest<Domain.Game.Entities.Game>, IGetGamesByGenreRequest
    {
        public GetGamesByGenreRequest(IRepository<Domain.Game.Entities.Game> repository, IRepositoryAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate) { }

        #region Implementation of IGetGamesByGenreRequest

        public GameListResponse Execute(string genre)
        {
            var gameListResponse = new GameListResponse();
            try
            {
                Log.Information("Retrieving game Genre : [{Genre}]", genre);

                var games = Repository.Find(g => string.Equals(g.Genre, genre, StringComparison.CurrentCultureIgnoreCase));
                if (games == null)
                {
                    var exception = new Exception($"No game found by Genre : [{genre}].");
                    Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                    HandleErrors(gameListResponse, exception, 404);
                }
                else
                {
                    //NOTE: Not sure if I want to do something like AutoMapper for this example.
                    gameListResponse.Games = games;
                    gameListResponse.StatusCode = 200;
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Failed to get Game for Genre [{Genre}].", genre);
                HandleErrors(gameListResponse, exception);
            }
            return gameListResponse;
        }

        #endregion
    }
}
