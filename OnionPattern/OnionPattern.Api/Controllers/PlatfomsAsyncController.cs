using Microsoft.AspNetCore.Mvc;
using OnionPattern.Domain.Services.Requests.Platform.Async;
using System;
using System.Threading.Tasks;

namespace OnionPattern.Api.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Async version of the Platform Controller
    /// </summary>
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class PlatfomsAsyncController : BaseAsyncController
    {
        private IPlatformRequestAsyncAggregate requestAsyncAggregate { get; }

        /// <summary>
        /// Ctor
        /// </summary>
        public PlatfomsAsyncController(IPlatformRequestAsyncAggregate requestAsyncAggregate)
        {
            this.requestAsyncAggregate = requestAsyncAggregate ?? throw new ArgumentNullException($"{nameof(requestAsyncAggregate)} cannot be null.");
        }

        /// <summary>
        /// Get All Platforms
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await ExecuteAndHandleRequestAsync(() => requestAsyncAggregate.GetAllPlatformsRequestAsync.Execute());
        }
    }
}
