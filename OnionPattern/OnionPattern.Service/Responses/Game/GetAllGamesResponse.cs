using OnionPattern.Domain.DataTransferObjects.Game;
using System.Collections.Generic;

namespace OnionPattern.Service.Responses.Game
{
    public class GetAllGamesResponse
    {
        public IEnumerable<IGame> Games { get; set; }
    }
}
