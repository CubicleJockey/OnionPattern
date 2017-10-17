using OnionPattern.Domain.DataTransferObjects.Game;
using System.Collections.Generic;
using OnionPattern.Domain.Interfaces;

namespace OnionPattern.Service.Responses.Game
{
    public class GetAllGamesResponse
    {
        public IEnumerable<IGame> Games { get; set; }
    }
}
