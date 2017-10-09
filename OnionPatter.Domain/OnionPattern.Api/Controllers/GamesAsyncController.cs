using Microsoft.AspNetCore.Mvc;
using OnionPattern.Domain.Services.Requests.Game;
using System;
using System.Threading.Tasks;

namespace OnionPattern.Api.Controllers
{
    /// <summary>
    /// Async version of Game Controller
    /// </summary>
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class GamesAsyncController : Controller
    {
        private IGetAllGamesRequestAsync GetAllGamesRequestAsync { get; }
        private IGetGameByIdRequestAsync GetGameByIdRequestAsync { get; }

        /// <summary>
        /// Video Games Controller
        /// </summary>
        /// <param name="getAllGamesRequest">Get All Games Request</param>
        /// <param name="getGameByIdRequest"></param>
        public GamesAsyncController(IGetAllGamesRequestAsync getAllGamesRequest, IGetGameByIdRequestAsync getGameByIdRequest)
        {
            GetAllGamesRequestAsync = getAllGamesRequest ?? throw new ArgumentNullException($"{nameof(getAllGamesRequest)} cannot be null.");
            GetGameByIdRequestAsync = getGameByIdRequest ?? throw new ArgumentNullException($"{nameof(getGameByIdRequest)} cannot be null.");
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

        /// <summary>
        /// Get a Game by Id
        /// </summary>
        /// <param name="id">Id of the Game.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await GetGameByIdRequestAsync.Execute(id);
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
