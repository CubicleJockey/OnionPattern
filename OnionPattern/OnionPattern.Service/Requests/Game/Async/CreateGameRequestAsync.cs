using System;
using System.Threading.Tasks;
using AutoMapper;
using OnionPattern.Domain.DataTransferObjects.Game;
using OnionPattern.Domain.DataTransferObjects.Game.Input;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Game.Async;
using Serilog;

namespace OnionPattern.Service.Requests.Game.Async
{
    public class CreateGameRequestAsync : BaseServiceRequestAsync<Domain.Entities.Game>, ICreateGameRequestAsync
    {
        public CreateGameRequestAsync(IRepositoryAsync<Domain.Entities.Game> repository, IRepositoryAsyncAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate) { }

        #region Implementation of ICreateGameRequestAsync

        public async Task<GameResponseDto> ExecuteAsync(CreateGameInputDto input)
        {
            var gameResponse = new GameResponseDto();
            try
            {
                Log.Logger.Information($"Creating Game Entry for [{input.Name}].");
                var gameEntity = Mapper.Map<CreateGameInputDto, Domain.Entities.Game>(input);
                gameResponse = Mapper.Map<Domain.Entities.Game, GameResponseDto>(await Repository.CreateAsync(gameEntity));
                gameResponse.StatusCode = 200;
            }
            catch (Exception x)
            {
                Log.Logger.Information($"Failed to Create Game: [{input.Name}].");
                HandleErrors(gameResponse, x);
            }
            return gameResponse;
        }

        #endregion
    }
}
