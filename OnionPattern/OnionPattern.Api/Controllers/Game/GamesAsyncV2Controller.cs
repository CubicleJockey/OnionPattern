using static System.Console;

using Microsoft.AspNetCore.Mvc;
using OnionPattern.Domain.Services.Requests.Game.Async;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OnionPattern.Api.Controllers.Game
{
    /// <inheritdoc />
    /// <summary>
    /// Example of a versioned controller.
    /// </summary>
    [ApiVersion("2")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/GamesAsync")]
    public class GamesAsyncV2Controller : BaseAsyncController
    {
        private readonly IGameRequestAggregateAsync gameRequestAggregateAsync;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="gameRequestAggregateAsync"></param>
        public GamesAsyncV2Controller(IGameRequestAggregateAsync gameRequestAggregateAsync)
        {
            this.gameRequestAggregateAsync = gameRequestAggregateAsync ?? throw new ArgumentNullException(nameof(gameRequestAggregateAsync));
        }

        /// <summary>
        /// Get a Game by Id,
        /// 
        /// This method is just to show a different version of an Api
        /// </summary>
        /// <param name="id">Id of the Game.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var getByIdTask = ExecuteAndHandleRequestAsync(() => gameRequestAggregateAsync.GetGameByIdRequestAsync.ExecuteAsync(id));

            Thread.Sleep(5000);
            WriteLine("Do something while we wait for response.");

            return await getByIdTask;
        }
    }
}
