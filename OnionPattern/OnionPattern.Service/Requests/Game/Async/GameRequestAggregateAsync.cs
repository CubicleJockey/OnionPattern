using System;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Game.Async;
using Serilog;

namespace OnionPattern.Service.Requests.Game.Async
{
    public class GameRequestAggregateAsync : IGameRequestAggregateAsync
    {
        private readonly IRepositoryAsync<Domain.Entities.Game> repositoryAsync;
        private readonly IRepositoryAsyncAggregate repositoryAsyncAggregate;
        private readonly ILogger logger;

        public GameRequestAggregateAsync(IRepositoryAsync<Domain.Entities.Game> repositoryAsync,
                                         IRepositoryAsyncAggregate repositoryAsyncAggregate, 
                                         ILogger logger)
        {
            this.repositoryAsync = repositoryAsync ?? throw new ArgumentNullException($"{nameof(repositoryAsync)} cannot be null.");
            this.repositoryAsyncAggregate = repositoryAsyncAggregate ?? throw new ArgumentNullException($"{nameof(repositoryAsyncAggregate)} cannot be null.");
            this.logger = logger ?? throw new ArgumentNullException($"{nameof(logger)} cannot be null.");
        }

        #region Implementation of IGameRequestAggregateAsync

        private ICreateGameRequestAsync createGameRequestAsync;
        public ICreateGameRequestAsync CreateGameRequestAsync => throw new NotImplementedException("TODO!");

        private IDeleteGameByIdRequestAsync deleteGameByIdRequestAsync;
        public IDeleteGameByIdRequestAsync DeleteGameByIdRequestAsync => throw new NotImplementedException("TODO!");

        private IGetAllGamesRequestAsync getAllGamesRequestAsync;

        public IGetAllGamesRequestAsync GetAllGamesRequestAsync => getAllGamesRequestAsync ??
                                                                   (getAllGamesRequestAsync = new GetAllGamesRequestAsync(repositoryAsync, repositoryAsyncAggregate, logger));

        private IGetGameByIdRequestAsync getGameByIdRequestAsync;
        public IGetGameByIdRequestAsync GetGameByIdRequestAsync => getGameByIdRequestAsync ??
                                                              (getGameByIdRequestAsync = new GetGameByIdRequestAsync(repositoryAsync, repositoryAsyncAggregate, logger));

        private IGetGamesByGenreRequestAsync getGamesByGenreRequestAsync;
        public IGetGamesByGenreRequestAsync GetGamesByGenreRequestAsync => throw new NotImplementedException("TODO!");

        private IUpdateGameTitleRequestAsync updateGameTitleRequestAsync;
        public IUpdateGameTitleRequestAsync UpdateGameTitleRequest => throw new NotImplementedException("TODO!");

        #endregion
    }
}
