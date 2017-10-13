using OnionPattern.Domain.Errors;
using System;

namespace OnionPattern.Service
{
    public abstract class ServiceHandleError
    {
        /// <summary>
        /// Fill in Error Details.
        /// </summary>
        /// <param name="detail">ErrorDetails Object</param>
        /// <param name="x">The Exception</param>
        /// <param name="statusCode">IFF ErrorDetail.StatusCode is null will it use this parameter.</param>
        protected void HandleErrors(ErrorDetail detail, Exception x, int statusCode = 500)
        {
            if (!detail.StatusCode.HasValue)
            {
                detail.StatusCode = statusCode;
            }
            detail.ErrorSummary = x.Message;
            detail.InnerException = x.InnerException;
        }
    }
}
