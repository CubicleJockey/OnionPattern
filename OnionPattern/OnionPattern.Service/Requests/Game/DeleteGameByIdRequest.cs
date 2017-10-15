using System;
using System.Linq;
using OnionPattern.Domain.DataTransferObjects.Game;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Game;
using Serilog;

namespace OnionPattern.Service.Requests.Game
{
    public class DeleteGameByIdRequest : BaseServiceRequest<Domain.Entities.Game>, IDeleteGameByIdRequest
    {
        public DeleteGameByIdRequest(IRepository<Domain.Entities.Game> repository, IRepositoryAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate) { }

        #region Implementation of IDeleteGameByIdRequest

        public GameResponseDto Execute(int id)
        {
            var gameResponse = new GameResponseDto();
            try
            {
                Logger.Information($"Deleting Game by Id:[{id}]...");
                var toDelete = Repository.SingleOrDefault(game => game.Id == id);
                if (toDelete == null)
                {
                    var exception = new Exception($"No Game found for Id:[{id}].");
                    HandleErrors(gameResponse, exception, 404);
                }
                else
                {
                    #region Delete GamePlatform References

                    Log.Information($"Retrieving GamePlatoforms for Game: [{toDelete.Name}] with Id: [{toDelete.Id}].");
                    var gamePlatforms = RepositoryAggregate.GamePlatforms.Find(gp => gp.Id == id)?.ToArray();
                    if(gamePlatforms != null && gamePlatforms.Any())
                    {
                        Log.Logger.Information($"Deleting [{gamePlatforms.Length}] GamePlatforms for Game: [{toDelete.Name}]...");
                        foreach (var gp in gamePlatforms)
                        {
                            RepositoryAggregate.GamePlatforms.Delete(gp);
                        }
                        Log.Logger.Information($"Finished deleting GamePlatform enteries. Procceeding to delete Game: {toDelete.Name} with Id: [{toDelete.Id}].");
                    }

                    #endregion Delete GamePlatform References

                    Repository.Delete(toDelete);
                    gameResponse.StatusCode = 200;
                    Logger.Information($"Deleted Game [{toDelete.Name}] for Id:[{toDelete.Id}].");
                }
            }
            catch (Exception x)
            {
                Logger.Error($"Failed to Delete Game. [{x.Message}].");
                HandleErrors(gameResponse, x);
            }
            return gameResponse;
        }

        #endregion
    }
}
