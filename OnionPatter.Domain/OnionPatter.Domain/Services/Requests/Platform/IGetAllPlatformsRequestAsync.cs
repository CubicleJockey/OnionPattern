using System.Collections.Generic;
using System.Threading.Tasks;
using OnionPattern.Domain.DataTransferObjects.Platform;

namespace OnionPattern.Domain.Services.Requests.Platform
{
    public interface IGetAllPlatformsRequestAsync
    {
        Task<PlatformListResponseDto> Execute();
    }
}