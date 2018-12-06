using OnionPattern.Domain.Game.Responses;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Game.Async;
using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OnionPattern.Service.Requests.Game.Async
{
    public class DeleteGameByIdRequestAsync : BaseServiceRequestAsync<Domain.Game.Entities.Game>, IDeleteGameByIdRequestAsync
    {
        public DeleteGameByIdRequestAsync(IRepositoryAsync<Domain.Game.Entities.Game> repositoryAsync, IRepositoryAsyncAggregate repositoryAsyncAggregate)
            : base(repositoryAsync, repositoryAsyncAggregate) { }

        #region Implementation of IDeleteGameByIdRequestAsync

        public async Task<GameResponse> ExecuteAsync(int id)
        {
            var gameResponse = new GameResponse();
            try
            {
                Log.Information("Deleting Game by Id:[{Id}]...", id);
                var toDelete = await Repository.SingleOrDefaultAsync(game => game.Id == id);
                if (toDelete == null)
                {
                    var exception = new Exception($"No Game found for Id:[{id}].");
                    Log.Error(exception, EXCEPTION_MESSAGE_TEMPLATE, exception.Message);
                    HandleErrors(gameResponse, exception, 404);
                }
                else
                {
                    #region Delete GamePlatform References

                    Log.Information("Retrieving GamePlatforms for Game: [{NewName}] with Id: [{Id}].", toDelete.Name, toDelete.Id);
                    var gamePlatforms = (await RepositoryAggregate.GamePlatforms.FindAsync(gp => gp.Id == id))?.ToArray();
                    if (gamePlatforms != null && gamePlatforms.Any())
                    {
                        Log.Information("Deleting [{Length}] GamePlatforms for Game: [{NewName}]...", gamePlatforms.Length, toDelete.Name);
                        foreach (var gp in gamePlatforms)
                        {
                            await RepositoryAggregate.GamePlatforms.DeleteAsync(gp);
                        }
                        Log.Information("Finished deleting GamePlatform entries. Proceeding to delete Game: {NewName} with Id: [{Id}].", toDelete.Name, toDelete.Id);
                    }

                    #endregion Delete GamePlatform References

                    gameResponse.Game = await Repository.DeleteAsync(toDelete);
                    gameResponse.StatusCode = 200;
                    Log.Information("Deleted Game [{NewName}] for Id:[{Id}].", toDelete.Name, toDelete.Id);
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Failed to Delete Game.");
                HandleErrors(gameResponse, exception);
            }
            return gameResponse;
        }

        #endregion
    }
}
