using AutoMapper;
using OnionPattern.Domain.DataTransferObjects.Platform;
using System;

namespace OnionPattern.Mapping.Platform
{
    public class PlatformToPlatformResponseDtoTypeConverter : ITypeConverter<Domain.Entities.Platform, PlatformResponseDto>
    {
        #region Implementation of ITypeConverter<in Platform,PlatformResponseDto>

        public PlatformResponseDto Convert(Domain.Entities.Platform source, PlatformResponseDto destination, ResolutionContext context)
        {
            if (source == null) {  throw new ArgumentNullException($"{nameof(source)} cannot be null."); }
            if (destination == null) { destination = new PlatformResponseDto(); }

            destination.Id = source.Id;
            destination.Name = source.Name;
            destination.ReleaseDate = source.ReleaseDate;

            return destination;
        }

        #endregion
    }
}
