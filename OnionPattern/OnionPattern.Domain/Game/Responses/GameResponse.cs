using OnionPattern.Domain.Errors;

namespace OnionPattern.Domain.Game.Responses
{
    public class GameResponse : IError
    {
        public Entities.Game Game { get; set; }

        #region Implementation of IError

        public ErrorResponse ErrorResponse { get; set; }
        public int? StatusCode { get; set; }

        #endregion
    }
}
