using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnionPattern.Domain.Services.Requests.Platform;

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
        private IGetAllPlatformsRequestAsync GetAllPlatformsRequest { get; }

        /// <summary>
        /// Ctor
        /// </summary>
        public PlatfomsAsyncController(IGetAllPlatformsRequestAsync getAllPlatformsRequest)
        {
            GetAllPlatformsRequest = getAllPlatformsRequest ?? throw new ArgumentNullException($"{nameof(getAllPlatformsRequest)} cannot be null.");
        }

        /// <summary>
        /// Get All Platforms
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await ExecuteAndHandleRequestAsync(() => GetAllPlatformsRequest.Execute());
        }
    }
}
