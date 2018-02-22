using System.Collections.Generic;
using System.Linq;
using OnionPattern.Domain.Errors;
using OnionPattern.Domain.Responses;

namespace OnionPattern.Domain.Platform.Responses
{
    public class PlatformListResponse : IError, IListResponse
    {
        public IEnumerable<IPlatform> Platforms { get; set; }

        #region Implementation of IListResponse

        public int Count => Platforms?.Count() ?? 0;

        #endregion

        #region Implementation of IError

        public ErrorResponse ErrorResponse { get; set; }
        public int? StatusCode { get; set; }

        #endregion
    }
}
