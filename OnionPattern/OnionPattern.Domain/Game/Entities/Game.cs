using System;
using System.Collections.Generic;
using OnionPattern.Domain.Entities;

namespace OnionPattern.Domain.Game.Entities
{
    public class Game : VideoGameEntity, IGame
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }
        public DateTime ReleaseDate { get; set; }

        public ICollection<GamePlatform> Platforms { get; set; } = new List<GamePlatform>();
    }
}
