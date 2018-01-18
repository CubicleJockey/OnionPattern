using AutoMapper;
using OnionPattern.Domain.DataTransferObjects.Game;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Game.Async;
using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OnionPattern.Service.Requests.Game.Async
{
    public class GetGamesByGenreRequestAsync : BaseServiceRequestAsync<Domain.Entities.Game>, IGetGamesByGenreRequestAsync
    {
        public GetGamesByGenreRequestAsync(IRepositoryAsync<Domain.Entities.Game> repository, IRepositoryAsyncAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate) { }

        #region Implementation of IGetGamesByGenreRequestAsync

        public async Task<GameListResponseDto> ExecuteAsync(string genre)
        {
            var gameListResponse = new GameListResponseDto();
            try
            {
                Log.Information("Retrieving game Genre : [{Genre}]", genre);

                var games = (await Repository.FindAsync(g => string.Equals(g.Genre, genre, StringComparison.CurrentCultureIgnoreCase)))?.ToArray();
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
