using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Game;
using Serilog;
using System;
using AutoMapper;
using OnionPattern.Domain.Game.Requests;
using OnionPattern.Domain.Game.Responses;

namespace OnionPattern.Service.Requests.Game
{
    public class UpdateGameTitleRequest : BaseServiceRequest<Domain.Game.Entities.Game>, IUpdateGameTitleRequest
    {
        public UpdateGameTitleRequest(IRepository<Domain.Game.Entities.Game> repository, IRepositoryAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate) { }

        #region Implementation of IUpdateGameTitleRequest

        public GameResponse Execute(UpdateGameTitleInput input)
        {

            var gameResponse = new GameResponse();
            try
            {
                CheckInputValidity(input);

                Log.Information("Updating GameId: [{Id}] to new title [{NewTitle}]...", input.Id, input.NewTitle);
                
                var gameToUpdate = Repository.SingleOrDefault(game => game.Id == input.Id);
                if (gameToUpdate == null)
                {
                    var exception = new Exception($"Failed to find game for id: [{input.Id}].");
                    Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                    HandleErrors(gameResponse, exception, 404);
                    return gameResponse;
                }

                gameToUpdate.Name = input.NewTitle;

                var updatedGame = Repository.Update(gameToUpdate);
                gameResponse = Mapper.Map(updatedGame, gameResponse);
                gameResponse.StatusCode = 200;

                Log.Information("Successful updated GameId: [{Id}] to title [{NewTitle}].", input.Id, input.NewTitle);
            }
            catch (Exception exception)
            {
                Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                HandleErrors(gameResponse, exception);
            }
            return gameResponse;
        }

        #endregion

        private void CheckInputValidity(UpdateGameTitleInput input)
        {
            if (input == null) { throw new ArgumentNullException(nameof(input)); }
            if (input.Id <= 0) { throw new ArgumentException($"Input {nameof(input.Id)} must be 1 or greater."); }
            if (string.IsNullOrWhiteSpace(input.NewTitle)) { throw new ArgumentException($"Input {nameof(input.NewTitle)} cannot be empty."); }
        }
    }
}
