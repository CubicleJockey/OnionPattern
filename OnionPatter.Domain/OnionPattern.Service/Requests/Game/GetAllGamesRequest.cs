using OnionPattern.Domain.DataTransferObjects.Game;
using OnionPattern.Domain.Repository;
using OnionPattern.Domain.Services.Requests.Game;

namespace OnionPattern.Service.Requests.Game
{
    public class GetAllGamesRequest : BaseServiceRequest<Domain.Entities.Game>, IGetAllGamesRequest
    {
        public GetAllGamesRequest(IRepository<Domain.Entities.Game> repository, IRepositoryAggregate repositoryAggregate) : base(repository, repositoryAggregate) { }


        #region Implementation of IGetAllGamesRequest

        public GameListResponseDto Execute()
        {
            var games = Repository.GetAll();
            return new GameListResponseDto { Games = games };
        }

        #endregion
    }
}
