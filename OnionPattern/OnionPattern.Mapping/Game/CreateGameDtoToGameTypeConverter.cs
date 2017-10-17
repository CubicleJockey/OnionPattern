using System;
using AutoMapper;
using OnionPattern.Domain.DataTransferObjects.Game.Input;

namespace OnionPattern.Mapping.Game
{
    public class CreateGameDtoToGameTypeConverter : ITypeConverter<CreateGameInputDto, Domain.Entities.Game>
    {
        #region Implementation of ITypeConverter<in IGame,Game>

        public Domain.Entities.Game Convert(CreateGameInputDto source, Domain.Entities.Game destination, ResolutionContext context)
        {
            if(source == null) {  throw new ArgumentNullException($"{nameof(source)} cannot be null."); }
            if(destination == null) {  destination = new Domain.Entities.Game(); }

            destination.Name = source.Name;
            destination.Genre = source.Genre;
            destination.Price = source.Price;
            destination.ReleaseDate = source.ReleaseDate;
                
            return destination;
        }

        #endregion
    }
}
