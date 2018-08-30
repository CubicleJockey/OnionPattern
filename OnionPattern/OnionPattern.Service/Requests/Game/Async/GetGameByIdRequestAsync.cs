using OnionPattern.Domain.Game.Responses;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Game.Async;
using Serilog;
using System;
using System.Threading.Tasks;

namespace OnionPattern.Service.Requests.Game.Async
{
    public class GetGameByIdRequestAsync : BaseServiceRequestAsync<Domain.Game.Entities.Game>, IGetGameByIdRequestAsync
    {
        public GetGameByIdRequestAsync(IRepositoryAsync<Domain.Game.Entities.Game> repositoryAsync, IRepositoryAsyncAggregate repositoryAsyncAggregate)
            : base(repositoryAsync, repositoryAsyncAggregate) { }

        #region Implementation of IGetGameByIdRequestAsync

        public async Task<GameResponse> ExecuteAsync(int id)
        {
            var gameResponse = new GameResponse();
            try
            {
                Log.Information("Retrieving game title : [{Id}]...", id);

                var game = await Repository.SingleOrDefaultAsync(g => g.Id == id);
                if (game == null)
                {
                    var exception = new Exception($"No game found by title : [{id}].");
                    Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                    HandleErrors(gameResponse, exception, 404);
                }
                else
                {
                    //NOTE: Not sure if I want to do something like AutoMapper for this example.
                    gameResponse.Game = game;
                    gameResponse.StatusCode = 200;
                    Log.Information("Retrieved [{NewName}] for Id: [{Id}].", gameResponse.Game.Name, id);
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Failed to get Game for title [{Id}].", id);
                HandleErrors(gameResponse, exception);
            }
            return gameResponse;
        }

        #endregion
    }
}
