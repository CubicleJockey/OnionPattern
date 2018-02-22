using System;
using System.Collections.Generic;
using OnionPattern.Domain.Entities;

namespace OnionPattern.Domain.Platform.Entities
{
    public class Platform : VideoGameEntity, IPlatform
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }

        public ICollection<GamePlatform> GamePlatforms { get; set; }
    }
}
