using OnionPattern.Domain.Errors;
using System.Collections.Generic;
using System.Linq;
using OnionPattern.Domain.Interfaces;

namespace OnionPattern.Domain.DataTransferObjects.Platform
{
    public class PlatformListResponseDto : ErrorDetail, IListResponseDto
    {
        public IEnumerable<IPlatform> Platforms { get; set; } = new List<IPlatform>();

        #region Implementation of IListResponseDto

        public int Count => Platforms.Count();

        #endregion
    }
}
