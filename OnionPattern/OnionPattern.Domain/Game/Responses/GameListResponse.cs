using System.Collections.Generic;
using System.Linq;
using OnionPattern.Domain.Errors;
using OnionPattern.Domain.Responses;

namespace OnionPattern.Domain.Game.Responses
{
    public class GameListResponse : IError, IListResponse
    {
        public IEnumerable<IGame> Games { get; set; }

        #region Implementation of IListResponse

        public int Count => Games?.Count() ?? 0;

        #endregion

        #region Implementation of IError

        public ErrorResponse ErrorResponse { get; set; }
        public int? StatusCode { get; set; }

        #endregion
    }
}
