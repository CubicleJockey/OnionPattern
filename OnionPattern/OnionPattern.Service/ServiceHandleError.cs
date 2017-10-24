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
        /// <param name="detail">ErrorDetails Object</param>
        /// <param name="message">The Exception</param>
        /// <param name="statusCode">IFF ErrorDetail.StatusCode is null will it use this parameter.</param>
        protected void HandleErrors(ErrorDetail detail, Exception message, int statusCode = 500)
        {
            if (!detail.StatusCode.HasValue)
            {
                detail.StatusCode = statusCode;
            }
            detail.ErrorSummary = message.Message;
            detail.InnerException = message.InnerException;
        }
    }
}
