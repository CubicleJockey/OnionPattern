using System;
using Microsoft.AspNetCore.Mvc;
using OnionPattern.Domain.DataTransferObjects.Platform.Input;
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
            this.requestAggregate = requestAggregate ?? throw new ArgumentNullException(nameof(requestAggregate));
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

        /// <summary>
        /// Creates a Platform
        /// </summary>
        /// <param name="input">Input values needed to create a Platform.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create/")]
        public IActionResult Post(CreatePlatformInputDto input)
        {
            return ExecuteAndHandleRequest(() => requestAggregate.CreatePlatformRequest.Execute(input));
        }

        /// <summary>
        /// Delete Platform by it's id.
        /// </summary>
        /// <param name="id">Id of the Platform</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            return ExecuteAndHandleRequest(() => requestAggregate.DeletePlatformByIdRequest.Execute(id));
        }

        /// <summary>
        /// Updates Platforms Name by it's Id
        /// </summary>
        /// <param name="input">Id and NewName for updating.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateName/")]
        public IActionResult Put(UpdatePlatformNameInputDto input)
        {
            return ExecuteAndHandleRequest(() => requestAggregate.UpdatePlatformNameRequest.Execute(input));
        }
    }
}
