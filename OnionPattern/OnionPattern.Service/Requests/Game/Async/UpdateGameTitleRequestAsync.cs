using OnionPattern.Domain.DataTransferObjects.Game;
using OnionPattern.Domain.DataTransferObjects.Game.Input;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Game.Async;
using Serilog;
using System;
using System.Threading.Tasks;
using AutoMapper;

namespace OnionPattern.Service.Requests.Game.Async
{
    public class UpdateGameTitleRequestAsync : BaseServiceRequestAsync<Domain.Entities.Game>, IUpdateGameTitleRequestAsync
    {
        public UpdateGameTitleRequestAsync(IRepositoryAsync<Domain.Entities.Game> repository, IRepositoryAsyncAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate) { }

        #region Implementation of IUpdateGameTitleRequestAsync

        public async Task<GameResponseDto> ExecuteAsync(UpdateGameTitleInputDto input)
        {
            Log.Information("Updating title for game with id: [{Id}]...", input.Id);
            var gameResponse = new GameResponseDto();
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
                    gameResponse = Mapper.Map<Domain.Entities.Game, GameResponseDto>(await Repository.UpdateAsync(gameToUpdate));
                    gameResponse.StatusCode = 200;
                }
            }
            catch (Exception x)
            {
                Log.Error(x, EXCEPTION_MESSAGE_TEMPLATE, x.Message);
                HandleErrors(gameResponse, x);
            }
            return gameResponse;
        }

        #endregion
    }
}
