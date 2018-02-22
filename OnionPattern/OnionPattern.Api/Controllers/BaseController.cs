using System;
using Microsoft.AspNetCore.Mvc;
using OnionPattern.Domain.Errors;
using Serilog;

namespace OnionPattern.Api.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Base Controller with Common Actions
    /// </summary>
    public abstract class BaseController : Controller
    {
        /// <summary>
        /// ExecuteAsync and Handle the Request
        /// </summary>
        /// <typeparam name="TReturn">Return Type of the Action</typeparam>
        /// <param name="action">Action to ExecuteAsync</param>
        /// <returns>IActionResult</returns>
        protected virtual IActionResult ExecuteAndHandleRequest<TReturn>(Func<TReturn> action) where TReturn : IError
        {
            var response = action();
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        /// <summary>
        /// Log which version of the controller is being called on what method.
        /// </summary>
        /// <param name="controllerName">Controller Name</param>
        protected IActionResult ApiVersion(string controllerName)
        {
            var content = $"{controllerName} requested Api-Version is [{HttpContext.GetRequestedApiVersion()}].";
            return Ok(content);
        }
    }
}
