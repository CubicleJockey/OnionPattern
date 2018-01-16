using System;
using Microsoft.AspNetCore.Mvc;
using OnionPattern.Domain.DataTransferObjects.Game.Input;
using OnionPattern.Domain.Services.Requests.Game;

namespace OnionPattern.Api.Controllers.Game
{
    /// <inheritdoc />
    /// <summary>
    /// Games Controller
    /// </summary>
    [ApiVersion("1")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class GamesController : BaseController
    {
        private readonly IGameRequestAggregate GameRequestAggregate;

        /// <inheritdoc />
        /// <summary>
        /// Video Games Controller
        /// </summary>
        /// <param name="gameRequestAggregate"></param>
        public GamesController(IGameRequestAggregate gameRequestAggregate)
        {
            GameRequestAggregate = gameRequestAggregate ?? throw new ArgumentNullException(nameof(gameRequestAggregate));
        }

        /// <summary>
        /// Get a list of all games.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return ExecuteAndHandleRequest(() => GameRequestAggregate.GetAllGamesRequest.Execute());
        }

        /// <summary>
        /// Get a Game by it's NewName/Title
        /// </summary>
        /// <param name="id">Id of the Game.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return ExecuteAndHandleRequest(() => GameRequestAggregate.GetGameByIdRequest.Execute(id));
        }

        /// <summary>
        /// Gets a list of games associated with a genre.
        /// </summary>
        /// <param name="genre">The Genre to filter by.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("ByGenre/{genre}")]
        public IActionResult Get(string genre)
        {
            return ExecuteAndHandleRequest(() => GameRequestAggregate.GetGamesByGenreRequest.Execute(genre));
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
            return ExecuteAndHandleRequest(() => GameRequestAggregate.CreateGameRequest.Execute(game));
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
            return ExecuteAndHandleRequest(() => GameRequestAggregate.UpdateGameTitleRequest.Execute(input));
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
            return ExecuteAndHandleRequest(() => GameRequestAggregate.DeleteGameByIdRequest.Execute(id));
        }
    }
}
