using AutoMapper;
using OnionPattern.Domain.DataTransferObjects.Platform.Input;

namespace OnionPattern.Mapping.Platform
{
    public class CreatePlatformInputDtoToPlatformTypeConverter : 
        BaseTypeConverter<CreatePlatformInputDto, Domain.Entities.Platform>, 
        ITypeConverter<CreatePlatformInputDto, Domain.Entities.Platform>
    {
        #region Implementation of ITypeConverter<in CreatePlatformInputDto,Platform>

        public Domain.Entities.Platform Convert(CreatePlatformInputDto source, Domain.Entities.Platform destination, ResolutionContext context)
        {
            Guard(source, ref destination);

            destination.Name = source.Name;
            destination.ReleaseDate = source.ReleaseDate;

            return destination;
        }

        #endregion
    }
}
