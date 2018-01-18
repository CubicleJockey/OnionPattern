using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Game.Async;

namespace OnionPattern.Service.Requests.Game.Async
{
    public class GameRequestAsyncAggregate : BaseRequestAsyncAggregate<Domain.Entities.Game>, IGameRequestAggregateAsync
    {
        public GameRequestAsyncAggregate(IRepositoryAsync<Domain.Entities.Game> repositoryAsync, IRepositoryAsyncAggregate repositoryAsyncAggregate)
            : base(repositoryAsync, repositoryAsyncAggregate) { }

        #region Implementation of IGameRequestAggregateAsync

        private ICreateGameRequestAsync createGameRequestAsync;
        public ICreateGameRequestAsync CreateGameRequestAsync => createGameRequestAsync ??
                                                                 (createGameRequestAsync = new CreateGameRequestAsync(RepositoryAsync, RepositoryAsyncAggregate));

        private IDeleteGameByIdRequestAsync deleteGameByIdRequestAsync;
        public IDeleteGameByIdRequestAsync DeleteGameByIdRequestAsync => deleteGameByIdRequestAsync ??
                                                                         (deleteGameByIdRequestAsync = new DeleteGameByIdRequestAsync(RepositoryAsync, RepositoryAsyncAggregate));

        private IGetAllGamesRequestAsync getAllGamesRequestAsync;
        public IGetAllGamesRequestAsync GetAllGamesRequestAsync => getAllGamesRequestAsync ??
                                                                   (getAllGamesRequestAsync = new GetAllGamesRequestAsync(RepositoryAsync, RepositoryAsyncAggregate));

        private IGetGameByIdRequestAsync getGameByIdRequestAsync;
        public IGetGameByIdRequestAsync GetGameByIdRequestAsync => getGameByIdRequestAsync ??
                                                                   (getGameByIdRequestAsync = new GetGameByIdRequestAsync(RepositoryAsync, RepositoryAsyncAggregate));

        private IGetGamesByGenreRequestAsync getGamesByGenreRequestAsync;
        public IGetGamesByGenreRequestAsync GetGamesByGenreRequestAsync => getGamesByGenreRequestAsync ??
                                                                          (getGamesByGenreRequestAsync = new GetGamesByGenreRequestAsync(RepositoryAsync, RepositoryAsyncAggregate));

        private IUpdateGameTitleRequestAsync updateGameTitleRequestAsync;
        public IUpdateGameTitleRequestAsync UpdateGameTitleRequestAsync => updateGameTitleRequestAsync ?? 
                                                                          (updateGameTitleRequestAsync = new UpdateGameTitleRequestAsync(RepositoryAsync, RepositoryAsyncAggregate));

        #endregion
    }
}
