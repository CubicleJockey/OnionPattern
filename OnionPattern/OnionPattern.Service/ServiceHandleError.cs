using OnionPattern.Domain.Errors;
using System;

namespace OnionPattern.Service
{
    public abstract class ServiceHandleError
    {
        protected const string EXCEPTION_MESSAGE_TEMPLATE = "{Message}";

        /// <summary>
        /// Fill in Error Details.
        /// </summary>
        /// <param name="error">ErrorDetails Object</param>
        /// <param name="message">The Exception</param>
        /// <param name="statusCode">IFF ErrorDetail.StatusCode is null will it use this parameter.</param>
        protected void HandleErrors(IError error, Exception message, int statusCode = 500)
        {
            if (!error.StatusCode.HasValue)
            {
                error.StatusCode = statusCode;
            }
            error.ErrorResponse.ErrorSummary = message.Message;
            error.ErrorResponse.InnerException = message.InnerException;
        }
    }
}
