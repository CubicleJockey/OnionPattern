using OnionPattern.Domain.DataTransferObjects.Game;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Game;
using System;
using AutoMapper;
using Serilog;

namespace OnionPattern.Service.Requests.Game
{
    public class GetGameByIdRequest : BaseServiceRequest<Domain.Entities.Game>, IGetGameByIdRequest
    {
        public GetGameByIdRequest(IRepository<Domain.Entities.Game> repository, IRepositoryAggregate repositoryAggregate, ILogger logger) 
            : base(repository, repositoryAggregate, logger) { }

        #region Implementation of IGetGameByIdRequest

        public GameResponseDto Execute(int id)
        {
            var gameResponse = new GameResponseDto();
            try
            {
                Logger.Information($"Retrieving game title : [{id}]");

                var game = Repository.SingleOrDefault(g => g.Id == id);
                if (game == null)
                {
                    var exception = new Exception($"No game found by title : [{id}].");
                    Logger.Error(exception.Message);
                    HandleErrors(gameResponse, exception, 404);
                }
                else
                {
                    //NOTE: Not sure if I want to do something like AutoMapper for this example.
                    gameResponse = Mapper.Map<Domain.Entities.Game, GameResponseDto>(game);
                    gameResponse.StatusCode = 200;
                }
            }
            catch (Exception x)
            {
                Logger.Error($"Failed to get Game for title [{id}].");
                HandleErrors(gameResponse, x);
            }
            return gameResponse;
        }

        #endregion
    }
}
