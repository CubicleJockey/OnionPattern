using OnionPattern.Domain.DataTransferObjects.Platform;
using System.Collections.Generic;

namespace OnionPattern.Service.Responses.Platform
{
    public class GetAllPlatformsResponse
    {
        public IEnumerable<IPlatform> Platforms { get; set; }
    }
}
