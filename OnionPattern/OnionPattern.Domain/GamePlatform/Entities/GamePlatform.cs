namespace OnionPattern.Domain.GamePlatform.Entities
{
    public class GamePlatform : VideoGameEntity
    {
        public int GameId { get; set; }
        public int PlatformId { get; set; }

        public Game.Entities.Game Game { get; set; }
        public Platform.Entities.Platform Plathform { get; set; }
    
    }
}
