using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnionPattern.Domain.Services.Requests.Game;

namespace OnionPattern.Api.Controllers
{
    /// <summary>
    /// Async version of Game Controller
    /// </summary>
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class GamesAsyncController
    {
        private IGetAllGamesRequestAsync GetAllGamesRequestAsync { get; }

        /// <summary>
        /// Video Games Controller
        /// </summary>
        /// <param name="getAllGamesRequest">Get All Games Request</param>
        public GamesAsyncController(IGetAllGamesRequestAsync getAllGamesRequest)
        {
            GetAllGamesRequestAsync = getAllGamesRequest ?? throw new ArgumentNullException($"{nameof(getAllGamesRequest)} cannot be null.");
        }

        /// <summary>
        /// Get a list of all games.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await GetAllGamesRequestAsync.Execute();
            return new ObjectResult(response.Games) { StatusCode = response.StatusCode };
        }
    }
}
