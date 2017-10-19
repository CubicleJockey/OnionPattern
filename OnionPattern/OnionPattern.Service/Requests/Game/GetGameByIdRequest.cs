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
        public GetGameByIdRequest(IRepository<Domain.Entities.Game> repository, IRepositoryAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate) { }

        #region Implementation of IGetGameByIdRequest

        public GameResponseDto Execute(int id)
        {
            var gameResponse = new GameResponseDto();
            try
            {
                Log.Information("Retrieving game title : [{Id}]", id);

                var game = Repository.SingleOrDefault(g => g.Id == id);
                if (game == null)
                {
                    var exception = new Exception($"No game found by title : [{id}].");
                    Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                    HandleErrors(gameResponse, exception, 404);
                }
                else
                {
                    //NOTE: Not sure if I want to do something like AutoMapper for this example.
                    gameResponse = Mapper.Map(game, gameResponse);
                    gameResponse.StatusCode = 200;
                }
            }
            catch (Exception x)
            {
                Log.Error(x, "Failed to get Game for title [{Id}].", id);
                HandleErrors(gameResponse, x);
            }
            return gameResponse;
        }

        #endregion
    }
}
