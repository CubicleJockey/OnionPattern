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
                CheckInputValidity(input);

                Log.Information("Updating GameId: [{Id}] to new title [{NewTitle}]...", input.Id, input.NewTitle);
                
                var gameToUpdate = Repository.SingleOrDefault(game => game.Id == input.Id);
                if (gameToUpdate == null)
                {
                    var exception = new Exception($"Failed to find game for id: [{input.Id}].");
                    Log.Error("{Message}", exception.Message);
                    HandleErrors(gameResponse, exception, 404);
                    return gameResponse;
                }

                gameToUpdate.Name = input.NewTitle;
                var updatedGame = Repository.Update(gameToUpdate);
                gameResponse = Mapper.Map<Domain.Entities.Game, GameResponseDto>(updatedGame);
                gameResponse.StatusCode = 200;

                Log.Information("Successful updated GameId: [{Id}] to title [{NewTitle}].", input.Id, input.NewTitle);
            }
            catch (Exception x)
            {
                Log.Error(x, "{Message}", x.Message);
                HandleErrors(gameResponse, x);
            }
            return gameResponse;
        }

        #endregion

        private void CheckInputValidity(UpdateGameTitleInputDto input)
        {
            if (input == null) { throw new ArgumentNullException($"{nameof(input)} cannot be null."); }
            if (input.Id <= 0) { throw new ArgumentException($"Input {nameof(input.Id)} must be 1 or greater."); }
            if (string.IsNullOrWhiteSpace(input.NewTitle)) { throw new ArgumentException($"Input {nameof(input.NewTitle)} cannot be empty."); }
        }
    }
}
