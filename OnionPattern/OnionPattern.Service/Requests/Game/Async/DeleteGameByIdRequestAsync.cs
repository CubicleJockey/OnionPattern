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
                Log.Information($"Deleting Game by Id:[{id}]...");
                var toDelete = await Repository.SingleOrDefaultAsync(game => game.Id == id);
                if (toDelete == null)
                {
                    var exception = new Exception($"No Game found for Id:[{id}].");
                    HandleErrors(gameResponse, exception, 404);
                }
                else
                {
                    #region Delete GamePlatform References

                    Log.Information($"Retrieving GamePlatoforms for Game: [{toDelete.Name}] with Id: [{toDelete.Id}].");
                    var gamePlatforms = (await RepositoryAggregate.GamePlatforms.FindAsync(gp => gp.Id == id))?.ToArray();
                    if (gamePlatforms != null && gamePlatforms.Any())
                    {
                        Log.Information($"Deleting [{gamePlatforms.Length}] GamePlatforms for Game: [{toDelete.Name}]...");
                        foreach (var gp in gamePlatforms)
                        {
                            await RepositoryAggregate.GamePlatforms.DeleteAsync(gp);
                        }
                        Log.Information($"Finished deleting GamePlatform enteries. Procceeding to delete Game: {toDelete.Name} with Id: [{toDelete.Id}].");
                    }

                    #endregion Delete GamePlatform References

                    gameResponse = Mapper.Map<Domain.Entities.Game, GameResponseDto>(await Repository.DeleteAsync(toDelete));
                    gameResponse.StatusCode = 200;
                    Log.Information($"Deleted Game [{toDelete.Name}] for Id:[{toDelete.Id}].");
                }
            }
            catch (Exception x)
            {
                Log.Error($"Failed to Delete Game. [{x.Message}].");
                HandleErrors(gameResponse, x);
            }
            return gameResponse;
        }

        #endregion
    }
}
