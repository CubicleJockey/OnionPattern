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
        /// Execute and Handle the Request
        /// </summary>
        /// <typeparam name="TReturn">Return Type of the Action</typeparam>
        /// <param name="action">Action to Execute</param>
        /// <returns>IActionResult</returns>
        protected virtual async Task<IActionResult> ExecuteAndHandleRequestAsync<TReturn>(Func<Task<TReturn>> action) where TReturn : ErrorDetail
        {
            var response = await action();
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
