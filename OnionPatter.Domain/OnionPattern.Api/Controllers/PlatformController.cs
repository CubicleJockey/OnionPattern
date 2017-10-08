using Microsoft.AspNetCore.Mvc;
using OnionPattern.Domain.DataTransferObjects.Platform;
using OnionPattern.Domain.Services.Requests.Platform;
using System;
using System.Collections.Generic;

namespace OnionPattern.Api.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Platform Controller
    /// </summary>
    [Route("api/v1/[controller]")]
    public class PlatformController : Controller
    {
        private IGetAllPlatformsRequest GetAllPlatformsRequest { get; }

        /// <summary>
        /// Ctor
        /// </summary>
        public PlatformController(IGetAllPlatformsRequest getAllPlatformsRequest)
        {
            GetAllPlatformsRequest = getAllPlatformsRequest ?? throw new ArgumentNullException($"{nameof(getAllPlatformsRequest)} cannot be null.");
        }

        /// <summary>
        /// Get All Platforms
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<IPlatform> Get()
        {
            var response = GetAllPlatformsRequest.Execute();
            return response.Platforms;
        }
    }
}
