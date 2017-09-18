using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Repository;

namespace OnionPattern.Api.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Games Controller
    /// </summary>
    [Route("api/v1/[controller]")]
    public class VideoGamesController : Controller
    {
        private IMediator mediator;
        private IRepository<Game> gamesRepository;
        private IRepository<Platform> platfomsRepository;

        /// <summary>
        /// Video Games Controller
        /// </summary>
        /// <param name="mediator">Mediator Request/Response system</param>
        /// <param name="gamesRepository">Games Repository</param>
        /// <param name="platformRepository">Platforms Repository</param>
        public VideoGamesController(IMediator mediator, IRepository<Game> gamesRepository, IRepository<Platform> platformRepository)
        {
            this.mediator = mediator;
            this.gamesRepository = gamesRepository;
            this.platfomsRepository = platformRepository;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
