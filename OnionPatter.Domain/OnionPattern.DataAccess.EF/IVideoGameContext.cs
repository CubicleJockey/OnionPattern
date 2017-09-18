using Microsoft.EntityFrameworkCore;
using OnionPattern.Domain.Entities;

namespace OnionPattern.DataAccess.EF
{
    public interface IVideoGameContext
    {
        DbSet<Game> Games { get; set; }
        DbSet<Platform> Platforms { get; set; }
    }
}