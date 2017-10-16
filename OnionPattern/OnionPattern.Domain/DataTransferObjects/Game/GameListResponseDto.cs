using OnionPattern.Domain.Errors;
using System.Collections.Generic;
using System.Linq;
using OnionPattern.Domain.Interfaces;

namespace OnionPattern.Domain.DataTransferObjects.Game
{
    public class GameListResponseDto : ErrorDetail, IListResponseDto
    {
        public IEnumerable<IGame> Games { get; set; } = new List<IGame>();

        #region Implementation of IListResponseDto

        public int Count => Games.Count();

        #endregion
    }
}
