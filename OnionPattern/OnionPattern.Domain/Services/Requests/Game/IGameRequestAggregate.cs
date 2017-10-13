namespace OnionPattern.Domain.Services.Requests.Game
{
    public interface IGameRequestAggregate
    {
        ICreateGameRequest CreateGameRequest { get; }
        IDeleteGameByIdRequest DeleteGameByIdRequest { get; }
        IGetAllGamesRequest GetAllGamesRequest { get; }
        IGetGameByIdRequest GetGameByIdRequest { get; }
        IGetGamesByGenreRequest GetGamesByGenreRequest { get; }
        IUpdateGameTitleRequest UpdateGameTitleRequest { get; }
    }
}