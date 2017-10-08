using OnionPattern.Domain.Entities;

namespace OnionPattern.Domain.Repository
{
    public interface IRepositoryAsyncAggregate
    {
        IRepositoryAsync<Game> Games { get; }
        IRepositoryAsync<Platform> Platforms { get; }
        IRepositoryAsync<GamePlatform> GamePlatforms { get; }
    }
}