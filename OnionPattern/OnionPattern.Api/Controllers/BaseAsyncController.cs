using Microsoft.AspNetCore.Mvc;
using OnionPattern.Domain.Errors;
using System;
using System.Threading.Tasks;

namespace OnionPattern.Api.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Base Async Controller for Common Methods
    /// </summary>
    public abstract class BaseAsyncController : Controller
    {
        /// <summary>
        /// ExecuteAsync and Handle the Request
        /// </summary>
        /// <typeparam name="TReturn">Return Type of the Action</typeparam>
        /// <param name="action">Action to ExecuteAsync</param>
        /// <returns>IActionResult</returns>
        protected virtual async Task<IActionResult> ExecuteAndHandleRequestAsync<TReturn>(Func<Task<TReturn>> action) where TReturn : IError
        {
            var response = await action();
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        /// <summary>
        /// Log which version of the controller is being called on what method.
        /// </summary>
        /// <param name="controllerName">Controller Name</param>
        protected async Task<IActionResult> ApiVersion(string controllerName)
        {
            var content = $"{controllerName} requested Api-Version is [{HttpContext.GetRequestedApiVersion()}].";
            return await Task.FromResult(Ok(content));
        }
    }
}
