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
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PlatfomsAsyncController : BaseAsyncController
    {
        private IPlatformRequestAsyncAggregate RequestAsyncAggregate { get; }

        /// <inheritdoc />
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

        /// <summary>
        /// Creates a Platform
        /// </summary>
        /// <param name="input">Inputs to create a Platform.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create/")]
        public async Task<IActionResult> Post(CreatePlatformInputDto input)
        {
            return await ExecuteAndHandleRequestAsync(() => RequestAsyncAggregate.CreatePlatformRequestAsync.ExecuteAsync(input));
        }

        /// <summary>
        /// Updates the Name of a Platform of a given id.
        /// </summary>
        /// <param name="input">Inputs required to update the name of a platform.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("Update/")]
        public async Task<IActionResult> Put(UpdatePlatformNameInputDto input)
        {
            return await ExecuteAndHandleRequestAsync(() => RequestAsyncAggregate.UpdatePlatformNameRequestAsync.ExecuteAsync(input));
        }
    }
}
