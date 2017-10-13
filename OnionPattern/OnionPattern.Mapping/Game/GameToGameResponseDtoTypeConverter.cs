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
    public class GameToGameResponseDtoTypeConverter : ITypeConverter<Domain.Entities.Game, GameResponseDto>
    {
        #region Implementation of ITypeConverter<in Game,GameToGameResponseDto>

        public GameResponseDto Convert(Domain.Entities.Game source, GameResponseDto destination, ResolutionContext context)
        {
            //For Simplicity of this Example I am ignoring the fact that destination can be passed in.
            destination = new GameResponseDto
            {
                Id = source.Id,
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
