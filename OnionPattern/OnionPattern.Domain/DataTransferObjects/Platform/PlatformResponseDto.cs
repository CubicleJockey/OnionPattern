using System;
using OnionPattern.Domain.Errors;
using OnionPattern.Domain.Interfaces;

namespace OnionPattern.Domain.DataTransferObjects.Platform
{
    public class PlatformResponseDto : ErrorDetail, IPlatform
    {
        #region Implementation of IPlatform

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }

        #endregion
    }
}
