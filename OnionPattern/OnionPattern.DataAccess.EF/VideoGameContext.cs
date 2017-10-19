using Microsoft.EntityFrameworkCore;
using OnionPattern.Domain.Entities;

namespace OnionPattern.DataAccess.EF
{
    public class VideoGameContext : DbContext, IVideoGameContext
    {
        public VideoGameContext(DbContextOptions options) : base(options) { }

        public DbSet<Game> Games { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<GamePlatform> GamePlatforms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().ToTable(nameof(Game)).Property(g => g.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Platform>().ToTable(nameof(Platform)).Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<GamePlatform>().ToTable(nameof(GamePlatform));//.HasKey(gp => new { gp.GameId, gp.PlatformId });
        }
    }
}
