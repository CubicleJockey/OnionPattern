using Microsoft.EntityFrameworkCore;
using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Game.Entities;
using OnionPattern.Domain.Platform.Entities;

namespace OnionPattern.DataAccess.EF
{
    public interface IVideoGameContext
    {
        DbSet<Game> Games { get; set; }
        DbSet<Platform> Platforms { get; set; }
        DbSet<GamePlatform> GamePlatforms { get; set; }
    }
}