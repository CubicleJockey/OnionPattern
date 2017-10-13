using OnionPattern.Domain.DataTransferObjects.Game;
using OnionPattern.Domain.DataTransferObjects.Game.Input;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Game;
using Serilog;
using System;
using AutoMapper;

namespace OnionPattern.Service.Requests.Game
{
    public class UpdateGameTitleRequest : BaseServiceRequest<Domain.Entities.Game>, IUpdateGameRequest
    {
        public UpdateGameTitleRequest(IRepository<Domain.Entities.Game> repository, 
                                      IRepositoryAggregate repositoryAggregate, 
                                      ILogger logger) 
            : base(repository, repositoryAggregate, logger) { }

        #region Implementation of IUpdateGameRequest

        public GameResponseDto Execute(UpdateGameTitleInputDto input)
        {
            var gameResponse = new GameResponseDto();
            try
            {
                Logger.Information($"Updating GameId: [{input.Id}] to new title [{input.NewTitle}]...");

                if (input.Id <= 0)
                {
                    var exception = new ArgumentException($"{nameof(input.Id)} must be 1 or more.");
                    Logger.Error(exception.Message);
                    HandleErrors(gameResponse, exception);
                    return gameResponse;
                }
                if (string.IsNullOrWhiteSpace(input.NewTitle))
                {
                    var exception = new ArgumentException($"{nameof(input.NewTitle)} cannot be empty.");
                    Logger.Error(exception.Message);
                    HandleErrors(gameResponse, exception);
                    return gameResponse;
                }

                var gameToUpdate = Repository.SingleOrDefault(game => game.Id == input.Id);
                if (gameToUpdate == null)
                {
                    var exception = new Exception($"Failed to find game for id: [{input.Id}].");
                    Logger.Error(exception.Message);
                    HandleErrors(gameResponse, exception, 404);
                    return gameResponse;
                }

                gameToUpdate.Name = input.NewTitle;
                var updatedGame = Repository.Update(gameToUpdate);
                gameResponse = Mapper.Map<Domain.Entities.Game, GameResponseDto>(updatedGame);
                gameResponse.StatusCode = 200;

                Logger.Information($"Successful updated GameId: [{input.Id}] to title [{input.NewTitle}].");
            }
            catch (Exception x)
            {
                Logger.Error($"Failed to update title to [{input.NewTitle}] for GameId: [{input.Id}].");
                HandleErrors(gameResponse, x);
            }
            return gameResponse;
        }

        #endregion
    }
}
