using OnionPattern.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace OnionPattern.Domain.Entities
{
    public class Game : VideoGameEntity, IGame
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }
        public DateTime ReleaseDate { get; set; }

        public ICollection<GamePlatform> Platforms { get; set; }
    }
}
