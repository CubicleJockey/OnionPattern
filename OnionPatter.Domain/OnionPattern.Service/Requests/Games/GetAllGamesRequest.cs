using MediatR;
using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Repository;
using OnionPattern.Service.Responses;

namespace OnionPattern.Service.Requests.Games
{
    public class GetAllGamesRequest : BaseRequest<Game, GetAllGamesResponse>, IRequest<GetAllGamesResponse>
    {
        public GetAllGamesRequest(IRepository<Game> repository) : base(repository) { }

        public override GetAllGamesResponse Execute()
        {
            var games = Repository.GetAll();
            return new GetAllGamesResponse
            {
                Games = games
            };
        }
    }
}
