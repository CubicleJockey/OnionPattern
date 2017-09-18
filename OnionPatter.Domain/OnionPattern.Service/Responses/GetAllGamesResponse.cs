using System.Collections.Generic;
using OnionPattern.Domain.Entities;

namespace OnionPattern.Service.Responses
{
    public class GetAllGamesResponse
    {
        public IEnumerable<Game> Games { get; set; }
    }
}
