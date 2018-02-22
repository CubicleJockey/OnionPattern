using System;

namespace OnionPattern.Domain.Platform.Requests
{
    public class CreatePlatformInput
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
