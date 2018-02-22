using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnionPattern.Domain.Platform.Requests;
using OnionPattern.Domain.Services.Requests.Platform.Async;

namespace OnionPattern.Api.Controllers.Platform
{
    /// <inheritdoc />
    /// <summary>
    /// Async version of the Platform Controller
    /// </summary>
    [ApiVersion("1")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PlatfomsAsyncController : BaseAsyncController
    {
        private IPlatformRequestAsyncAggregate RequestAsyncAggregate { get; }

        /// <inheritdoc />
        /// <summary>
        /// Ctor
        /// </summary>
        /// <exception cref="ArgumentNullException">Condition.</exception>
        public PlatfomsAsyncController(IPlatformRequestAsyncAggregate requestAsyncAggregate)
        {
            RequestAsyncAggregate = requestAsyncAggregate ?? throw new ArgumentNullException(nameof(requestAsyncAggregate));
        }

        /// <summary>
        /// Get All Platforms
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("all")]
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
        [Route("get/{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return await ExecuteAndHandleRequestAsync(() => RequestAsyncAggregate.GetPlatformByIdRequestAsync.ExecuteAsync(id));
        }

        /// <summary>
        /// Creates a Platform
        /// </summary>
        /// <param name="input">Inputs to create a Platform.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create/")]
        public async Task<IActionResult> Post(CreatePlatformInput input)
        {
            return await ExecuteAndHandleRequestAsync(() => RequestAsyncAggregate.CreatePlatformRequestAsync.ExecuteAsync(input));
        }

        /// <summary>
        /// Updates Platforms Name by it's Id
        /// </summary>
        /// <param name="input">Id and NewName for updating.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateName/")]
        public async Task<IActionResult> Put(UpdatePlatformNameInput input)
        {
            return await ExecuteAndHandleRequestAsync(() => RequestAsyncAggregate.UpdatePlatformNameRequestAsync.ExecuteAsync(input));
        }
        /// <summary>
        /// Delete Platform by it's id.
        /// </summary>
        /// <param name="id">Id of the Platform</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await ExecuteAndHandleRequestAsync(() => RequestAsyncAggregate.DeletePlatformByIdRequestAsync.ExecuteAsync(id));
        }
    }
}
