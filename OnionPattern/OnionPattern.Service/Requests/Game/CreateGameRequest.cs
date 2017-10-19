using System;
using AutoMapper;
using OnionPattern.Domain.DataTransferObjects.Game;
using OnionPattern.Domain.DataTransferObjects.Game.Input;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Game;
using Serilog;

namespace OnionPattern.Service.Requests.Game
{
    public class CreateGameRequest : BaseServiceRequest<Domain.Entities.Game>, ICreateGameRequest
    {
        public CreateGameRequest(IRepository<Domain.Entities.Game> repository, IRepositoryAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate) { }

        #region Implementation of ICreateGameRequest

        public GameResponseDto Execute(CreateGameInputDto game)
        {
            var gameResponse = new GameResponseDto();
            try
            {
                Log.Information("Creating Game Entry for [{NewName}].", game.Name);
                var gameEntity = Mapper.Map<CreateGameInputDto, Domain.Entities.Game>(game);
                gameResponse = Mapper.Map(Repository.Create(gameEntity), gameResponse);
                gameResponse.StatusCode = 200;
            }
            catch (Exception x)
            {
                Log.Information("Failed to Create Game: [{NewName}].", game.Name);
                HandleErrors(gameResponse, x);
            }
            return gameResponse;
        }

        #endregion
    }
}
