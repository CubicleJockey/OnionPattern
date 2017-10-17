using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Game.Async;

namespace OnionPattern.Service.Requests.Game.Async
{
    public class GameRequestAsyncAggregate : BaseRequestAsyncAggregate<Domain.Entities.Game>, IGameRequestAggregateAsync
    {
        private readonly IRepositoryAsync<Domain.Entities.Game> repositoryAsync;
        private readonly IRepositoryAsyncAggregate repositoryAsyncAggregate;

        public GameRequestAsyncAggregate(IRepositoryAsync<Domain.Entities.Game> repositoryAsync, IRepositoryAsyncAggregate repositoryAsyncAggregate)
            : base(repositoryAsync, repositoryAsyncAggregate) { }

        #region Implementation of IGameRequestAggregateAsync

        private ICreateGameRequestAsync createGameRequestAsync;
        public ICreateGameRequestAsync CreateGameRequestAsync => createGameRequestAsync ??
                                                                 (createGameRequestAsync = new CreateGameRequestAsync(repositoryAsync, repositoryAsyncAggregate));

        private IDeleteGameByIdRequestAsync deleteGameByIdRequestAsync;
        public IDeleteGameByIdRequestAsync DeleteGameByIdRequestAsync => deleteGameByIdRequestAsync ??
                                                                         (deleteGameByIdRequestAsync = new DeleteGameByIdRequestAsync(repositoryAsync, repositoryAsyncAggregate));

        private IGetAllGamesRequestAsync getAllGamesRequestAsync;

        public IGetAllGamesRequestAsync GetAllGamesRequestAsync => getAllGamesRequestAsync ??
                                                                   (getAllGamesRequestAsync = new GetAllGamesRequestAsync(repositoryAsync, repositoryAsyncAggregate));

        private IGetGameByIdRequestAsync getGameByIdRequestAsync;
        public IGetGameByIdRequestAsync GetGameByIdRequestAsync => getGameByIdRequestAsync ??
                                                                   (getGameByIdRequestAsync = new GetGameByIdRequestAsync(repositoryAsync, repositoryAsyncAggregate));

        private IGetGamesByGenreRequestAsync getGamesByGenreRequestAsync;
        public IGetGamesByGenreRequestAsync GetGamesByGenreRequestAsync => getGamesByGenreRequestAsync ??
                                                                          (getGamesByGenreRequestAsync = new GetGamesByGenreRequestAsync(repositoryAsync, repositoryAsyncAggregate));

        private IUpdateGameTitleRequestAsync updateGameTitleRequestAsync;
        public IUpdateGameTitleRequestAsync UpdateGameTitleRequestAsync => updateGameTitleRequestAsync ?? 
                                                                          (updateGameTitleRequestAsync = new UpdateGameTitleRequestAsync(repositoryAsync, repositoryAsyncAggregate));

        #endregion
    }
}
