using OnionPattern.Domain.Errors;
using System.Collections.Generic;

namespace OnionPattern.Domain.DataTransferObjects.Platform
{
    public class PlatformListResponseDto : ErrorDetails
    {
        public IEnumerable<IPlatform> Platforms { get; set; }
    }
}
