using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Game;

namespace OnionPattern.Service.Requests.Game
{
    public class GameRequestAggregate : BaseRequestAggregate<Domain.Entities.Game>, IGameRequestAggregate
    {

        public GameRequestAggregate(IRepository<Domain.Entities.Game> repository, IRepositoryAggregate repositoryAggregate) 
            : base(repository, repositoryAggregate)  {}

        #region Implementation of IGameRequestAggregate

        private ICreateGameRequest createGameRequest;
        public ICreateGameRequest CreateGameRequest => createGameRequest ?? (createGameRequest = new CreateGameRequest(Repository, RepositoryAggregate));

        private IDeleteGameByIdRequest deleteGameByIdRequest;
        public IDeleteGameByIdRequest DeleteGameByIdRequest =>deleteGameByIdRequest ?? (deleteGameByIdRequest = new DeleteGameByIdRequest(Repository, RepositoryAggregate));

        private IGetAllGamesRequest getAllGamesRequest;
        public IGetAllGamesRequest GetAllGamesRequest => getAllGamesRequest ?? (getAllGamesRequest = new GetAllGamesRequest(Repository, RepositoryAggregate));

        private IGetGameByIdRequest getGameByIdRequest;
        public IGetGameByIdRequest GetGameByIdRequest => getGameByIdRequest ?? (getGameByIdRequest = new GetGameByIdRequest(Repository, RepositoryAggregate));

        private IGetGamesByGenreRequest getGamesByGenreRequest;
        public IGetGamesByGenreRequest GetGamesByGenreRequest => getGamesByGenreRequest ?? (getGamesByGenreRequest = new GetGamesByGenreRequest(Repository, RepositoryAggregate));

        private IUpdateGameTitleRequest updateGameTitleRequest;
        public IUpdateGameTitleRequest UpdateGameTitleRequest => updateGameTitleRequest ?? (updateGameTitleRequest = new UpdateGameTitleRequest(Repository, RepositoryAggregate));

        #endregion
    }
}
