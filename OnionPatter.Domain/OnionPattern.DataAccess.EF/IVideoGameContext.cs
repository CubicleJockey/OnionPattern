using Microsoft.EntityFrameworkCore;
using OnionPattern.DataAccess.EF.Repository;
using OnionPattern.Domain.Entities;

namespace OnionPattern.DataAccess.EF
{
    public interface IVideoGameContext: IDbContext
    {
        DbSet<Game> Games { get; set; }
        DbSet<Platform> Platforms { get; set; }
    }
}