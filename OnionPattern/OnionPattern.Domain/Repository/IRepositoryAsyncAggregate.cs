namespace OnionPattern.Domain.Repository
{
    public interface IRepositoryAsyncAggregate
    {
        IRepositoryAsync<Game.Entities.Game> Games { get; }
        IRepositoryAsync<Platform.Entities.Platform> Platforms { get; }
        IRepositoryAsync<GamePlatform.Entities.GamePlatform> GamePlatforms { get; }
    }
}