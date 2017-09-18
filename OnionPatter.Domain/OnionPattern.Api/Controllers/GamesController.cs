using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Services;
using OnionPattern.Service.Responses;

namespace OnionPattern.Api.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Games Controller
    /// </summary>
    [Route("api/v1/[controller]")]
    public class GamesController : Controller
    {
        private IServiceRequest<Game, GetAllGamesResponse> GetAllGamesRequest { get; }

        /// <summary>
        /// Video Games Controller
        /// </summary>
        /// <param name="getAllGamesRequest">Get All Games Request</param>
        public GamesController(IServiceRequest<Game, GetAllGamesResponse> getAllGamesRequest)
        {
            GetAllGamesRequest = getAllGamesRequest ?? throw new ArgumentNullException($"{nameof(getAllGamesRequest)} cannot be null.");
        }
        
        /// <summary>
        /// Get a list of all games.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Game>> Get()
        {
            var response = await GetAllGamesRequest.Execute();
            return response.Games;
        }
    }
}
