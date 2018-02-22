using System;
using AutoMapper;
using OnionPattern.Domain.Game.Requests;
using OnionPattern.Domain.Game.Responses;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Game;
using Serilog;

namespace OnionPattern.Service.Requests.Game
{
    public class CreateGameRequest : BaseServiceRequest<Domain.Game.Entities.Game>, ICreateGameRequest
    {
        public CreateGameRequest(IRepository<Domain.Game.Entities.Game> repository, IRepositoryAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate) { }

        #region Implementation of ICreateGameRequest

        public GameResponse Execute(CreateGameInput game)
        {
            var gameResponse = new GameResponse();
            try
            {
                Log.Information("Creating Game Entry for [{NewName}].", game?.Name);
                var gameEntity = Mapper.Map<CreateGameInput, Domain.Game.Entities.Game>(game);
                gameResponse = Mapper.Map(Repository.Create(gameEntity), gameResponse);
                gameResponse.StatusCode = 200;
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Failed to Create Game: [{NewName}].", game?.Name);
                HandleErrors(gameResponse, exception);
            }
            return gameResponse;
        }

        #endregion
    }
}
