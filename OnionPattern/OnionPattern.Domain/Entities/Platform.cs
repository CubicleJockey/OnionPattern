using System;
using System.Collections.Generic;
using OnionPattern.Domain.DataTransferObjects.Platform;
using OnionPattern.Domain.Interfaces;

namespace OnionPattern.Domain.Entities
{
    public class Platform : VideoGameEntity, IPlatform
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }

        public ICollection<GamePlatform> GamePlatforms { get; set; }
    }
}
