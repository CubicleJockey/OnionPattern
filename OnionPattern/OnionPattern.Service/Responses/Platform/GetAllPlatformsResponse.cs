using OnionPattern.Domain.DataTransferObjects.Platform;
using System.Collections.Generic;
using OnionPattern.Domain.Interfaces;

namespace OnionPattern.Service.Responses.Platform
{
    public class GetAllPlatformsResponse
    {
        public IEnumerable<IPlatform> Platforms { get; set; }
    }
}
