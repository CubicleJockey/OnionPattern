using OnionPattern.Domain.Errors;

namespace OnionPattern.Domain.Platform.Responses
{
    public class PlatformResponse : IError
    {
        public Domain.Platform.Entities.Platform Platform { get; set; }

        #region Implementation of IError

        public ErrorResponse ErrorResponse { get; set; }
        public int? StatusCode { get; set; }

        #endregion
    }
}
