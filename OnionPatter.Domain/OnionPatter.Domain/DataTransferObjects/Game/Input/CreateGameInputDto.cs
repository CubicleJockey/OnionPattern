using System;

namespace OnionPattern.Domain.DataTransferObjects.Game.Input
{
    public class CreateGameInputDto
    {
        #region Implementation of IGame

        public string Name { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }
        public DateTime ReleaseDate { get; set; }

        #endregion
    }
}
