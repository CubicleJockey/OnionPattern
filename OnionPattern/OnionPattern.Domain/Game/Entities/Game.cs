using System;
using System.Collections.Generic;

namespace OnionPattern.Domain.Game.Entities
{
    public class Game : VideoGameEntity, IGame
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }

        public ICollection<GamePlatform.Entities.GamePlatform> Platforms { get; set; } = new List<GamePlatform.Entities.GamePlatform>();
    }
}
