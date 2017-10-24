using Microsoft.AspNetCore.Mvc;
using OnionPattern.Domain.Errors;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

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
        protected virtual async Task<IActionResult> ExecuteAndHandleRequestAsync<TReturn>(Func<Task<TReturn>> action) where TReturn : ErrorDetail
        {
            var response = await action();
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        /// <summary>
        /// Log which version of the controller is being called on what method.
        /// </summary>
        /// <param name="controllerName">Controller Name</param>
        /// <param name="callingMethod">Calling Method Name</param>
        protected void LogApiVersion(string controllerName, string callingMethod)
        {
            Log.Information("{ControllerName} requested Api-Version is [{GetRequestedApiVersion}].", controllerName, HttpContext.GetRequestedApiVersion());
        }
    }
}
