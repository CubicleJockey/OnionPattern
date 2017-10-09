using System;
using System.Threading.Tasks;
using OnionPattern.Domain.DataTransferObjects.Game;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Game;
using Serilog;

namespace OnionPattern.Service.Requests.Game
{
    public class GetGameByIdRequestAsync : BaseServiceRequestAsync<Domain.Entities.Game>, IGetGameByIdRequestAsync
    {
        public GetGameByIdRequestAsync(IRepositoryAsync<Domain.Entities.Game> repository, IRepositoryAsyncAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate) { }

        #region Implementation of IGetGameByIdRequestAsync

        public async Task<GameResponseDto> Execute(int id)
        {
            var gameResponse = new GameResponseDto();
            try
            {
                Log.Logger.Information($"Retrieving game title : [{id}]");

                var game = await Repository.SingleOrDefaultAsync(g => g.Id == id);
                if (game == null)
                {
                    throw new Exception($"No game found by title : [{id}].");
                }

                //NOTE: Not sure if I want to do something like AutoMapper for this example.
                gameResponse.Id = game.Id;
                gameResponse.Name = game.Name;
                gameResponse.Genre = game.Genre;
                gameResponse.Price = game.Price;
                gameResponse.ReleaseDate = game.ReleaseDate;
                gameResponse.StatusCode = 200;
            }
            catch (Exception x)
            {
                Log.Logger.Error($"Failed to get Game for title [{id}].");
                HandleErrors(gameResponse, x);
            }
            return gameResponse;
        }

        #endregion
    }
}
