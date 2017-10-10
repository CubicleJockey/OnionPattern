using Microsoft.AspNetCore.Mvc;
using OnionPattern.Domain.Services.Requests.Game;
using System;
using OnionPattern.Domain.DataTransferObjects.Game;
using OnionPattern.Domain.Errors;

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
        private IGetGameByIdRequest GetGameByIdRequest { get; }
        private ICreateGameRequest CreateGameRequest { get; }
        private IDeleteGameByIdRequest DeleteGameByIdRequest { get; }

        /// <summary>
        /// Video Games Controller
        /// </summary>
        /// <param name="getAllGamesRequest">Get All Games Request</param>
        /// <param name="getGameByIdRequest">Get Game By Name Request</param>
        /// <param name="createGameRequest"></param>
        /// <param name="deleteGameByIdRequest">Delete Game by Id</param>
        public GamesController(IGetAllGamesRequest getAllGamesRequest, 
                               IGetGameByIdRequest getGameByIdRequest, 
                               ICreateGameRequest createGameRequest,
                               IDeleteGameByIdRequest deleteGameByIdRequest)
        {
            GetAllGamesRequest = getAllGamesRequest ?? throw new ArgumentNullException($"{nameof(getAllGamesRequest)} cannot be null.");
            GetGameByIdRequest = getGameByIdRequest ?? throw new ArgumentNullException($"{nameof(getGameByIdRequest)} cannot be null.");
            CreateGameRequest = createGameRequest ??throw new ArgumentNullException($"{nameof(createGameRequest)} cannot be null.");
            DeleteGameByIdRequest = deleteGameByIdRequest ?? throw new ArgumentNullException($"{nameof(deleteGameByIdRequest)} cannot be null.");
        }
        
        /// <summary>
        /// Get a list of all games.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var response = GetAllGamesRequest.Execute();
            return new ObjectResult(response.Games) { StatusCode = response.StatusCode };
        }

        /// <summary>
        /// Get a Game by it's Name/Title
        /// </summary>
        /// <param name="id">Id of the Game.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var response = GetGameByIdRequest.Execute(id);
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        /// <summary>
        /// Creates a new Game Entry
        /// </summary>
        /// <param name="game">Create Game Information</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create/")]
        public IActionResult Post(CreateGameDto game)
        {
            var response = CreateGameRequest.Execute(game);
            return new ObjectResult(response){ StatusCode = response.StatusCode };
        }

        /// <summary>
        /// Delete a Game by it's Id
        /// </summary>
        /// <param name="id">Id of the Game</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var response = DeleteGameByIdRequest.Execute(id);
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
