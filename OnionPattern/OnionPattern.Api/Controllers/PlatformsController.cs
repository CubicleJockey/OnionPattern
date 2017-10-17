using Microsoft.AspNetCore.Mvc;
using OnionPattern.Domain.Services.Requests.Platform;
using System;

namespace OnionPattern.Api.Controllers
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
    }
}
