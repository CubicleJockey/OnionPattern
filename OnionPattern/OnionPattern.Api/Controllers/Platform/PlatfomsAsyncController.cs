using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnionPattern.Domain.DataTransferObjects.Platform.Input;
using OnionPattern.Domain.Services.Requests.Platform.Async;

namespace OnionPattern.Api.Controllers.Platform
{
    /// <inheritdoc />
    /// <summary>
    /// Async version of the Platform Controller
    /// </summary>
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class PlatfomsAsyncController : BaseAsyncController
    {
        private IPlatformRequestAsyncAggregate RequestAsyncAggregate { get; }

        /// <summary>
        /// Ctor
        /// </summary>
        public PlatfomsAsyncController(IPlatformRequestAsyncAggregate requestAsyncAggregate)
        {
            RequestAsyncAggregate = requestAsyncAggregate ?? throw new ArgumentNullException(nameof(requestAsyncAggregate));
        }

        /// <summary>
        /// Get All Platforms
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await ExecuteAndHandleRequestAsync(() => RequestAsyncAggregate.GetAllPlatformsRequestAsync.ExecuteAsync());
        }

        /// <summary>
        /// Get A Platform by it's id.
        /// </summary>
        /// <param name="id">Id of the Platform</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return await ExecuteAndHandleRequestAsync(() => RequestAsyncAggregate.GetPlatformByIdRequestAsync.ExecuteAsync(id));
        }

        [HttpPost]
        [Route("Create/")]
        public async Task<IActionResult> Post(CreatePlatformInputDto input)
        {
            return await ExecuteAndHandleRequestAsync(() => RequestAsyncAggregate.CreatePlatformRequestAsync.ExecuteAsync(input));
        }
    }
}
