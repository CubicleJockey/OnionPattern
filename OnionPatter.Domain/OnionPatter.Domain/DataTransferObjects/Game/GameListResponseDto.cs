using OnionPattern.Domain.Errors;
using System.Collections.Generic;

namespace OnionPattern.Domain.DataTransferObjects.Game
{
    public class GameListResponseDto : ErrorDetails
    {
        public IEnumerable<IGame> Games { get; set; }
    }
}
