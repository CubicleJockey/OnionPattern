namespace OnionPattern.Domain.Entities
{
    public class GamePlatform : VideoGameEntity
    {
        public int GameId { get; set; }
        public int PlatformId { get; set; }

        public Game Game { get; set; }
        public Platform Plathform { get; set; }
    
    }
}
