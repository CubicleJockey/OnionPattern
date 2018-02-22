using System;

namespace OnionPattern.Domain.Game
{
    public interface IGame
    {
        int Id { get; set; }
        string Name { get; set; }
        string Genre { get; set; }
        decimal Price { get; set; }
        DateTime ReleaseDate { get; set; }
    }
}