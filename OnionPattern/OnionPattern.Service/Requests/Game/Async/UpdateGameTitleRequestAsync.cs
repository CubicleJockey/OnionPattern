using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Game.Async;
using Serilog;
using System;
using System.Threading.Tasks;
using AutoMapper;
using OnionPattern.Domain.Game.Requests;
using OnionPattern.Domain.Game.Responses;

namespace OnionPattern.Service.Requests.Game.Async
{
    public class UpdateGameTitleRequestAsync : BaseServiceRequestAsync<Domain.Game.Entities.Game>, IUpdateGameTitleRequestAsync
    {
        public UpdateGameTitleRequestAsync(IRepositoryAsync<Domain.Game.Entities.Game> repository, IRepositoryAsyncAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate) { }

        #region Implementation of IUpdateGameTitleRequestAsync

        public async Task<GameResponse> ExecuteAsync(UpdateGameTitleInput input)
        {
            Log.Information("Updating title for game with id: [{Id}]...", input.Id);
            var gameResponse = new GameResponse();
            try
            {
                if (string.IsNullOrWhiteSpace(input.NewTitle))
                {
                    var exception = new ArgumentException($"[{nameof(input)}] property [{nameof(input.NewTitle)}] cannot be empty.");
                    HandleErrors(gameResponse, exception);
                    return gameResponse;
                }

                var gameToUpdate = await Repository.SingleOrDefaultAsync(g => g.Id == input.Id);
                if (gameToUpdate == null)
                {
                    var exception = new Exception($"Update failed: No Game found for Id: [{input.Id}].");
                    Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                    HandleErrors(gameResponse, exception, 404);
                }
                else
                {
                    gameToUpdate.Name = input.NewTitle;
                    gameResponse = Mapper.Map(await Repository.UpdateAsync(gameToUpdate), gameResponse);
                    gameResponse.StatusCode = 200;
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                HandleErrors(gameResponse, exception);
            }
            return gameResponse;
        }

        #endregion
    }
}
