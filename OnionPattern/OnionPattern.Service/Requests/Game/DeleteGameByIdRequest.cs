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
                Log.Information("Deleting Game by Id:[{Id}]...", id);
                var toDelete = Repository.SingleOrDefault(game => game.Id == id);
                if (toDelete == null)
                {
                    var exception = new Exception($"No Game found for Id:[{id}].");
                    HandleErrors(gameResponse, exception, 404);
                }
                else
                {
                    #region Delete GamePlatform References

                    Log.Information("Retrieving GamePlatoforms for Game: [{Name}] with Id: [{Id}].", toDelete.Name, toDelete.Id);
                    var gamePlatforms = RepositoryAggregate.GamePlatforms.Find(gp => gp.Id == id)?.ToArray();
                    if(gamePlatforms != null && gamePlatforms.Any())
                    {
                        Log.Information("Deleting [{Length}] GamePlatforms for Game: [{Name}]...", gamePlatforms.Length, toDelete.Name);
                        foreach (var gp in gamePlatforms)
                        {
                            RepositoryAggregate.GamePlatforms.Delete(gp);
                        }
                        Log.Information("Finished deleting GamePlatform enteries. Procceeding to delete Game: {Name} with Id: [{Id}].", toDelete.Name, toDelete.Id);
                    }

                    #endregion Delete GamePlatform References

                    Repository.Delete(toDelete);
                    gameResponse.StatusCode = 200;
                    Log.Information("Deleted Game [{Name}] for Id:[{Id}].", toDelete.Name, toDelete.Id);
                }
            }
            catch (Exception x)
            {
                Log.Error("Failed to Delete Game. [{Message}].", x.Message);
                HandleErrors(gameResponse, x);
            }
            return gameResponse;
        }

        #endregion
    }
}
