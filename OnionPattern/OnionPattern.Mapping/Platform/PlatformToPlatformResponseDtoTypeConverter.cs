using AutoMapper;
using OnionPattern.Domain.DataTransferObjects.Platform;

namespace OnionPattern.Mapping.Platform
{
    public class PlatformToPlatformResponseDtoTypeConverter :
        BaseTypeConverter<Domain.Entities.Platform, PlatformResponseDto>,
        ITypeConverter<Domain.Entities.Platform, PlatformResponseDto>
    {
        #region Implementation of ITypeConverter<in Platform,PlatformResponseDto>

        public PlatformResponseDto Convert(Domain.Entities.Platform source, PlatformResponseDto destination, ResolutionContext context)
        {
            Guard(source, ref destination);

            destination.Id = source.Id;
            destination.Name = source.Name;
            destination.ReleaseDate = source.ReleaseDate;

            return destination;
        }

        #endregion
    }
}
