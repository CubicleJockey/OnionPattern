using System;
using System.Linq;
using AutoMapper;
using OnionPattern.Domain.DataTransferObjects.Game;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Game;
using Serilog;

namespace OnionPattern.Service.Requests.Game
{
    public class GetGamesByGenreRequest : BaseServiceRequest<Domain.Entities.Game>, IGetGamesByGenreRequest
    {
        public GetGamesByGenreRequest(IRepository<Domain.Entities.Game> repository, IRepositoryAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate) { }

        #region Implementation of IGetGamesByGenreRequest

        public GameListResponseDto Execute(string genre)
        {
            var gameListResponse = new GameListResponseDto();
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
                    gameListResponse.Games = games.Select(Mapper.Map<Domain.Entities.Game, GameResponseDto>);
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
