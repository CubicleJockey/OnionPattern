using Microsoft.AspNetCore.Mvc;
using OnionPattern.Domain.Services.Requests.Game.Async;
using System;
using System.Threading.Tasks;

namespace OnionPattern.Api.Controllers
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
            return await ExecuteAndHandleRequestAsync(() => gameRequestAggregateAsync.GetAllGamesRequestAsync.Execute());
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
            return await ExecuteAndHandleRequestAsync(() => gameRequestAggregateAsync.GetGameByIdRequestAsync.Execute(id));
        }
    }
}
