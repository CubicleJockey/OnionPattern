using OnionPattern.Domain.Errors;
using System;

namespace OnionPattern.Service
{
    public abstract class ServiceHandleError
    {
        protected void HandleErrors(ErrorDetail detail, Exception x)
        {
            detail.StatusCode = 500;
            detail.ErrorSummary = x.Message;
            detail.InnerException = x.InnerException;
        }
    }
}
