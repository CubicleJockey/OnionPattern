using AutoMapper;
using OnionPattern.Domain.DataTransferObjects.Game;

namespace OnionPattern.Mapping.Game
{
    /// <inheritdoc />
    /// <summary>
    /// Converts a Game object into a GameResponseDto.
    /// Only not using the true Auto of Automapper incase other logic wants to be done later.
    /// You can also, unit test your logic this way.
    /// </summary>
    public class GameToGameResponseDtoTypeConverter : 
        BaseTypeConverter<Domain.Entities.Game, GameResponseDto>,
        ITypeConverter<Domain.Entities.Game, GameResponseDto>
    {
        #region Implementation of ITypeConverter<in Game,GameToGameResponseDto>

        public GameResponseDto Convert(Domain.Entities.Game source, GameResponseDto destination, ResolutionContext context)
        {
            Guard(source, ref destination);

            destination.Id = source.Id;
            destination.Name = source.Name;
            destination.Genre = source.Genre;
            destination.Price = source.Price;
            destination.ReleaseDate = source.ReleaseDate;

            return destination;
        }

        #endregion
    }
}
