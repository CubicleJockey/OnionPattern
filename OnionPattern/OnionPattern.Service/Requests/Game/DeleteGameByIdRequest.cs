using System;
using System.Linq;
using OnionPattern.Domain.Game.Responses;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Game;
using Serilog;

namespace OnionPattern.Service.Requests.Game
{
    public class DeleteGameByIdRequest : BaseServiceRequest<Domain.Game.Entities.Game>, IDeleteGameByIdRequest
    {
        public DeleteGameByIdRequest(IRepository<Domain.Game.Entities.Game> repository, IRepositoryAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate) { }

        #region Implementation of IDeleteGameByIdRequest

        public GameResponse Execute(int id)
        {
            var gameResponse = new GameResponse();
            try
            {
                Log.Information("Deleting Game by Id:[{Id}]...", id);
                var toDelete = Repository.SingleOrDefault(game => game.Id == id);
                if (toDelete == null)
                {
                    var exception = new Exception($"No Game found for Id:[{id}].");
                    Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                    HandleErrors(gameResponse, exception, 404);
                }
                else
                {
                    #region Delete GamePlatform References

                    Log.Information("Retrieving GamePlatoforms for Game: [{NewName}] with Id: [{Id}].", toDelete.Name, toDelete.Id);
                    var gamePlatforms = RepositoryAggregate.GamePlatforms.Find(gp => gp.Id == id)?.ToArray();
                    if(gamePlatforms != null && gamePlatforms.Any())
                    {
                        Log.Information("Deleting [{Length}] GamePlatforms for Game: [{NewName}]...", gamePlatforms.Length, toDelete.Name);
                        foreach (var gp in gamePlatforms)
                        {
                            RepositoryAggregate.GamePlatforms.Delete(gp);
                        }
                        Log.Information("Finished deleting GamePlatform enteries. Procceeding to delete Game: {NewName} with Id: [{Id}].", toDelete.Name, toDelete.Id);
                    }

                    #endregion Delete GamePlatform References

                    Repository.Delete(toDelete);
                    gameResponse.StatusCode = 200;
                    Log.Information("Deleted Game [{NewName}] for Id:[{Id}].", toDelete.Name, toDelete.Id);
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Failed to Delete Game. [{Message}].", exception.Message);
                HandleErrors(gameResponse, exception);
            }
            return gameResponse;
        }

        #endregion
    }
}
