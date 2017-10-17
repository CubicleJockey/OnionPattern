using System;
using OnionPattern.Domain.Interfaces;

namespace OnionPattern.Domain.DataTransferObjects.Platform
{
    public class PlatformResponseDto : IPlatform
    {
        #region Implementation of IPlatform

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }

        #endregion
    }
}
