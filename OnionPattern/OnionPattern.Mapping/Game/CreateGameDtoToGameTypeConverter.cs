using AutoMapper;
using OnionPattern.Domain.DataTransferObjects.Game.Input;

namespace OnionPattern.Mapping.Game
{
    public class CreateGameDtoToGameTypeConverter : ITypeConverter<CreateGameInputDto, Domain.Entities.Game>
    {
        #region Implementation of ITypeConverter<in IGame,Game>

        public Domain.Entities.Game Convert(CreateGameInputDto source, Domain.Entities.Game destination, ResolutionContext context)
        {
            destination = new Domain.Entities.Game
            {
                Name = source.Name,
                Genre = source.Genre,
                Price = source.Price,
                ReleaseDate = source.ReleaseDate
            };
            return destination;
        }

        #endregion
    }
}
