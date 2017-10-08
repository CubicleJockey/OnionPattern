using Microsoft.AspNetCore.Mvc;
using OnionPattern.Domain.Services.Requests.Game;
using System;

namespace OnionPattern.Api.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Games Controller
    /// </summary>
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class GamesController : Controller
    {
        private IGetAllGamesRequest GetAllGamesRequest { get; }

        /// <summary>
        /// Video Games Controller
        /// </summary>
        /// <param name="getAllGamesRequest">Get All Games Request</param>
        public GamesController(IGetAllGamesRequest getAllGamesRequest)
        {
            GetAllGamesRequest = getAllGamesRequest ?? throw new ArgumentNullException($"{nameof(getAllGamesRequest)} cannot be null.");
        }
        
        /// <summary>
        /// Get a list of all games.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var response = GetAllGamesRequest.Execute();
            return new ObjectResult(response.Games) { StatusCode = 200 };
        }
    }
}
