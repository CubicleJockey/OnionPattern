namespace OnionPattern.Domain.Services.Requests.Game.Async
{
    public interface IGameRequestAggregateAsync
    {
        ICreateGameRequestAsync CreateGameRequestAsync { get; }
        IDeleteGameByIdRequestAsync DeleteGameByIdRequestAsync { get; }
        IGetAllGamesRequestAsync GetAllGamesRequestAsync { get; }
        IGetGameByIdRequestAsync GetGameByIdRequestAsync { get; }
        IGetGamesByGenreRequestAsync GetGamesByGenreRequestAsync { get; }
        IUpdateGameTitleRequestAsync UpdateGameTitleRequest { get; }
    }
}