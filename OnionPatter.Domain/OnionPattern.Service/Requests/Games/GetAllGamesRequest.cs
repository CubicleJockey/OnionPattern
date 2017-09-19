using System.Threading.Tasks;
using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Repository;
using OnionPattern.Service.Responses;

namespace OnionPattern.Service.Requests.Games
{
    public class GetAllGamesRequest : BaseServiceRequest<Game, GetAllGamesResponse>
    {
        public GetAllGamesRequest(IRepository<Game> repository, IRepositoryAggregate repositoryAggregate) : base(repository, repositoryAggregate) { }

        public override Task<GetAllGamesResponse> Execute()
        {
            var games = Repository.GetAll();
            return Task.FromResult(new GetAllGamesResponse
            {
                Games = games
            });
        }
    }
}
