using System;

namespace OnionPattern.Domain.Errors
{
    /// <summary>
    /// Response Error Message Object
    /// </summary>
    public abstract class ErrorDetail
    {
        /// <summary>
        /// Response Status Code
        /// </summary>
        public int? StatusCode { get; set; } = 500;

        /// <summary>
        /// Response Error Code. optional
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Error Summary should be a single sentence.
        /// </summary>
        public string ErrorSummary { get; set; }

        /// <summary>
        /// Link to more error information. optional
        /// </summary>
        public string ErrorLink { get; set; }

        /// <summary>
        /// List of Error causes. optional
        /// </summary>
        public ErrorCause[] ErrorCauses { get; set; }

        public Exception InnerException { get; set; }
    }
}
