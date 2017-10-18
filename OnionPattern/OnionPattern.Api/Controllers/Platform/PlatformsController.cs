using System;
using Microsoft.AspNetCore.Mvc;
using OnionPattern.Domain.Services.Requests.Platform;

namespace OnionPattern.Api.Controllers.Platform
{
    /// <inheritdoc />
    /// <summary>
    /// Platform Controller
    /// </summary>
    [Route("api/v1/[controller]")]
    public class PlatformsController : BaseController
    {
        private readonly IPlatformRequestAggregate requestAggregate;

        /// <summary>
        /// Ctor
        /// </summary>
        public PlatformsController(IPlatformRequestAggregate requestAggregate)
        {
            this.requestAggregate = requestAggregate ?? throw new ArgumentNullException($"{nameof(requestAggregate)} cannot be null.");
        }

        /// <summary>
        /// Get All Platforms
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return ExecuteAndHandleRequest(() => requestAggregate.GetAllPlatformsRequest.Execute());
        }

        /// <summary>
        /// Get A Platform by it's id.
        /// </summary>
        /// <param name="id">Id of the Platform</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            return ExecuteAndHandleRequest(() => requestAggregate.GetPlatformByIdRequest.Execute(id));
        }
    }
}
