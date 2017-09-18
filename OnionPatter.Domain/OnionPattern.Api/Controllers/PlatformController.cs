using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Services;
using OnionPattern.Service.Responses;

namespace OnionPattern.Api.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Platform Controller
    /// </summary>
    [Route("api/v1/[controller]")]
    public class PlatformController : Controller
    {
        private IServiceRequest<Platform, GetAllPlatformsResponse> GetAllPlatformsRequest { get; }

        /// <summary>
        /// Ctor
        /// </summary>
        public PlatformController(IServiceRequest<Platform, GetAllPlatformsResponse> getAllPlatformsRequest)
        {
            GetAllPlatformsRequest = getAllPlatformsRequest ?? throw new ArgumentNullException($"{nameof(getAllPlatformsRequest)} cannot be null.");
        }

        /// <summary>
        /// Get All Platforms
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Platform>> Get()
        {
            var response = await GetAllPlatformsRequest.Execute();
            return response.Platforms;
        }
    }
}
