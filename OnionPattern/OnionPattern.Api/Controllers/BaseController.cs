using System;
using Microsoft.AspNetCore.Mvc;
using OnionPattern.Domain.Errors;

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
        protected virtual IActionResult ExecuteAndHandleRequest<TReturn>(Func<TReturn> action) where TReturn : ErrorDetail
        {
            var response = action();
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
