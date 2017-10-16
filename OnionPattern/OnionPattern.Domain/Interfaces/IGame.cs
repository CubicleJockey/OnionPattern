using System;

namespace OnionPattern.Domain.Interfaces
{
    public interface IGame
    {
        int Id { get; set; }
        string Name { get; set; }
        string Genre { get; set; }
        double Price { get; set; }
        DateTime ReleaseDate { get; set; }
    }
}