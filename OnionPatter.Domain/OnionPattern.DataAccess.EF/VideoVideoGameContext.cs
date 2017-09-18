using Microsoft.EntityFrameworkCore;
using OnionPattern.Domain.Entities;

namespace OnionPattern.DataAccess.EF
{
    public class VideoVideoGameContext : DbContext, IVideoGameContext
    {
        public VideoVideoGameContext(DbContextOptions options) : base(options) { }

        public DbSet<Game> Games { get; set; }
        public DbSet<Platform> Platforms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().ToTable(nameof(Game));
            modelBuilder.Entity<Platform>().ToTable(nameof(Platform));
        }
    }
}
