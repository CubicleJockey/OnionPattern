using OnionPattern.Domain.Errors;
using System;

namespace OnionPattern.Domain.DataTransferObjects.Game
{
    public class GameResponseDto : ErrorDetails, IGame
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
