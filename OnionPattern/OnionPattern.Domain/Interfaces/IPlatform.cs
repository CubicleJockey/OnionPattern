using System;

namespace OnionPattern.Domain.Interfaces
{
    public interface IPlatform
    {
        int Id { get; set; }
        string Name { get; set; }
        DateTime ReleaseDate { get; set; }
    }
}