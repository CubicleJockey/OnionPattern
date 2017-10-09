using System;
using AutoMapper;
using OnionPattern.Domain.DataTransferObjects.Game;
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

        public GameResponseDto Execute(CreateGameDto game)
        {
            var gameResponse = new GameResponseDto();
            try
            {
                Log.Logger.Information($"Creating Game Entry for [{game.Name}].");
                var gameEntity = Mapper.Map<CreateGameDto, Domain.Entities.Game>(game);
                gameResponse = Mapper.Map<Domain.Entities.Game, GameResponseDto>(Repository.Create(gameEntity));
                gameResponse.StatusCode = 200;
            }
            catch (Exception x)
            {
                Log.Logger.Information($"Failed to Create Game: [{game.Name}].");
                HandleErrors(gameResponse, x);
            }
            return gameResponse;
        }

        #endregion
    }
}
