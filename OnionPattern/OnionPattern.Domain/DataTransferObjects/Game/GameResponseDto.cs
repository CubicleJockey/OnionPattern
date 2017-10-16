using OnionPattern.Domain.Errors;
using System;
using OnionPattern.Domain.Interfaces;

namespace OnionPattern.Domain.DataTransferObjects.Game
{
    public class GameResponseDto : ErrorDetail, IGame
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
