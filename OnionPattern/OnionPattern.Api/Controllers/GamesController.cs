using Microsoft.AspNetCore.Mvc;
using OnionPattern.Domain.DataTransferObjects.Game;
using OnionPattern.Domain.Services.Requests.Game;
using System;
using OnionPattern.Domain.DataTransferObjects.Game.Input;

namespace OnionPattern.Api.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Games Controller
    /// </summary>
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class GamesController : BaseController
    {
        private IGetAllGamesRequest GetAllGamesRequest { get; }
        private IGetGameByIdRequest GetGameByIdRequest { get; }
        private ICreateGameRequest CreateGameRequest { get; }
        private IUpdateGameRequest UpdateGameRequest { get; }
        private IDeleteGameByIdRequest DeleteGameByIdRequest { get; }

        /// <summary>
        /// Video Games Controller
        /// </summary>
        /// <param name="getAllGamesRequest">Get All Games Request</param>
        /// <param name="getGameByIdRequest">Get Game By Name Request</param>
        /// <param name="createGameRequest"></param>
        /// <param name="updateGameTitleRequest"></param>
        /// <param name="deleteGameByIdRequest">Delete Game by Id</param>
        public GamesController(IGetAllGamesRequest getAllGamesRequest, 
                               IGetGameByIdRequest getGameByIdRequest, 
                               ICreateGameRequest createGameRequest, 
                               IUpdateGameRequest updateGameTitleRequest, 
                               IDeleteGameByIdRequest deleteGameByIdRequest)
        {
            GetAllGamesRequest = getAllGamesRequest ?? throw new ArgumentNullException($"{nameof(getAllGamesRequest)} cannot be null.");
            GetGameByIdRequest = getGameByIdRequest ?? throw new ArgumentNullException($"{nameof(getGameByIdRequest)} cannot be null.");
            CreateGameRequest = createGameRequest ??throw new ArgumentNullException($"{nameof(createGameRequest)} cannot be null.");
            UpdateGameRequest = updateGameTitleRequest ?? throw new ArgumentNullException($"{nameof(updateGameTitleRequest)} cannot be null.");
            DeleteGameByIdRequest = deleteGameByIdRequest ?? throw new ArgumentNullException($"{nameof(deleteGameByIdRequest)} cannot be null.");
        }
        
        /// <summary>
        /// Get a list of all games.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return ExecuteAndHandleRequest(() => GetAllGamesRequest.Execute());
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
            return ExecuteAndHandleRequest(() => GetGameByIdRequest.Execute(id));
        }

        /// <summary>
        /// Creates a new Game Entry
        /// </summary>
        /// <param name="game">Create Game Information</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create/")]
        public IActionResult Post(CreateGameInputDto game)
        {
            return ExecuteAndHandleRequest(() => CreateGameRequest.Execute(game));
        }

        /// <summary>
        /// Update a Game Title by it's Id.
        /// </summary>
        /// <param name="input">Update Inputs</param>
        /// <returns></returns>
        [HttpPut]
        [Route("Update/")]
        public IActionResult Put(UpdateGameTitleInputDto input)
        {
            return ExecuteAndHandleRequest(() => UpdateGameRequest.Execute(input));
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
            return ExecuteAndHandleRequest(() => DeleteGameByIdRequest.Execute(id));
        }
    }
}
