using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OnionPattern.Domain.DataTransferObjects.Game;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Game.Async;
using Serilog;

namespace OnionPattern.Service.Requests.Game.Async
{
    public class DeleteGameByIdRequestAsync : BaseServiceRequestAsync<Domain.Entities.Game>, IDeleteGameByIdRequestAsync
    {
        public DeleteGameByIdRequestAsync(IRepositoryAsync<Domain.Entities.Game> repository, IRepositoryAsyncAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate) { }

        #region Implementation of IDeleteGameByIdRequestAsync

        public async Task<GameResponseDto> ExecuteAsync(int id)
        {
            var gameResponse = new GameResponseDto();
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

                    Log.Information("Retrieving GamePlatoforms for Game: [{Name}] with Id: [{Id}].", toDelete.Name, toDelete.Id);
                    var gamePlatforms = (await RepositoryAggregate.GamePlatforms.FindAsync(gp => gp.Id == id))?.ToArray();
                    if (gamePlatforms != null && gamePlatforms.Any())
                    {
                        Log.Information("Deleting [{Length}] GamePlatforms for Game: [{Name}]...", gamePlatforms.Length, toDelete.Name);
                        foreach (var gp in gamePlatforms)
                        {
                            await RepositoryAggregate.GamePlatforms.DeleteAsync(gp);
                        }
                        Log.Information("Finished deleting GamePlatform enteries. Procceeding to delete Game: {Name} with Id: [{Id}].", toDelete.Name, toDelete.Id);
                    }

                    #endregion Delete GamePlatform References

                    gameResponse = Mapper.Map(await Repository.DeleteAsync(toDelete), gameResponse);
                    gameResponse.StatusCode = 200;
                    Log.Information("Deleted Game [{Name}] for Id:[{Id}].", toDelete.Name, toDelete.Id);
                }
            }
            catch (Exception x)
            {
                Log.Error(x, "Failed to Delete Game.");
                HandleErrors(gameResponse, x);
            }
            return gameResponse;
        }

        #endregion
    }
}
