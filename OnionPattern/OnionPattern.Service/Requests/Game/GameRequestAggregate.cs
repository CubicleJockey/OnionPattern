using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Game;
using Serilog;
using System;

namespace OnionPattern.Service.Requests.Game
{
    public class GameRequestAggregate : IGameRequestAggregate
    {
        private readonly IRepository<Domain.Entities.Game> repository;
        private readonly IRepositoryAggregate repositoryAggregate;
        private readonly ILogger logger;

        public GameRequestAggregate(IRepository<Domain.Entities.Game> repository, 
                                    IRepositoryAggregate repositoryAggregate, 
                                    ILogger logger)
        {
            this.repository = repository ?? throw new ArgumentNullException($"{nameof(repository)} cannot be null.");
            this.repositoryAggregate = repositoryAggregate ?? throw new ArgumentNullException($"{nameof(repositoryAggregate)} cannot be null.");
            this.logger = logger ?? throw new ArgumentNullException($"{nameof(logger)} cannot be null.");
        }

        #region Implementation of IGameRequestAggregate

        private ICreateGameRequest createGameRequest;
        public ICreateGameRequest CreateGameRequest => createGameRequest ?? (createGameRequest = new CreateGameRequest(repository, repositoryAggregate, logger));

        private IDeleteGameByIdRequest deleteGameByIdRequest;
        public IDeleteGameByIdRequest DeleteGameByIdRequest =>deleteGameByIdRequest ?? (deleteGameByIdRequest = new DeleteGameByIdRequest(repository, repositoryAggregate, logger));

        private IGetAllGamesRequest getAllGamesRequest;
        public IGetAllGamesRequest GetAllGamesRequest => getAllGamesRequest ?? (getAllGamesRequest = new GetAllGamesRequest(repository, repositoryAggregate, logger));

        private IGetGameByIdRequest getGameByIdRequest;
        public IGetGameByIdRequest GetGameByIdRequest => getGameByIdRequest ?? (getGameByIdRequest = new GetGameByIdRequest(repository, repositoryAggregate, logger));

        private IGetGamesByGenreRequest getGamesByGenreRequest;
        public IGetGamesByGenreRequest GetGamesByGenreRequest => getGamesByGenreRequest ?? (getGamesByGenreRequest = new GetGamesByGenreRequest(repository, repositoryAggregate, logger));

        private IUpdateGameTitleRequest updateGameTitleRequest;
        public IUpdateGameTitleRequest UpdateGameTitleRequest => updateGameTitleRequest ?? (updateGameTitleRequest = new UpdateGameTitleRequest(repository, repositoryAggregate, logger));

        #endregion
    }
}
