using Microsoft.AspNetCore.Mvc;
using OnionPattern.Domain.DataTransferObjects.Game;
using OnionPattern.Domain.Services.Requests.Game;
using System;
using System.Collections.Generic;

namespace OnionPattern.Api.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Games Controller
    /// </summary>
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
        public IEnumerable<IGame> Get()
        {
            var response = GetAllGamesRequest.Execute();
            return response.Games;
        }
    }
}
