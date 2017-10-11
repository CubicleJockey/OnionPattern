using System;

namespace OnionPattern.Domain.DataTransferObjects.Platform.Input
{
    public class CreatePlatformInputDto
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
