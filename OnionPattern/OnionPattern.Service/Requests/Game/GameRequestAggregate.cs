using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Game;
using System;

namespace OnionPattern.Service.Requests.Game
{
    public class GameRequestAggregate : IGameRequestAggregate
    {
        private readonly IRepository<Domain.Entities.Game> repository;
        private readonly IRepositoryAggregate repositoryAggregate;

        public GameRequestAggregate(IRepository<Domain.Entities.Game> repository, IRepositoryAggregate repositoryAggregate)
        {
            this.repository = repository ?? throw new ArgumentNullException($"{nameof(repository)} cannot be null.");
            this.repositoryAggregate = repositoryAggregate ?? throw new ArgumentNullException($"{nameof(repositoryAggregate)} cannot be null.");
        }

        #region Implementation of IGameRequestAggregate

        private ICreateGameRequest createGameRequest;
        public ICreateGameRequest CreateGameRequest => createGameRequest ?? (createGameRequest = new CreateGameRequest(repository, repositoryAggregate));

        private IDeleteGameByIdRequest deleteGameByIdRequest;
        public IDeleteGameByIdRequest DeleteGameByIdRequest =>deleteGameByIdRequest ?? (deleteGameByIdRequest = new DeleteGameByIdRequest(repository, repositoryAggregate));

        private IGetAllGamesRequest getAllGamesRequest;
        public IGetAllGamesRequest GetAllGamesRequest => getAllGamesRequest ?? (getAllGamesRequest = new GetAllGamesRequest(repository, repositoryAggregate));

        private IGetGameByIdRequest getGameByIdRequest;
        public IGetGameByIdRequest GetGameByIdRequest => getGameByIdRequest ?? (getGameByIdRequest = new GetGameByIdRequest(repository, repositoryAggregate));

        private IGetGamesByGenreRequest getGamesByGenreRequest;
        public IGetGamesByGenreRequest GetGamesByGenreRequest => getGamesByGenreRequest ?? (getGamesByGenreRequest = new GetGamesByGenreRequest(repository, repositoryAggregate));

        private IUpdateGameTitleRequest updateGameTitleRequest;
        public IUpdateGameTitleRequest UpdateGameTitleRequest => updateGameTitleRequest ?? (updateGameTitleRequest = new UpdateGameTitleRequest(repository, repositoryAggregate));

        #endregion
    }
}
