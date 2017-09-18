using Microsoft.EntityFrameworkCore;
using OnionPattern.Domain.Entities;

namespace OnionPattern.DataAccess.EF
{
    public class VideoGameContext : DbContext, IVideoGameContext
    {
        public VideoGameContext(DbContextOptions options) : base(options) { }

        public DbSet<Game> Games { get; set; }
        public DbSet<Platform> Platforms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().ToTable(nameof(Game)).HasMany(game => game.Platforms);
            modelBuilder.Entity<Platform>().ToTable(nameof(Platform)).HasMany(platform => platform.Games);
        }
    }
}
