using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnionPattern.Domain.DataTransferObjects.Game.Input;
using OnionPattern.Domain.Services.Requests.Game.Async;

namespace OnionPattern.Api.Controllers.Game
{
    /// <inheritdoc />
    /// <summary>
    /// Async version of Game Controller
    /// </summary>
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class GamesAsyncController : BaseAsyncController
    {
        private readonly IGameRequestAggregateAsync gameRequestAggregateAsync;

        /// <summary>
        /// Video Games Controller
        /// </summary>
        /// <param name="gameRequestAggregateAsync"></param>
        public GamesAsyncController(IGameRequestAggregateAsync gameRequestAggregateAsync)
        {
            this.gameRequestAggregateAsync = gameRequestAggregateAsync ?? throw new ArgumentNullException($"{nameof(gameRequestAggregateAsync)} cannot be null.");
        }

        /// <summary>
        /// Get a list of all games.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await ExecuteAndHandleRequestAsync(() => gameRequestAggregateAsync.GetAllGamesRequestAsync.ExecuteAsync());
        }

        /// <summary>
        /// Get a Game by Id
        /// </summary>
        /// <param name="id">Id of the Game.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return await ExecuteAndHandleRequestAsync(() => gameRequestAggregateAsync.GetGameByIdRequestAsync.ExecuteAsync(id));
        }

        /// <summary>
        /// Gets a list of games associated with a genre.
        /// </summary>
        /// <param name="genre">The Genre to filter by.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("ByGenre/{genre}")]
        public async Task<IActionResult> Get(string genre)
        {
            return await ExecuteAndHandleRequestAsync(() => gameRequestAggregateAsync.GetGamesByGenreRequestAsync.ExecuteAsync(genre));
        }

        /// <summary>
        /// Creates a new Game Entry
        /// </summary>
        /// <param name="game">Create Game Information</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create/")]
        public async Task<IActionResult> Post(CreateGameInputDto game)
        {
            return await ExecuteAndHandleRequestAsync(() => gameRequestAggregateAsync.CreateGameRequestAsync.ExecuteAsync(game));
        }

        /// <summary>
        /// Update a Game Title by it's Id.
        /// </summary>
        /// <param name="input">Update Inputs</param>
        /// <returns></returns>
        [HttpPut]
        [Route("Update/")]
        public async Task<IActionResult> Put(UpdateGameTitleInputDto input)
        {
            return await ExecuteAndHandleRequestAsync(() => gameRequestAggregateAsync.UpdateGameTitleRequestAsync.ExecuteAsync(input));
        }

        /// <summary>
        /// Delete a Game by it's Id
        /// </summary>
        /// <param name="id">Id of the Game</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await ExecuteAndHandleRequestAsync(() => gameRequestAggregateAsync.DeleteGameByIdRequestAsync.ExecuteAsync(id));
        }
    }
}
