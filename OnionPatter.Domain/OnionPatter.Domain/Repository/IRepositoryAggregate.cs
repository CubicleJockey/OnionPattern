using System.Dynamic;
using OnionPattern.Domain.Entities;

namespace OnionPattern.Domain.Repository
{
    public interface IRepositoryAggregate
    {
        IRepository<Game> Games { get; }
        IRepository<Platform> Platforms { get; }
        IRepository<GamePlatform> GamePlatforms { get; }
    }
}