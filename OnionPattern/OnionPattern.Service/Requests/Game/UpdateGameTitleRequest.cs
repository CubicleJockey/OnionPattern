using OnionPattern.Domain.DataTransferObjects.Game;
using OnionPattern.Domain.DataTransferObjects.Game.Input;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Game;
using Serilog;
using System;
using AutoMapper;

namespace OnionPattern.Service.Requests.Game
{
    public class UpdateGameTitleRequest : BaseServiceRequest<Domain.Entities.Game>, IUpdateGameTitleRequest
    {
        public UpdateGameTitleRequest(IRepository<Domain.Entities.Game> repository, IRepositoryAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate) { }

        #region Implementation of IUpdateGameTitleRequest

        public GameResponseDto Execute(UpdateGameTitleInputDto input)
        {
            var gameResponse = new GameResponseDto();
            try
            {
                Log.Information($"Updating GameId: [{input.Id}] to new title [{input.NewTitle}]...");

                if (input.Id <= 0)
                {
                    var exception = new ArgumentException($"{nameof(input.Id)} must be 1 or more.");
                    Log.Error(exception.Message);
                    HandleErrors(gameResponse, exception);
                    return gameResponse;
                }
                if (string.IsNullOrWhiteSpace(input.NewTitle))
                {
                    var exception = new ArgumentException($"{nameof(input.NewTitle)} cannot be empty.");
                    Log.Error(exception.Message);
                    HandleErrors(gameResponse, exception);
                    return gameResponse;
                }

                var gameToUpdate = Repository.SingleOrDefault(game => game.Id == input.Id);
                if (gameToUpdate == null)
                {
                    var exception = new Exception($"Failed to find game for id: [{input.Id}].");
                    Log.Error(exception.Message);
                    HandleErrors(gameResponse, exception, 404);
                    return gameResponse;
                }

                gameToUpdate.Name = input.NewTitle;
                var updatedGame = Repository.Update(gameToUpdate);
                gameResponse = Mapper.Map<Domain.Entities.Game, GameResponseDto>(updatedGame);
                gameResponse.StatusCode = 200;

                Log.Information($"Successful updated GameId: [{input.Id}] to title [{input.NewTitle}].");
            }
            catch (Exception x)
            {
                Log.Error($"Failed to update title to [{input.NewTitle}] for GameId: [{input.Id}].");
                HandleErrors(gameResponse, x);
            }
            return gameResponse;
        }

        #endregion
    }
}
