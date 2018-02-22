using System;
using Newtonsoft.Json;

namespace OnionPattern.Domain.Errors
{
    /// <summary>
    /// Error Response
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// Process defined Error Code
        /// </summary>
        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Error summary statement.
        /// </summary>
        [JsonProperty("errorSummary")]
        public string ErrorSummary { get; set; }

        /// <summary>
        /// Link to error documentation
        /// </summary>
        [JsonProperty("errorLink")]
        public string ErrorLink { get; set; }

        /// <summary>
        /// Unique Error Id
        /// </summary>
        [JsonProperty("errorId")]
        public string ErrorId { get; set; }

        /// <summary>
        /// List of Error causes
        /// </summary>
        [JsonProperty("errorCauses")]
        public ErrorCause[] ErrorCauses { get; set; }

        [JsonProperty("innerException")]
        public Exception InnerException { get; set; }
    }
}
