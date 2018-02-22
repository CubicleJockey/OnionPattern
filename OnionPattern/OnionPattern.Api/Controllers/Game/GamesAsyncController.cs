using static System.Console;

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnionPattern.Domain.Game.Requests;
using OnionPattern.Domain.Services.Requests.Game.Async;

namespace OnionPattern.Api.Controllers.Game
{
    /// <inheritdoc />
    /// <summary>
    /// Async version of Game Controller
    /// </summary>
    [ApiVersion("1")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class GamesAsyncController : BaseAsyncController
    {
        private readonly IGameRequestAggregateAsync GameRequestAggregateAsync;

        /// <inheritdoc />
        /// <summary>
        /// Video Games Controller
        /// </summary>
        /// <param name="gameRequestAggregateAsync"></param>
        public GamesAsyncController(IGameRequestAggregateAsync gameRequestAggregateAsync)
        {
            GameRequestAggregateAsync = gameRequestAggregateAsync ?? throw new ArgumentNullException(nameof(gameRequestAggregateAsync));
        }

        /// <summary>
        /// Get a list of all games.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> Get()
        {
            return await ExecuteAndHandleRequestAsync(() => GameRequestAggregateAsync.GetAllGamesRequestAsync.ExecuteAsync());
        }

        /// <summary>
        /// Get a Game by Id
        /// </summary>
        /// <param name="id">Id of the Game.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("get/{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return await ExecuteAndHandleRequestAsync(() => GameRequestAggregateAsync.GetGameByIdRequestAsync.ExecuteAsync(id));
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
            return await ExecuteAndHandleRequestAsync(() => GameRequestAggregateAsync.GetGamesByGenreRequestAsync.ExecuteAsync(genre));
        }

        /// <summary>
        /// Creates a new Game Entry
        /// </summary>
        /// <param name="game">Create Game Information</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create/")]
        public async Task<IActionResult> Post(CreateGameInput game)
        {
            return await ExecuteAndHandleRequestAsync(() => GameRequestAggregateAsync.CreateGameRequestAsync.ExecuteAsync(game));
        }

        /// <summary>
        /// Update a Game Title by it's Id.
        /// </summary>
        /// <param name="input">Update Inputs</param>
        /// <returns></returns>
        [HttpPut]
        [Route("Update/")]
        public async Task<IActionResult> Put(UpdateGameTitleInput input)
        {
            return await ExecuteAndHandleRequestAsync(() => GameRequestAggregateAsync.UpdateGameTitleRequestAsync.ExecuteAsync(input));
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
            return await ExecuteAndHandleRequestAsync(() => GameRequestAggregateAsync.DeleteGameByIdRequestAsync.ExecuteAsync(id));
        }
    }
}
