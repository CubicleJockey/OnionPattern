namespace OnionPattern.Domain.Repository
{
    public interface IRepositoryAggregate
    {
        IRepository<Game.Entities.Game> Games { get; }
        IRepository<Platform.Entities.Platform> Platforms { get; }
        IRepository<GamePlatform.Entities.GamePlatform> GamePlatforms { get; }
    }
}