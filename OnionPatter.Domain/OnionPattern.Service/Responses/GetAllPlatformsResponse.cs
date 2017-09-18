using System.Collections.Generic;
using OnionPattern.Domain.Entities;

namespace OnionPattern.Service.Responses
{
    public class GetAllPlatformsResponse
    {
        public IEnumerable<Platform> Platforms { get; set; }
    }
}
