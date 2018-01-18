using AutoMapper;
using OnionPattern.Domain.DataTransferObjects.Game.Input;

namespace OnionPattern.Mapping.Game
{
    public class CreateGameDtoToGameTypeConverter :
        BaseTypeConverter<CreateGameInputDto, Domain.Entities.Game>,
        ITypeConverter<CreateGameInputDto, Domain.Entities.Game>
    {
        #region Implementation of ITypeConverter<in IGame,Game>

        public Domain.Entities.Game Convert(CreateGameInputDto source, Domain.Entities.Game destination, ResolutionContext context)
        {
            Guard(source, ref destination);

            destination.Name = source.Name;
            destination.Genre = source.Genre;
            destination.Price = source.Price;
            destination.ReleaseDate = source.ReleaseDate;
                
            return destination;
        }

        #endregion
    }
}
