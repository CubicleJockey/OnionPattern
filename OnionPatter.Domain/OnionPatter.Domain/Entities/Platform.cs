using System;

namespace OnionPattern.Domain.Entities
{
    public class Platform : VideoGameEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
